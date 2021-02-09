using System;
using System.Xml.Serialization;

namespace IikoApi
{
    [Serializable]
    [XmlRoot("employee")]
    public class Employee
    {
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "login")]
        public string Login { get; set; }

        [XmlElement(ElementName = "mainRoleId")]
        public string MainRoleId { get; set; }

        [XmlElement(ElementName = "rolesIds")]
        public string RolesIds { get; set; }

        [XmlElement(ElementName = "mainRoleCode")]
        public string MainRoleCode { get; set; }

        [XmlElement(ElementName = "roleCodes")]
        public string RoleCodes { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "cardNumber")]
        public string CardNumber { get; set; }

        [XmlElement(ElementName = "taxpayerIdNumber")]
        public object TaxpayerIdNumber { get; set; }

        [XmlElement(ElementName = "snils")]
        public string Snils { get; set; }

        [XmlElement(ElementName = "departmentCodes")]
        public string DepartmentCodes { get; set; }

        [XmlElement(ElementName = "responsibilityDepartmentCodes")]
        public string ResponsibilityDepartmentCodes { get; set; }

        [XmlElement(ElementName = "deleted")]
        public bool Deleted { get; set; }

        [XmlElement(ElementName = "supplier")]
        public bool Supplier { get; set; }

        [XmlElement(ElementName = "employee")]
        public bool IsEmployee { get; set; }

        [XmlElement(ElementName = "client")]
        public bool Client { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
