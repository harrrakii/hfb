using System.Text.Json;
namespace Explorer;

public static class RecordsTable
{
    private static List<User> records;
    private static string filePath = "records.json";

    static RecordsTable()
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            records = JsonSerializer.Deserialize<List<User>>(jsonString);
        }
        else
        {
            records = new List<User>();
        }
    }

    public static void AddRecord(User user)
    {
        records.Add(user);
        SaveRecords();
    }

    public static void ShowRecords()
    {
        Console.WriteLine("Records:");
        Console.WriteLine("Name\t\tCPM\t\tCPS");
        foreach (var user in records)
        {
            Console.WriteLine("{0}\t\t{1}\t\t{2}", user.Name, user.CharactersPerMinute, user.CharactersPerSecond);
        }
    }

    private static void SaveRecords()
    {
        string jsonString = JsonSerializer.Serialize(records);
        File.WriteAllText(filePath, jsonString);
    }
}