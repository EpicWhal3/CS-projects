namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class ConsoleInterface
{
    private readonly CommandParser _commandParser;

    public ConsoleInterface(CommandParser commandParser)
    {
        _commandParser = commandParser;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the File System Manager!");
        Console.WriteLine("Type a command or 'help' for a list of available commands.");
        Console.WriteLine("Type 'exit' to quit the application.");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting the application. Goodbye!");
                break;
            }

            if (input.Trim().Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                PrintHelp();
                continue;
            }

            _commandParser.ParseAndExecute(input);
        }
    }

    private static void PrintHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("  connect [Address] [-m Mode]        - Connect to a file system");
        Console.WriteLine("  disconnect                         - Disconnect from the file system");
        Console.WriteLine("  tree list [Path] {-d Depth}        - List directory contents");
        Console.WriteLine("  file show [Path] {-m Mode}         - Show file content");
        Console.WriteLine("  file move [SourcePath] [DestPath]  - Move a file");
        Console.WriteLine("  file copy [SourcePath] [DestPath]  - Copy a file");
        Console.WriteLine("  file delete [Path]                 - Delete a file");
        Console.WriteLine("  file rename [Path] [Name]          - Rename a file");
        Console.WriteLine("  exit                               - End session");
    }
}