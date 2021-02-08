using System.Xml.Serialization;

namespace IikoServerApi.Entities.Documents
{
	[XmlRoot(ElementName = "documentValidationResult")]
	public class DocumentValidationResult
	{

		[XmlElement(ElementName = "documentNumber")]
		public string DocumentNumber { get; set; }

		[XmlElement(ElementName = "valid")]
		public bool Valid { get; set; }

		[XmlElement(ElementName = "warning")]
		public bool Warning { get; set; }
	}

}
