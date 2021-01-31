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

        [XmlElement(ElementName = "login")]
        public string Login { get; set; }

        [XmlElement(ElementName = "cardNumber")]
        public string CardNumber { get; set; }

        [XmlElement(ElementName = "pinCode")]
        public string PinCode { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
