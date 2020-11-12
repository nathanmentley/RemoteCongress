/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2020  Nathan Mentley

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
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// An interface for a client used to interact an endpoint of the api.
    /// </summary>
    public interface IEndpointClient<TModel>
    {
        /// <summary>
        /// Creates, signs, and persists a <see cref="TModel"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="TModel"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="TModel"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="data">
        /// The <see cref="TModel"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="TModel"/>.
        /// </returns>
        Task<VerifiedData<TModel>> Create(
            string privateKey,
            string publicKey,
            TModel data,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Fetches a signed, and verified <see cref="TModel"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="TModel"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <see cref="TModel"/>.
        /// </returns>
        Task<VerifiedData<TModel>> Get(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Fetches a collection of signed, and verified <see cref="TModel"/>s by <paramref name="query"/>.
        /// </summary>
        /// <param name="query">
        /// A collection of <see cref="IQuery"/>s to filter <see cref="TModel"/> by.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// A collection of persisted <see cref="TModel"/> that matches <paramref name="query"/>.
        /// </returns>
        IAsyncEnumerable<VerifiedData<TModel>> Get(IList<IQuery> query, CancellationToken cancellationToken);
    }
}