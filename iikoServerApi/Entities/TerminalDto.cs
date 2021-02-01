using System;
using System.Xml.Serialization;

namespace IikoServerApi
{
    [Serializable]
    [XmlRoot("employee")]
    public class TerminalDto
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "computerName")]
        public string ComputerName { get; set; }

        [XmlElement(ElementName = "anonymous")]
        public bool Anonymous { get; set; }

        public override string ToString()
        {
            return ComputerName;
        }
    }
}