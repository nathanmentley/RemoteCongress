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
using Microsoft.AspNetCore.Mvc;
using RemoteCongress.Common.Repositories.Queries;

namespace RemoteCongress.Server.Api.ModelBinders
{
    /// <summary>
    /// An attribute to build <see cref="IQuery"/> from the query string.
    /// </summary>
    public class BuildFromQueryAttribute: ModelBinderAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BuildFromQueryAttribute(): base()
        {
            BinderType = typeof(QueryModelBinder);
        }
    }
}