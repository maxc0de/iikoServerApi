using System;
using System.Xml.Serialization;

namespace IikoServerApi
{
    [Serializable]
    public class CorporateItemDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
