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

namespace RemoteCongress.Util.FilteredVoteGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public static class Templates
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static string BillTemplateName = nameof(BillTemplate);

        /// <summary>
        /// 
        /// </summary>
        public readonly static string BillTemplate =
@"<html>
    <head>
    </head>
    <body>
        <div class=""bill-title"">@Model.Bill.Title</div>
        <div class=""bill-content"">@Model.Bill.Content</div>
        <hr/>
        <div class=""bill-passed"">Bill Passed: @Model.BillPassed</div>
        <div class=""bill-legitimately-passed"">Bill Passed Without Illegitimate Congress Members: @Model.BillLegitimatelyPassed</div>
        <div class=""bill-result-changed"">Changed Result: @(Model.BillPassed != Model.BillLegitimatelyPassed)</div>
    </body>
</html>";
 
        /// <summary>
        /// 
        /// </summary>
        public readonly static string IndexTemplateName = nameof(IndexTemplate);
 
        /// <summary>
        /// 
        /// </summary>
        public readonly static string IndexTemplate =
@"<html>
    <head>
    </head>
    <body>
        @foreach (var result in Model)
        {
            <div>
                <a href=""@(result.BillId).html"">@result.Bill.Title</a> - @(result.BillPassed != result.BillLegitimatelyPassed)
            </div>
        }
    </body>
</html>";
 
    }
}