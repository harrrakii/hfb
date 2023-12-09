namespace HotKeys2;

public static class ConsoleExtensions
{
    public static ConsoleKey ReadKey()
    {
        var key = Console.ReadKey().Key;
        Console.SetCursorPosition(Console.GetCursorPosition().Left - 1, Console.GetCursorPosition().Top);
        Console.WriteLine();

        return key;
    }
}