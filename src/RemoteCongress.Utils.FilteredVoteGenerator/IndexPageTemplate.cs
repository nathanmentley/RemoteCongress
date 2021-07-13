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
                    In late 2020 126 gop lawmakers publicly supported a <a href=""https://www.mercurynews.com/2020/12/12/list-the-126-congress-members-19-states-and-2-imaginary-states-that-backed-texas-suit-over-trump-defeat/"">seditious lawsuit</a>.
                    This lawsuit asked the courts to throw out the 2020 election results and appoint Donald Trump as President. It was a direct attack on our democracy by these members of congress.
                    Our constitution, specificly section 3 of the 14th amendment, actually specifically states that no one shall be a senator or representative in congress if they've taken the outh of office and then engaged in insurection or rebillion against the nation. This has previously been interpreted to include seditious speech.
                    I believe that Nancy Pelosi should have refused to seat any of these 126 republicans who were re-elected for the 117th session of congress.
                </div>
            </div>
            <div class=""row p-2"">
                <div class=""col"">
                    This page contains unofficial results to house rollcall votes that filter out the votes from these seditious house members to show what effect sitting these illegitimate congress members has had on our government.
                </div>
            </div>
            <div class=""row p-2"">
                <div class=""col"">
                    117th Congress Session 1 Bill Results
                </div>
            </div>
            @foreach (var result in Model.Bills)
            {
                <div class=""row p-2"">
                    <div class=""col"">
                        <div class=""card card-body shadow-sm p-2"">
                            <div class=""@(result.BillPassed != result.BillLegitimatelyPassed ? ""text-danger"": ""text-secondary"")"">
                                @result.Bill.Title @(result.BillPassed != result.BillLegitimatelyPassed ? ""- Changed Result"": string.Empty)
                            </div>
                            <div id=""@result.BillId"">
                                <div class=""row p-2"">
                                    <div class=""col"">
                                        <div class=""bill-content"">@result.Bill.Content</div>
                                    </div>
                                </div>
                                <div class=""row p-2"">
                                    <div class=""col"">
                                        <table class=""table"">
                                            <thead>
                                                <tr>
                                                    <th scope=""col"">#</th>
                                                    <th scope=""col"">Bill Passed</th>
                                                    <th scope=""col"">Passed Illegitimately</th>
                                                    <th scope=""col"">Chanded Result</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <th scope=""row"">@result.Bill.Code</th>
                                                    <td>@result.BillPassed</td>
                                                    <td>@result.BillLegitimatelyPassed</td>
                                                    <td>@(result.BillPassed != result.BillLegitimatelyPassed)</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class=""row p-2"">
                                    <div class=""col"">
                                        <table class=""table"">
                                            <thead>
                                                <tr>
                                                    <th scope=""col"">Yes Votes</th>
                                                    <th scope=""col"">No Votes</th>
                                                    <th scope=""col"">Present Votes</th>
                                                    <th scope=""col"">Illegitimate Yes Votes</th>
                                                    <th scope=""col"">Illegitimate No Votes</th>
                                                    <th scope=""col"">Illegitimate Present Votes</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>@result.ValidYays</td>
                                                    <td>@result.ValidNays</td>
                                                    <td>@result.ValidPresents</td>
                                                    <td>@result.InvalidYays</td>
                                                    <td>@result.InvalidNays</td>
                                                    <td>@result.InvalidPresents</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            }
            <div class=""row p-2"">
                <div class=""col"">
                    Illegitimate Members Currently Sitting In Congress
                </div>
            </div>
            <div class=""row p-2"">
                <div class=""col"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th scope=""col"">First Name</th>
                                <th scope=""col"">Last Name</th>
                                <th scope=""col"">Seat</th>
                                <th scope=""col"">Party</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach (var result in Model.IllegitamteMembers)
                            {
                                <tr>
                                    <td>@result.FirstName</td>
                                    <td>@result.LastName</td>
                                    <td>@result.Seat</td>
                                    <td>@result.Party</td>
                                </tr>
                            }
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js"" integrity=""sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF"" crossorigin=""anonymous""></script>
    </body>
</html>";
    }
}