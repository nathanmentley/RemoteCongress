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
using Microsoft.Extensions.Logging;
using RemoteCongress.Client;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DataSeeder
{
    class Program
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string AdminPrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
d6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40FKdqbPS9sqAz1op32vOHHvB1
rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkwkwMRyHisc6diIMoNAgMBAAEC
gYAi/1buxBeS4A1yKso8EnoD4JjAywa2D2+kVNWauvpBhoUGbUxlj14y0XopBGDQ
CdmK3hVCurHN2/pgHv5d4aGQ3E394Nslog33uiz/Ianlt0mWQV/s9JolHJymI+na
njP+gMZafqVIePvlHWheJaqhdAF80yU44JJV9E/1RwQg+QJBAMGM0TFwJSOWgkZs
lMshTa8yQUjPtyXjQeqaZFwDF6ZdZLoQQ48ZNrXHz2Kxnkf22s5eovRAORJAPIf5
xvdcld8CQQCKfHA6j62ea2E9FzzDo4FAbaOZ1ZzHfiZJkP5V02g5PvqDa9pL5o2i
Q9MApt3UVzj2KtXZMx5yHSK0nao0YqWTAkAmt7qpPxvO0K7i05m4QMM/hrgUjqi+
hYWMHrJwzZWPjCM4LUS2fX66Qmwz/AADuVfv7HKAldBU3FC/irHIjdbVAkBjYHrU
u0f2t822nhc/uPRGfKb6/Hwd+BuXjRHGGwfelKAGcP3cm5ylhZBEFnp3JwQ8Om7t
By7g6qF+BOof3247AkAkBiZ5okAVl8BGBG4m4RPoUgVzi+ZKwFSxWko4hoo8tMKV
1YvXub7/GoRzqUdnxmo6F3qHl1+uT2CnSJuvkcqI";

        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string AdminPublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";

        private static readonly int Congress = 116;
        private static readonly int Session = 2;

        private static readonly string Hostname = "127.0.0.1:8000";
        private static readonly string Protocol = "http";

        public static async Task Main(string[] args)
        {
            using ServiceProvider serviceProvider = GetServiceProvider(
                new ClientConfig(Protocol, Hostname)
            );

            IApp app = serviceProvider.GetRequiredService<IApp>();

            await app.Run(CancellationToken.None);
        }

        private static ServiceProvider GetServiceProvider(ClientConfig config) =>
            new ServiceCollection()
                .AddSingleton<IKeyGenerator, KeyGenerator>()
                .AddSingleton<IDataSeeder>(provider => 
                    new SenateDataSeeder(
                        provider.GetRequiredService<IKeyGenerator>(),
                        Congress,
                        Session
                    )
                )
                .AddSingleton<IApp>(provider =>
                    new App(
                        provider.GetRequiredService<ILogger<App>>(),
                        AdminPrivateKey,
                        AdminPublicKey,
                        provider.GetRequiredService<IRemoteCongressClient>(),
                        provider.GetRequiredService<IDataSeeder>()
                    )
                )
                .AddRemoteCongressClient(config)
                .BuildServiceProvider();
    }
}