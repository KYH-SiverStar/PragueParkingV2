




using Spectre.Console;

namespace PragueParking
{
    public static class ConsoleInterface
    {
        public static string PromptForInput(string message)
        {
            return AnsiConsole.Ask<string>(message);
        }

        public static void ShowMessage(string message, string color = "green")
        {
            AnsiConsole.MarkupLine($"[{color}]{message}[/]");
        }
    }
}
