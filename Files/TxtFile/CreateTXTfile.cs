using System.IO;

namespace Files.TxtFile
{
    public class CreateTXTfile
    {
        public static void CreateAndWrite(string text, string fileName)
        {
            using StreamWriter writer = File.CreateText(fileName);
            writer.Write(text);
            writer.Write(writer.NewLine);
        }
    }
}
