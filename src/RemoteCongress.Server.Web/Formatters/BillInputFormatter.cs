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

namespace RemoteCongress.Server.Web.Formatters
{
    /// <summary>
    /// Reads and validates a signed <see cref="Bill"/> from the input.
    /// </summary>
    public class BillInputFormatter: BaseInputFormatter<Bill>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BillInputFormatter(): base() {}

        /// <summary>
        /// Converts from a <see cref="SignedData"/> to a <see cref="Bill"/>.
        /// </summary>
        /// <param name="data">
        /// The <see cref="SignedData"/> containing the data to convert.
        /// </param>
        /// <returns>
        /// The validated, and signed <see cref="Bill"/>.
        /// </returns>
        protected override Bill FromSignedData(SignedData data) => new Bill(data);
    }
}