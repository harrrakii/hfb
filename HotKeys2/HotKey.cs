namespace HotKeys2;

public class HotKey
{
    public HotKey(ConsoleKey key, string processPath)
    {
        ProcessPath = processPath;
        Key = key;
    }

    public readonly ConsoleKey Key;
    public readonly string ProcessPath;

    public override string ToString()
    {
        return $"{Key} - {ProcessPath}";
    }
}
