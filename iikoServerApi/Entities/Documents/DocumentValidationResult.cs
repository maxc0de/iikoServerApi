using System.Xml.Serialization;

namespace IikoApi.Entities.Documents
{
	[XmlRoot(ElementName = "documentValidationResult")]
	public class DocumentValidationResult
	{
		[XmlElement(ElementName = "valid")]
		public bool Valid { get; set; }

		[XmlElement(ElementName = "warning")]
		public bool Warning { get; set; }

		[XmlElement(ElementName = "documentNumber")]
		public string DocumentNumber { get; set; }

		[XmlElement(ElementName = "errorMessage")]
		public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }

}
