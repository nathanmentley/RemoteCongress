/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Microsoft.Extensions.Logging;
using RazorEngine;
using RazorEngine.Templating;
using RemoteCongress.Client;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Util.FilteredVoteGenerator
{
    /// <summary>
    /// Application logic.
    /// </summary>
    public class App: IApp
    {
        /// <summary>
        /// The <see cref="IRemoteCongressClient"/> to seed against.
        /// </summary>
        private readonly IRemoteCongressClient _client;

        /// <summary>
        /// An <see cref="ILogger"/> to log against.
        /// </summary>
        private readonly ILogger<App> _logger;

        private readonly IList<string> _bannedMemberIds = new List<string>()
        {

        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="client">
        /// The <see cref="IRemoteCongressClient"/> to seed against.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="client"/> is null.
        /// </exception>
        public App(
            ILogger<App> logger,
            IRemoteCongressClient client
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            if (client is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(client)),
                    LogLevel.Debug
                );
            }

            _client = client;

            Engine.Razor.Compile(
                Templates.BillTemplate,
                Templates.BillTemplateName,
                typeof(BillResult)
            );

            Engine.Razor.Compile(
                Templates.IndexTemplate,
                Templates.IndexTemplateName,
                typeof(IEnumerable<BillResult>)
            );
        }

        /// <summary>
        /// Runs the seed data logic.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <returns>
        /// The result code
        /// </returns>
        public async Task<int> Run(CancellationToken cancellationToken)
        {
            try
            {
                await Logic(cancellationToken);
            }
            catch(Exception exception)
            {
                _logger.LogException(exception, LogLevel.Debug);

                return exception switch
                {
                    BaseRemoteCongressException _ =>
                        AppResultCode.UnknownError,
                    OperationCanceledException _ =>
                        AppResultCode.OperationCancelled,
                    _ =>
                        AppResultCode.UnknownError
                };
            }

            return AppResultCode.Success;
        }

        /// <summary>
        /// Runs the logic to seed data.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        private async Task Logic(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            IDictionary<string, Member> members = await GetMembers(cancellationToken);

            IList<string> bannedKeys = GetBannedKeys(members);

            IAsyncEnumerable<VerifiedData<Bill>> bills =
                _client.GetBills(new List<IQuery>(), cancellationToken);

            int count = 0;
            List<BillResult> billResults = new List<BillResult>();
            IList<Task<BillResult>> billTasks = new List<Task<BillResult>>();
            await foreach(VerifiedData<Bill> bill in bills)
            {
                if (count % 10 == 0)
                {
                    billResults.AddRange(await Task.WhenAll(billTasks));

                    billTasks.Clear();
                }

                billTasks.Add(
                    ProcessBill(members, bannedKeys, bill, cancellationToken)
                );

                count++;
            }

            billResults.AddRange(await Task.WhenAll(billTasks));

            await RenderIndexPage(billResults, cancellationToken);
        }

        private async Task<IDictionary<string, Member>> GetMembers(
            CancellationToken cancellationToken
        )
        {
            IDictionary<string, Member> result = new Dictionary<string, Member>();

            IAsyncEnumerable<VerifiedData<Member>> members =
                _client.GetMembers(new List<IQuery>(), cancellationToken);

            await foreach(VerifiedData<Member> member in members)
            {
                result.Add(member.Data.PublicKey, member.Data);
            }

            return result;
        }

        private IList<string> GetBannedKeys(IDictionary<string, Member> members)
        {
            IList<string> result = new List<string>();

            foreach((string key, Member member) in members)
            {
                if (_bannedMemberIds.Contains(member.Id))
                {
                    result.Add(key);
                }
            }

            return result;
        }

        private async Task<BillResult> ProcessBill(
            IDictionary<string, Member> members,
            IList<string> bannedKeys,
            VerifiedData<Bill> bill,
            CancellationToken cancellationToken
        )
        {
            BillResult billResult = new BillResult()
            {
                BillId = bill.Id,
                Bill = bill.Data
            };

            IAsyncEnumerable<VerifiedData<Vote>> votes = _client.GetVotes(
                new List<IQuery>()
                {
                    new BillIdQuery(bill.Id)
                },
                cancellationToken
            );

            await foreach(VerifiedData<Vote> vote in votes)
            {
                billResult.AddVote(
                    new VoteResult()
                    {
                        Member = members[vote.PublicKey],
                        IsInvalid = bannedKeys.Contains(vote.PublicKey),
                        Opinion = vote.Data.Opinion
                    }
                );
            }

            await RenderBillPage(billResult, cancellationToken);

            return billResult;
        }

        private async Task RenderBillPage(
            BillResult billResult,
            CancellationToken cancellationToken
        ) =>
            await RenderToFile(
                Templates.BillTemplateName,
                $"data/{billResult.BillId}.html",
                billResult,
                cancellationToken
            );

        private async Task RenderIndexPage(
            IEnumerable<BillResult> billResults,
            CancellationToken cancellationToken
        ) =>
            await RenderToFile(
                Templates.IndexTemplateName,
                $"data/index.html",
                billResults,
                cancellationToken
            );

        private async Task RenderToFile<TModel>(
            string templateName,
            string file,
            TModel model,
            CancellationToken cancellationToken
        )
        {
            string result = Engine.Razor.Run(
                templateName,
                typeof(TModel),
                model
            );

            await File.WriteAllTextAsync(
                file,
                result,
                cancellationToken
            );
        }
    }
}