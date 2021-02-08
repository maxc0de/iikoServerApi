using System;
using System.Xml.Serialization;

namespace IikoServerApi.Entities.Documents
{
	[Serializable]
	[XmlRoot(ElementName = "document")]
	public class Document
	{

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }

		[XmlElement(ElementName = "transportInvoiceNumber")]
		public object TransportInvoiceNumber { get; set; }

		[XmlElement(ElementName = "incomingDate")]
		public DateTime IncomingDate { get; set; }

		[XmlElement(ElementName = "useDefaultDocumentTime")]
		public bool UseDefaultDocumentTime { get; set; }

		[XmlElement(ElementName = "dueDate")]
		public DateTime DueDate { get; set; }

		[XmlElement(ElementName = "supplier")]
		public Guid Supplier { get; set; }

		[XmlElement(ElementName = "defaultStore")]
		public string DefaultStore { get; set; }

		[XmlElement(ElementName = "invoice")]
		public object Invoice { get; set; }

		[XmlElement(ElementName = "documentNumber")]
		public int DocumentNumber { get; set; }

		[XmlElement(ElementName = "status")]
		public string Status { get; set; }

		[XmlElement(ElementName = "distributionAlgorithm")]
		public string DistributionAlgorithm { get; set; }

		[XmlElement(ElementName = "items")]
		public Items Items { get; set; }

		public Document()
        {

        }

		public Document(Guid supplier)
        {
			Items = new Items();
			Supplier = supplier;
        }

		public void AddItem(Item item)
        {
			Items.ItemList.Add(item);
        }
	}
}
