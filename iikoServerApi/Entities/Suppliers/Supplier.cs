using System;
using System.Xml.Serialization;

namespace IikoServerApi.Entities.Suppliers
{
	[Serializable]
	[XmlRoot(ElementName = "employee")]
	public class Supplier
    {
		[XmlElement(ElementName = "id")]
		public Guid Id { get; set; }

		[XmlElement(ElementName = "code")]
		public string Code { get; set; }

		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

        [XmlElement(ElementName = "login")]
        public string Login { get; set; }

        [XmlElement(ElementName = "cardNumber")]
        public string CardNumber { get; set; }

        [XmlElement(ElementName = "taxpayerIdNumber")]
        public string TaxpayerIdNumber { get; set; }

        [XmlElement(ElementName = "snils")]
        public string Snils { get; set; }

        [XmlElement(ElementName = "preferredDepartmentCode")]
        public string PreferredDepartmentCode { get; set; }

        [XmlElement(ElementName = "deleted")]
        public bool Deleted { get; set; }

        [XmlElement(ElementName = "supplier")]
        public bool IsSupplier { get; set; }

        [XmlElement(ElementName = "employee")]
        public bool Employee { get; set; }

        [XmlElement(ElementName = "client")]
        public bool Client { get; set; }

        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }

        [XmlElement(ElementName = "note")]
        public string Note { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}