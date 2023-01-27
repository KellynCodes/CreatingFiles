using FileContent.Implementation;
using FileContent.Model;
using FileContent.Utility;
using Files.JsonFile;
using Files.PDFfile;
using Files.TxtFile;
using Files.XMLFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File.UI
{
    public class Application
    {

        ///<summary>Method that runs the inhouse code documentation of the project.</summary>
        //This codes below Creates a new text file
        //Code Beggining.
        private static string CrossPlatFormFilePath = $"C{Path.VolumeSeparatorChar}Users{Path.DirectorySeparatorChar}KELLYNCODES{Path.DirectorySeparatorChar}source{Path.DirectorySeparatorChar}repos{Path.DirectorySeparatorChar}CreatingFiles{Path.DirectorySeparatorChar}File.UI{Path.DirectorySeparatorChar}Files{Path.DirectorySeparatorChar}";
        private readonly static string WindowsFilePath = "C:\\Users\\KELLYNCODES\\source\\repos\\CreatingFiles\\File.UI\\Files\\";
        private readonly static string PDFfileName = "MetaDataInfo.pdf";
        private readonly static string XMLFileName = "MetaDataInfo.xml";
        private readonly static string JsonFileName = "MetaDataInfo.json";
        private readonly static string TxtFileName = "MetaDataInfo.txt";

        public static void CreateFile()
        {
            MetaData.GetDocs();
            StringBuilder TextData = MetaData.Data;
            string Text = Convert.ToString(TextData) ?? "Text Input was empty.";
            //if (File.Exists($"{WindowsFilePath}{TxtFileName}")) File.Delete($"{WindowsFilePath}{TxtFileName}");
            CreateTXTfile.CreateAndWrite(Text, $"{WindowsFilePath}{TxtFileName}");
            ConsoleMessage.Message(ConsoleColor.Magenta, $"=> Saved Text in Txt format!. File name: {WindowsFilePath}{TxtFileName}");
            //Text File Created Successfully.

            //Creating a Json File.
            //if (File.Exists($"{WindowsFilePath}{JsonFileName}")) File.Delete($"{WindowsFilePath}{JsonFileName}");
            CreateJsonFile.SaveAsJsonFormat(MetaData.ObjectGraph, $"{JsonFileName}");
            ConsoleMessage.Message(ConsoleColor.Magenta, $"=> Saved Text in JSON format!. File name: {JsonFileName}");

            //Creating an XML File. 
            //if (File.Exists($"{WindowsFilePath}{XMLFileName}")) File.Delete($"{WindowsFilePath}{XMLFileName}");
            CreateXMLfile.SaveAsXmlFormat(MetaData.ObjectGraph, $"{WindowsFilePath}{XMLFileName}");
            ConsoleMessage.Message(ConsoleColor.DarkRed, $"=> Saved Text in XML format!. File name: {XMLFileName}");

            //Creating a PDF File.
            //if (File.Exists($"{WindowsFilePath}{PDFfileName}")) File.Delete($"{WindowsFilePath}{PDFfileName}");
            CreatePDFfile.CreateFile(Text, $"{WindowsFilePath}{PDFfileName}");
            ConsoleMessage.Message(ConsoleColor.DarkGreen, $"=> Saved Text in PDF format!. File name: {PDFfileName}");
        }

        public static void ReadFile()
        {
           List<ObjectData>  JsonFileContent = ReadJsonFile.ReadJson<List<ObjectData>>($"{JsonFileName}");
            List<ObjectData> XMLFileContent = ReadXMLfile.ReadAsXmlFormat<List<ObjectData>>($"{WindowsFilePath}{XMLFileName}");
            string TXTfileContent = ReadTXTfile.ReadTXT($"{WindowsFilePath}{TxtFileName}");
            ConsoleMessage.Message(ConsoleColor.Green, "Which file would you like to read.\n1. Json File.\n2. XML File.\n3. PDF File.\n4. Text File.");
            if(int.TryParse(Console.ReadLine(), out int answer))
                {
                switch (answer)
                {
                    case (int)SwitchCase.CaseOne:
                        foreach(var item in JsonFileContent)
                        {
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.Properties);
                            foreach(var prop in item.Properties)
                            {
                                Console.WriteLine(prop.Name);
                                Console.WriteLine(prop.Description);
                            }
                            foreach (var meth in item.Methods)
                            {
                                Console.WriteLine($"{meth.Description}\n, {meth.Input}\n, {meth.Output}");

                            }
                            Console.WriteLine(item.Description);
                        }
                        break;
                    case (int)SwitchCase.CaseTwo:
                        foreach (var item in XMLFileContent)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case (int)SwitchCase.CaseThree:
                        //Console.WriteLine(PDFfileContent);
                        break;
                    case (int)SwitchCase.CaseFour:
                        Console.WriteLine(TXTfileContent);
                        break;
                }
                }
                else
                {
                    ConsoleMessage.Message(ConsoleColor.Red, "Invalid input. Please try again.");
                }
        }
    }
}
