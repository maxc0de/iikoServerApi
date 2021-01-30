using System;
using System.Xml.Serialization;

namespace iikoAPIServer
{
    [Serializable]
    [XmlRoot("employees")]
    public class Employees
    {
        [XmlElement(ElementName = "employee")]
        public Employee[] EmployeeList { get; set; }
    }
}
