using System.Diagnostics;
namespace HotKeys2;

public class HotKeyManager
{
    public readonly Dictionary<ConsoleKey, HotKey> HotKeys;

    public HotKeyManager()
    {
        HotKeys = new Dictionary<ConsoleKey, HotKey>();
    }

    public HotKeyManager(string path)
    {
        HotKeys = HotKeyFileManager.ReadHotKeysFromFile(path);
    }

    public void AddNewHotKey(ConsoleKey key, string processPath)
    {
        if (!CanAddKey(key))
        {
            return;
        }

        HotKeys.Add(key, new HotKey(key, processPath));
    }

    public void ModifyHotKey(ConsoleKey existingKey, ConsoleKey newKey, string newProcessPath)
    {
        if (HotKeys.ContainsKey(existingKey))
        {
            HotKeys.Remove(existingKey);
            AddNewHotKey(newKey, newProcessPath);
        }
    }

    public void DeleteHotKey(ConsoleKey key)
    {
        if (HotKeys.ContainsKey(key))
        {
            HotKeys.Remove(key);
        }
    }

    public void Execute(ConsoleKey key)
    {
        if (HotKeys.ContainsKey(key))
        {
            try
            {
                Process.Start(HotKeys[key].ProcessPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public void SaveHotKeysToFile(string path)
    {
        HotKeyFileManager.WriteHotKeysToFile(path, HotKeys);
    }

    public bool CanAddKey(ConsoleKey key)
    {
        return !HotKeys.ContainsKey(key);
    }
}