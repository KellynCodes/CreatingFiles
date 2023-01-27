using System.Collections.Generic;

namespace FileContent.Model
{
    public class ObjectData
    {
        public ObjectData()
        {
            Properties = new List<Property>();
            Methods = new List<Methods>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Property Constructor { get; set; }
        public List<Property> Properties { get; set; }
        public List<Methods> Methods { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Methods : Property
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
