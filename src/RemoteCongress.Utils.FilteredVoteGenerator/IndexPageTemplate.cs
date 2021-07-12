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
    public static class IndexPageTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static string Name = nameof(Content);
 
        /// <summary>
        /// 
        /// </summary>
        public readonly static string Content =
@"<html>
    <head>
        <title>Real House Vote Results</title>
        <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"">
    </head>
    <body>
        <div class=""container"">
            <div class=""row p-2"">
                <div class=""col"">
                </div>
            </div>
            @foreach (var result in Model)
            {
                <div class=""row p-2"">
                    <div class=""col"">
                        <div class=""card card-body shadow-sm p-2"">
                            <div>
                                <a data-bs-toggle=""collapse"" href=""#@result.BillId"" role=""button"" aria-expanded=""false"" aria-controls=""@result.BillId"">
                                    @result.Bill.Title - @(result.BillPassed != result.BillLegitimatelyPassed)
                                </a>
                            </div>
                            <div class=""collapse"" id=""@result.BillId"">
                                <div class=""bill-content"">@result.Bill.Content</div>
                                <hr/>
                                <div class=""bill-passed"">Bill Passed: @result.BillPassed</div>
                                <div class=""bill-legitimately-passed"">Bill Passed Without Illegitimate Congress Members: @result.BillLegitimatelyPassed</div>
                                <div class=""bill-result-changed"">Changed Result: @(result.BillPassed != result.BillLegitimatelyPassed)</div>
                            </div>
                        </div>
                    </div>
                </div>
            }
            <div class=""row p-2"">
                <div class=""col"">
                </div>
            </div>
        </div>

        <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js"" integrity=""sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF"" crossorigin=""anonymous""></script>
    </body>
</html>";
 
    }
}