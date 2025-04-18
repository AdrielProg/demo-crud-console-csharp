namespace Crud.Employee.Demo.UI;

public static class ConsoleStyles
{
    public static void WriteHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string border = new('═', title.Length + 8);
        Console.WriteLine($"\n╔{border}╗");
        Console.WriteLine($"║    {title}    ║");
        Console.WriteLine($"╚{border}╝\n");
        Console.ResetColor();
    }

    public static void WriteMenuOption(string option, ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(option);
        Console.ResetColor();
    }

    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WritePrompt(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
