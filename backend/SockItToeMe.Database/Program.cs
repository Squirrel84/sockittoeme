using DbUp;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SockItToeMe.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(assemblyFolder)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("ConnStr");

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

#if DEBUG
            Debug.Assert(result.Successful);
#endif

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
