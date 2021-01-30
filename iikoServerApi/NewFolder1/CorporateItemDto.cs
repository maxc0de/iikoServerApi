using System;
using System.Xml.Serialization;

namespace iikoAPIServer
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
    }
}
