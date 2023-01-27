using System.IO;
using System.Text.Json;

namespace Files.JsonFile
{
    public class CreateJsonFile
    {
            public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true
                };
                File.WriteAllText(fileName, JsonSerializer.Serialize(objGraph, options));
            }
    }

}

