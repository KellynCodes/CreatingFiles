using System.Text.Json;
using System.IO;

namespace Files.JsonFile
{
    public class ReadJsonFile
    {
            public static T ReadJson<T>(string fileName) =>
                JsonSerializer.Deserialize<T>(File.ReadAllText(fileName));
    }
}
