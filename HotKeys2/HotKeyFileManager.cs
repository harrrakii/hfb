using System.Text.Json;
namespace HotKeys2;

public static class HotKeyFileManager
{
    public static Dictionary<ConsoleKey, HotKey> ReadHotKeysFromFile(string path)
    {
        try
        {
            using var file = new StreamReader(path);
            return JsonSerializer.Deserialize<Dictionary<ConsoleKey, HotKey>>(file.ReadToEnd())!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return new Dictionary<ConsoleKey, HotKey>();
        }
    }

    public static void WriteHotKeysToFile(string path, Dictionary<ConsoleKey, HotKey> hotKeys)
    {
        try
        {
            using var file = new StreamWriter(path);
            file.Write(JsonSerializer.Serialize(hotKeys));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи файла: {ex.Message}");
        }
    }
}
