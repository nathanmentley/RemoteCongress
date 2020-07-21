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
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Repositories
{
    /// <summary>
    /// An interface defining what operations can happen for persisted immutable data types.
    /// </summary>
    /// <typeparam name="TBlock">
    /// A type that inherits from <see cref="BaseBlockModel"/>. So we know it's signed, and immutable.
    /// </typeparam>
    public interface IImmutableDataRepository<TBlock>
        where TBlock: BaseBlockModel
    {
        /// <summary>
        /// Creates and persist the signed and verified <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">
        /// A signed and verified instance of type <typeparamref name="TBlock"/> to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <paramref name="instance"/> model.
        /// </returns>
        Task<TBlock> Create(TBlock instance, CancellationToken cancellationToken);

        /// <summary>
        /// Fetches a persisted instance of <typeparamref name="TBlock"/> that has an <see cref="IIdentifiable.Id"/> that
        ///     matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique <see cref="IIdentifiable.Id"/> of an <typeparamref name="TBlock"/> instance to fetch.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The immutable, and verified <typeparamref name="TBlock"/> instance with an <see cref="IIdentifiable.Id"/>
        ///     of <paramref name="id"/>.
        /// </returns>
        Task<TBlock> Fetch(string id, CancellationToken cancellationToken);
    }
}