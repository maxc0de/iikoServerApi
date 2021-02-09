using System;
using System.Xml.Serialization;

namespace IikoApi.Entities.Documents
{
    [Serializable]
    [XmlRoot("incomingInvoiceDtoes")]
    public class IncomingInvoiceDtoes
    {
        [XmlElement("document")]
        public IncomingInvoiceExport[] DocumentList { get; set; }
    }
}
