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
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Common.Exceptions
{
    /// <summary>
    /// An <see cref="Exception"/> to throw when a <see cref="ISignedData"/>'s <see cref="ISignedData.Signature"/> isn't
    ///     valid for it's <see cref="ISignedData.PublicKey"/> and <see cref="ISignedData.BlockContent"/>.
    ///
    /// This indicates that either:
    ///     * The block was tampered with.
    ///     * Is being sent by someone claming to be someone else.
    ///     * Was corrupted over the network.
    /// 
    /// In any case this is an exception, because our system only operates on immutabe, valid, and signed data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InvalidBlockSignatureException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">
        /// A message describing the exceptional situation in detail.
        /// </param>
        /// <param name="innerException">
        /// Another exception that brought this exception to light.
        /// </param>
        public InvalidBlockSignatureException(string message, Exception innerException):
            base(message, innerException) {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">
        /// A message describing the exceptional situation in detail.
        /// </param>
        public InvalidBlockSignatureException(string message):
            base(message) {}

        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidBlockSignatureException():
            base() {}
    }
}