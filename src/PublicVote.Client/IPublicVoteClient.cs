/*
    PublicVote - A platform for conducting small secure public elections
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
using PublicVote.Common;
using System.Threading.Tasks;

namespace PublicVote.Client
{
    /// <summary>
    /// An interface that defines a client for communicating with the PublicVote Api Server
    /// </summary>
    public interface IPublicVoteClient
    {
        /// <summary>
        /// Creates, signs, and persists a <see cref="Bill"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Bill"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Bill"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="title">
        /// The title of the <see cref="Bill"/>.
        /// </param>
        /// <param name="content">
        /// The content of the <see cref="Bill"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        Task<Bill> CreateBill(string privateKey, string publicKey, string title, string content);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Bill"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Bill"/>.
        /// </returns>
        Task<Bill> GetBill(string id);

        /// <summary>
        /// Creates, signs, and persists a <see cref="Vote"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <see cref="Vote"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <see cref="Vote"/> to
        ///     the producing individual.
        /// </param>
        /// <param name="billId">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/> related to the <see cref="Vote"/>.
        /// </param>
        /// <param name="opinion">
        /// The opinion in the <see cref="Vote"/>.
        /// </param>
        /// <param name="message">
        /// The optional message attached to the <see cref="Vote"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        Task<Vote> CreateVote(string privateKey, string publicKey, string billId, bool? opinon, string message);

        /// <summary>
        /// Fetches a signed, and verified <see cref="Vote"/> by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Vote"/>.
        /// </param>
        /// <returns>
        /// The persisted <see cref="Vote"/>.
        /// </returns>
        Task<Vote> GetVote(string id);
    }
}