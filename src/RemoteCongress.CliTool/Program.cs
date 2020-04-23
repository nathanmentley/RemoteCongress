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
using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Client;
using RemoteCongress.Common.Repositories;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.CliTool
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var castVoteCommand = new Command("cast-vote", "cast a vote")
            {
                Handler = CommandHandler.Create<string, string, string, string, bool, string>(
                    async (protocol, hostname, key, billId, opinion, message) => {
                        var client = SetupApp(protocol, hostname);
                        var (privateKey, publicKey) = await SetupKeys(key);

                        var vote = await client.CreateVote(privateKey, publicKey, billId, opinion, message);

                        Console.WriteLine($"cast a new vote with id: {vote.Id}.");
                    }
                )
            };

            var submitBillCommand = new Command("submit-bill", "submit a bill")
            {
                Handler = CommandHandler.Create<string, string, string, string, string>(
                    async (protocol, hostname, key, title, content) => {
                        var client = SetupApp(protocol, hostname);
                        var (privateKey, publicKey) = await SetupKeys(key);

                        var bill = await client.CreateBill(privateKey, publicKey, title, content);

                        Console.WriteLine($"A new bill was submitted with id: {bill.Id}.");
                    }
                )
            };

            var viewBillCommand = new Command("view-bill", "view an already submitted bill")
            {
                Handler = CommandHandler.Create<string, string, string>(
                    async (protocol, hostname, id) => {
                        var client = SetupApp(protocol, hostname);

                        var bill = await client.GetBill(id);

                        Console.WriteLine($"found a bill with id: {bill.Id} - Title: {bill.Title}. Content: {bill.Content}");
                    }
                )
            };

            var viewVoteCommand = new Command("view-vote", "view an already cast vote")
            {
                Handler = CommandHandler.Create<string, string, string>(
                    async (protocol, hostname, id) => {
                        var client = SetupApp(protocol, hostname);

                        var vote = await client.GetVote(id);

                        Console.WriteLine($"found a vote with id: {vote.Id}. For Bill: {vote.BillId}. Opinon: {vote.Opinion}. Message: {vote.Message}.");
                    }
                )
            };

            castVoteCommand.AddOption(
                new Option<string>(
                    "--key",
                    "A file path to the public / private key pair files to use to sign content."
                )
            );

            castVoteCommand.AddOption(
                new Option<string>(
                    "--billId",
                    "The id of the bill to vote on."
                )
            );

            castVoteCommand.AddOption(
                new Option<bool>(
                    "--opinion",
                    "The opinion of the vote."
                )
            );

            castVoteCommand.AddOption(
                new Option<string>(
                    "--message",
                    "The message to include with the vote."
                )
            );

            submitBillCommand.AddOption(
                new Option<string>(
                    "--key",
                    "A file path to the public / private key pair files to use to sign content."
                )
            );

            submitBillCommand.AddOption(
                new Option<string>(
                    "--title",
                    "The title of the bill to create."
                )
            );

            submitBillCommand.AddOption(
                new Option<string>(
                    "--content",
                    "The content of the bill to create."
                )
            );

            viewBillCommand.AddOption(
                new Option<string>(
                    "--id",
                    "The unique id to pull the bill by."
                )
            );

            viewVoteCommand.AddOption(
                new Option<string>(
                    "--id",
                    "The unique id to pull the vote by."
                )
            );

            var rootCommand = new RootCommand
            {
                castVoteCommand,
                submitBillCommand,
                viewBillCommand,
                viewVoteCommand
            };

            rootCommand.AddGlobalOption(
                new Option<string>(
                    "--protocol",
                    () => "http",
                    "The protocol to use to connect to the remote congress server."
                )
            );
            rootCommand.AddGlobalOption(
                new Option<string>(
                    "--hostname",
                    () => "localhost:8000",
                    "The hostname of the remote congress server."
                )
            );

            rootCommand.Description = "Remote Congress CLI Tool";

            rootCommand.Handler = CommandHandler.Create(() => {
                Console.WriteLine("display help message");
            });

            return await rootCommand.InvokeAsync(args);
        }

        public static IRemoteCongressClient SetupApp(string protocol, string hostname)
        {
            // Setup client in DI
            var serviceProvider = GetServiceProvider(new ClientConfig(protocol, hostname));
                //TODO: set service provider up somewhere to dispose
            
            // pull out the client
            return serviceProvider.GetService<IRemoteCongressClient>();
        }

        public static async Task<(string privateKey, string publicKey)> SetupKeys(string key)
        {
            // load keys
            var privateKeyFile = key;
            var publicKeyFile = $"{key}.pub";
            var (privateKey, publicKey) = await ReadKeys(privateKeyFile, publicKeyFile);

            return (privateKey, publicKey);
        }

        private static async Task<(string, string)> ReadKeys(string privateKeyFile, string publicKeyFile)
        {
            var privateKeyData = await File.ReadAllTextAsync(privateKeyFile, Encoding.UTF8);
            var publicKeyData = await File.ReadAllTextAsync(publicKeyFile, Encoding.UTF8);

            return (TrimKey(privateKeyData), TrimKey(publicKeyData));
        }

        private static string TrimKey(string key)
        {
            //TODO: This is hacky. We should detect the key type. Verify, and then clean it up.
            key = key.Trim();
            key = key.Substring(key.IndexOf(Environment.NewLine));
            key = key.Substring(0, key.LastIndexOf(Environment.NewLine));
            key = key.Trim();
            key = key.Replace("\n", string.Empty);
            key = key.Replace("\r", string.Empty);

            return key;
        }

        private static ServiceProvider GetServiceProvider(ClientConfig config) =>
            new ServiceCollection()
                .AddSingleton<HttpClient>(_ => {
                    var handler = new HttpClientHandler();
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = 
                        (httpRequestMessage, cert, cetChain, policyErrors) => true;

                    return new HttpClient(handler);
                })
                .AddSingleton<ClientConfig>(config)

                .AddSingleton<IBillRepository, BillRepository>(provider =>
                    new BillRepository(
                        new HttpDataClient(
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            "bill"
                        )
                    )
                )
                .AddSingleton<IVoteRepository, VoteRepository>(provider =>
                    new VoteRepository(
                        new HttpDataClient(
                            provider.GetRequiredService<ClientConfig>(),
                            provider.GetRequiredService<HttpClient>(),
                            "vote"
                        )
                    )
                )

                .AddSingleton<IRemoteCongressClient, RemoteCongressClient>()

                .BuildServiceProvider();
    }
}
