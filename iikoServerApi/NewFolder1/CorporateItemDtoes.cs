﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace iikoAPIServer
{
    [Serializable]
    [XmlRoot("corporateItemDtoes")]
    public class CorporateItemDtoes
    {
        [XmlElement("corporateItemDto")]
        public CorporateItemDto[] CorporateItemDtoList { get; set; }
    }
}
