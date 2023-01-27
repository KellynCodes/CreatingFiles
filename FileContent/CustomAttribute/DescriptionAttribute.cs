using System;

namespace FileContent.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        [Description("Attribute Description property.")]
        public string? Description { get; set; }

        [Description("Attribute Input property")]
        public string? Input { get; set; }

        [Description("Attribute output property.")]
        public string? Output { get; set; }

        [Description("Attribute Constructor", input: "It accepts three overloads. [description, input and output]", output: "It returns the value of each properties.")]
        public DescriptionAttribute(string description, string input = "", string output = "")
        {
            Description = description;
            Input = input;
            Output = output;
        }

    }
}
