using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace JsonSerialize
{
    public static class json
    {
        public static void Serialize<T>(T obj, string file)
        {
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(file, json);
        }

        public static ObservableCollection<T> Deserialize<T>(string file)
        {
            try
            {
                var json = File.ReadAllText(file);
                var obj = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                if (obj != null) return obj;
                return new ObservableCollection<T>();
            }
            catch
            {
                return new ObservableCollection<T>();
            }
        }
    }
}