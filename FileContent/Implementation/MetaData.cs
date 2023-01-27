using FileContent.CustomAttribute;
using FileContent.Model;
using FileContent.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FileContent.Implementation
{
    [Description("This class holds all the implementation of getting information about the metat data.")]
    public class MetaData
    {
        public static List<ObjectData> ObjectGraph { get; set; } = new List<ObjectData>();
        public static ObjectData objectData = new ObjectData();
        public readonly static StringBuilder Data = new StringBuilder();


        [Description("This method return the all the description and information in the assemblies illustrated by the default attribute.")]
        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();

            ConsoleMessage.Message(ConsoleColor.Cyan, $"Assembly name: {assembly.FullName}");
            Console.WriteLine();

            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                DisplayAttribute(type);

                DisplayType(type);

                DisplayConstructor(type);

                DisplayProperties(type);

                DisplayMethods(type);
                if (!string.IsNullOrWhiteSpace(objectData.Name))
                {
                    ObjectGraph.Add(objectData);
                    objectData = new ObjectData();
                }
            }
        }

        public static void DisplayAttribute(Type type)
        {
            DescriptionAttribute Attribute = (DescriptionAttribute)type.GetCustomAttribute(typeof(DescriptionAttribute))!;

            if (Attribute != null)
            {
                objectData.Name = type.Name;
                objectData.Description = Attribute?.Description;
            }
        }

        private static void DisplayMethods(Type type)
        {
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var Attribute = (DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute));

                if (Attribute != null)
                {
                    ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Method: {method.Name}");
                    Data.AppendLine(method.Name);

                    ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Description: {Attribute.Description}");
                    Data.AppendLine(Attribute.Description);

                    if (!string.IsNullOrEmpty(Attribute.Input))
                    {
                        ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Input: {Attribute.Input}");
                        Data.AppendLine(Attribute.Input);
                    }

                    if (!string.IsNullOrEmpty(Attribute.Output))
                    {
                        ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Output: {Attribute.Output}\n");
                        Data.AppendLine(Attribute.Output);
                    }
                    objectData.Methods.Add(new Methods()
                    {
                        Name = method.Name,
                        Description = string.IsNullOrWhiteSpace(Attribute.Description) ? string.Empty : Attribute.Description,
                        Input = string.IsNullOrWhiteSpace(Attribute.Input) ? string.Empty : Attribute.Input,
                        Output = string.IsNullOrWhiteSpace(Attribute.Output) ? string.Empty : Attribute.Output
                    });
                }
            }
        }

        private static void DisplayProperties(Type type)
        {

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                //Gets custom attribute  to property variable. The returned attribute is then being assigned to the documentattribute variable.
                var Attribute = (DescriptionAttribute)property.GetCustomAttribute(typeof(DescriptionAttribute));

                if (Attribute != null)
                {
                    ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Property: {property.Name}");
                    Data.AppendLine(property.Name);

                    ConsoleMessage.Message(ConsoleColor.Cyan, $"\t Description: {Attribute.Description}\n");
                    Data.AppendLine(Attribute.Description);
                }

                objectData.Methods.Add(new Methods()
                {
                    Name = property.Name,
                    Description = string.IsNullOrWhiteSpace(Attribute?.Description) ? string.Empty : Attribute.Description,
                    Input = string.IsNullOrWhiteSpace(Attribute?.Input) ? string.Empty : Attribute.Input,
                    Output = string.IsNullOrWhiteSpace(Attribute?.Output) ? string.Empty : Attribute.Output
                }
                   );
            }
        }

        private static void DisplayConstructor(Type type)
        {

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                var Attribute = (DescriptionAttribute)constructor.GetCustomAttribute(typeof(DescriptionAttribute));

                if (Attribute != null)
                {
                    ConsoleMessage.Message(ConsoleColor.Cyan, $"\t Constructor: {constructor.Name}");
                    Data.AppendLine(constructor.Name);

                    ConsoleMessage.Message(ConsoleColor.Cyan, $"\t Description: {Attribute.Description}");
                    Data.AppendLine(Attribute.Description);

                    if (!string.IsNullOrEmpty(Attribute.Input))
                    {
                        ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Input: {Attribute.Input}");
                        Data.AppendLine(Attribute.Input);
                    }

                    if (!string.IsNullOrEmpty(Attribute.Output))
                    {
                        ConsoleMessage.Message(ConsoleColor.Yellow, $"\t Output: {Attribute.Output}\n");
                        Data.AppendLine(Attribute.Output);
                    }
                    objectData.Methods.Add(new Methods()
                    {
                        Name = constructor.Name,
                        Description = string.IsNullOrWhiteSpace(Attribute.Description) ? string.Empty : Attribute.Description,
                        Input = string.IsNullOrWhiteSpace(Attribute.Input) ? string.Empty : Attribute.Input,
                        Output = string.IsNullOrWhiteSpace(Attribute.Output) ? string.Empty : Attribute.Output
                    }
                   );

                }
            }
        }

        private static void DisplayType(Type type)
        {
            var Attribute = (DescriptionAttribute)type.GetCustomAttribute(typeof(DescriptionAttribute));

            if (Attribute != null && type.IsClass)
            {
                ConsoleMessage.Message(ConsoleColor.Yellow, $"Class: {type.Name}");
                Data.AppendLine(type.Name);

                ConsoleMessage.Message(ConsoleColor.Yellow, $"Description: {Attribute.Description}");
                Data.AppendLine(Attribute.Description);
                objectData.Methods.Add(new Methods()
                {
                    Name = type.Name,
                    Description = string.IsNullOrWhiteSpace(Attribute.Description) ? string.Empty : Attribute.Description,
                    Input = string.IsNullOrWhiteSpace(Attribute.Input) ? string.Empty : Attribute.Input,
                    Output = string.IsNullOrWhiteSpace(Attribute.Output) ? string.Empty : Attribute.Output
                }
                   );
            }
            else if (Attribute != null && type.IsEnum)
            {
                ConsoleMessage.Message(ConsoleColor.Cyan, $"Enum: {type.Name}");
                Data.AppendLine(type.Name);

                ConsoleMessage.Message(ConsoleColor.Cyan, $"Description: {Attribute.Description}\n");
                Data.AppendLine(Attribute.Description);
                objectData.Methods.Add(new Methods()
                {
                    Name = type.Name,
                    Description = string.IsNullOrWhiteSpace(Attribute.Description) ? string.Empty : Attribute.Description,
                    Input = string.IsNullOrWhiteSpace(Attribute.Input) ? string.Empty : Attribute.Input,
                    Output = string.IsNullOrWhiteSpace(Attribute.Output) ? string.Empty : Attribute.Output
                }
                   );
            }
            else if (Attribute != null && type.IsInterface)
            {
                ConsoleMessage.Message(ConsoleColor.Cyan, $"Interface: {type.Name}");
                Data.AppendLine(type.Name);
                ConsoleMessage.Message(ConsoleColor.Cyan, $"Description: {Attribute.Description}\n");
                Data.AppendLine(Attribute.Description);
                objectData.Methods.Add(new Methods()
                {
                    Name = type.Name,
                    Description = string.IsNullOrWhiteSpace(Attribute.Description) ? string.Empty : Attribute.Description,
                    Input = string.IsNullOrWhiteSpace(Attribute.Input) ? string.Empty : Attribute.Input,
                    Output = string.IsNullOrWhiteSpace(Attribute.Output) ? string.Empty : Attribute.Output
                }
                       );
            }
        }
    }
}
