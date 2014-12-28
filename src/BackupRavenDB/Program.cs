using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Conditions;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;
using Serilog;
using Serilog.Events;
using SlavaGu.ConsoleAppLauncher;

namespace BackupRavenDB
{
    internal class Program
    {
        private static ILogger logger;
        private static IDocumentStore store;
        private static int AmountOfFailures = 0;

        private static void Main(string[] args)
        {
            logger = new LoggerConfiguration()
                .Destructure.UsingAttributes()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .WriteTo.RollingFile(@"logs\{Date}.txt", LogEventLevel.Verbose)
                .WriteTo.Logentries(AppSettings.LogEntriesToken)
                .CreateLogger();

            Log.Logger = logger;

            store = new DocumentStore()
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();


            Task t = MainAsync(args);
            t.Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            logger.Information("Retrieving list of databases on server: {url}", store.Url);

            var databases = await store.AsyncDatabaseCommands.GlobalAdmin.GetDatabaseNamesAsync(Int32.MaxValue);
            logger.Information("Found the following databases: {databases}", databases);

            var datbaseBackups = databases.ToList();
            datbaseBackups.Add("system");
            datbaseBackups.ForEach(databaseName =>
            {
                var destination =
                    new Uri(Path.Combine(AppSettings.BackupDestination, Environment.MachineName, databaseName,
                        DateTime.UtcNow.ToString("u").Replace(' ', '-').Replace(':', '-')));

                Directory.CreateDirectory(destination.LocalPath);

                BackupDatabase(databaseName, destination);
            });

            if (AmountOfFailures > 0)
            {
                logger.Fatal(
                    "{0} failures occurred whilst backing up. Please review the logs to determine which database backups failed.",
                    AmountOfFailures);
                Environment.Exit(AmountOfFailures);
            }

            Log.Information("Databases: {datbaseBackups} were successfully backed up.", datbaseBackups);
            Environment.Exit(0);
        }

        private static void BackupDatabase(string databaseName, Uri destinationPath)
        {
            Condition.Requires(databaseName, "databaseName").IsNotNullOrWhiteSpace();
            Condition.Requires(destinationPath, "destinationPath").IsNotNull().Evaluate(x => x.IsFile);

            logger.Information("Backing up database: {database} to {destination}", databaseName,
                destinationPath.LocalPath);

            using (logger.BeginTimedOperation("Database Backup", databaseName))
            {
                if (databaseName.Equals("system"))
                {
                    databaseName = String.Empty;
                }
                var backupCommandArgs = String.Format("--url={0} --dest={1} --database={2}", store.Url, destinationPath.LocalPath, databaseName);
                var backupCommand = new ConsoleApp("Raven.Backup.exe", backupCommandArgs);
                backupCommand.ConsoleOutput += (o, args) =>
                {
                    if (args.Line.Contains("Failed") || args.Line.Contains("Error"))
                    {
                        logger.Error(args.Line);

                        AmountOfFailures++;
                    }
                    else
                    {
                        logger.Debug(args.Line);
                    }
                };
                backupCommand.Run();
                backupCommand.WaitForExit();
                if (backupCommand.ExitCode != null)
                {
                    AmountOfFailures += backupCommand.ExitCode.Value;
                }
            }
        }
    }
}
