using DbUp;
using System;
using System.Reflection;

namespace Waling.Dbup;

class Program
{
    static int Main()
    {
        var connectionString = Environment.GetEnvironmentVariable("connectionString");

        EnsureDatabase.For.SqlDatabase(connectionString);
        var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

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
#pragma warning disable CA1303 // Do not pass literals as localized parameters
        Console.WriteLine("Success!");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
        Console.ResetColor();
        return 0;
    }
}
