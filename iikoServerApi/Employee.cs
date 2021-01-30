using System;
using System.Xml.Serialization;

namespace iikoAPIServer
{
    [Serializable]
    [XmlRoot("employee")]
    public class Employee
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
