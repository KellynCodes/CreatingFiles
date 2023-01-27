using System;
using System.IO;

namespace Files.TxtFile
{
    public class ReadTXTfile
    {
        private static string FileContent { get; set; }
        public static string ReadTXT(string fileName)
        {
                Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

                // Now read data from file.
                Console.WriteLine("Here are your thoughts:\n");
                using (StreamReader sr = File.OpenText(fileName))
                {
                   string input = null;
                   while ((input = sr.ReadLine()) != null)
                   {
                       FileContent = input;
                   }
                }
            return FileContent;
        }
    }
}
