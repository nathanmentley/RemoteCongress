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

        //https://www.mercurynews.com/2020/12/12/list-the-126-congress-members-19-states-and-2-imaginary-states-that-backed-texas-suit-over-trump-defeat/
        private readonly IList<string> _bannedMemberIds = new List<string>()
        {
            //AL
            "A000055", //Aderholt
            "B001274", //Brooksa
            "P000609", //Palmer
            "R000575", //Rogers

            //AZ
            "B001302", //Biggs
            "L000589", //Lesko

            //AR
            "C001087", //Crawford

            //CA
            "C000059", //Calvert
            "L000578", //LaMalfa
            "M001165", //McCarthy
            "M001177", //McClintock

            //CO
            "B001297", //Buck
            "L000564", //Lamborn

            //FL
            "B001257", //Bilirakis
            "D000600", //Diaz-Balart
            "D000628", //Dunn
            "G000578", //Gaetz
            "P000599", //Posey
            "R000609", //Rutherford
            "S001214", //Steube
            "W000823", //Waltz
            "W000806", //Webster

            //GA
            "A000372", //Allen
            "C001103", //Carter
            "F000465", //Ferguson
            "H001071", //Hice
            "L000583", //Loudermilk
            "S001189", //Scott

            //Id
            "F000469", //Fulcher
            "S001148", //Simpson

            //IL
            "B001295", //Boat
            "L000585", //LaHood

            //IN
            "B001307", //Baird
            "B001299", //Banks
            "H001074", //Hollingsworth
            "P000615", //Pence
            "W000813", //Walorski
            "", //
            "", //
            "", //
            "", //
            "", //
            "", //
            "", //

            /*
Indiana
James Baird
Jim Banks
Trey 
Greg 
Jackie 

Iowa
Steve King

Kansas
Ron Estes
Roger Marshall

Louisiana
Ralph Abraham
Clay Higgins
Mike Johnson
Steve Scalise

Maryland
Andy Harris

Michigan
Jack Bergman
Bill Huizenga
John Moolenaar
Tim Walberg

Minnesota
Tom Emmer
Jim Hagedorn
Pete Stauber

Mississippi
Michael Guest
Trent Kelly
Steven Palazzo

Missouri
Sam Graves
Vicky Hartzler
Billy Long
Blaine Luetkemeyer
Jason Smith
Ann Wagner

Montana
Greg Gianforte

Nebraska
Jeff Fortenberry
Adrian Smith

New Jersey
Jefferson Van Drew

New York
Elise Stefanik
Lee Zeldin

North Carolina
Dan Bishop
Ted Budd
Virginia Foxx
Richard Hudson
Greg Murphy
David Rouzer
Mark Walker

Ohio
Bob Gibbs
Bill Johnson
Jim Jordan
Robert E. Latta
Brad Wenstrup

Oklahoma
Kevin Hern
Markwayne Mullin

Pennsylvania
John Joyce
Fred Keller
Mike Kelly
Daniel Meuser
Scott Perry
Guy Reschenthaler
Glenn Thompson

South Carolina
Jeffrey Duncan
Ralph Norman
Tom Rice
William Timmons
Joe Wilson

Tennessee
Tim Burchett
Scott DesJarlais
Chuck Fleischmann
Mike Green
David Kustoff
John Rose

Texas
Jodey Arrington
Brian Babin
Kevin Brady
Michael C. Burgess
Michael Cloud
K. Michael Conaway
Dan Crenshaw
Bill Flores
Louie Gohmert
Lance Gooden
Kenny Marchant
Randy Weber
Roger Williams
Ron Wright

Virginia
Ben Cline
Morgan Griffith
Robert J. Wittman

Washington
Cathy McMorris Rodgers
Dan Newhouse

West Virginia
Carol Miller
Alex Mooney

Wisconsin
Tom Tiffany
            */
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