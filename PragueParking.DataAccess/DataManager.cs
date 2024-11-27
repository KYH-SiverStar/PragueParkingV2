





using System.Text.Json;
using System.IO;

namespace PragueParking.DataAccess
{
    public static class DataManager
    {
        public static void SaveData<T>(string path, T data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public static T LoadData<T>(string path)
        {
            if (!File.Exists(path))
            {
                // Skapa en ny fil eller hantera situationen när filen inte finns
                var defaultData = default(T); // Exempel på att skapa en tom objekt
                SaveData(path, defaultData);
                return defaultData;
            }

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
