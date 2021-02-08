using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IikoServerApi.Entities.Suppliers
{
	[Serializable]
	[XmlRoot(ElementName = "employees")]
	public class Suppliers
	{
		[XmlElement(ElementName = "employee")]
		public Supplier[] SupplierList { get; set; }
	}
}
