using System;
using System.Xml.Serialization;

namespace IikoApi.Entities.Documents
{
    [Serializable]
    [XmlRoot(ElementName = "document")]
    public class IncomingInvoiceImport
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "transportInvoiceNumber")]
        public string TransportInvoiceNumber { get; set; }

        [XmlElement(ElementName = "incomingDate")]
        public DateTime IncomingDate { get; set; }

        [XmlElement(ElementName = "dateIncoming")]
        public DateTime DateIncoming { get; set; }

        [XmlElement(ElementName = "useDefaultDocumentTime")]
        public bool UseDefaultDocumentTime { get; set; }

        [XmlElement(ElementName = "dueDate")]
        public DateTime DueDate { get; set; }

        [XmlElement(ElementName = "supplier")]
        public Guid Supplier { get; set; }

        [XmlElement(ElementName = "defaultStore")]
        public Guid DefaultStore { get; set; }

        [XmlElement(ElementName = "invoice")]
        public string Invoice { get; set; }

        [XmlElement(ElementName = "documentNumber")]
        public string DocumentNumber { get; set; }

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "distributionAlgorithm")]
        public string DistributionAlgorithm { get; set; }

        [XmlElement(ElementName = "items")]
        public Items Items { get; set; }

        public IncomingInvoiceImport() { }

        public IncomingInvoiceImport(Guid supplier, Guid defaultStore)
        {
            Items = new Items();
            Supplier = supplier;
            DefaultStore = defaultStore;
        }

        public IncomingInvoiceImport(Guid supplier, Guid defaultStore, Item[] items) : this(supplier, defaultStore)
        {
            Items.ItemList.AddRange(items);
        }

        public void AddItem(Item item)
        {
            Items.ItemList.Add(item);
        }
    }
}
