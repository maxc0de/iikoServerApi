using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IikoServerApi.Entities.Documents
{
    [Serializable]
    [XmlRoot("incomingInvoiceDtoes")]
    public class IncomingInvoiceDtoes
    {
        [XmlElement("document")]
        public Document[] DocumentList { get; set; }
    }
}
