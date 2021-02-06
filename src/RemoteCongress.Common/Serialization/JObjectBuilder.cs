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
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// 
    /// </summary>
    public class JObjectBuilder
    {
        private readonly IDictionary<string, JToken> _data =
            new Dictionary<string, JToken>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">
        /// 
        /// </param>
        /// <param name="jToken">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public JObjectBuilder WithData(string key, JToken jToken)
        {
            _data[key] = jToken;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public JObject Build()
        {
            JObject jObject = new JObject();

            foreach((string key, JToken data) in _data)
            {
                jObject[key] = data;
            }

            return jObject;
        }
    }
}