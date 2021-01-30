using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace iikoAPIServer
{
    [Serializable]
    [XmlRoot("corporateItemDtoes")]
    public class CorporateItemDtoes
    {
        [XmlElement("corporateItemDto")]
        public List<CorporateItemDto> CorporateItemDtos { get; set; } = new List<CorporateItemDto>();
    }
}
