using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IikoApi.Entities.Documents
{
    [Serializable]
    [XmlRoot(ElementName = "items")]
    public class Items
    {
        [XmlElement(ElementName = "item")]
        public List<Item> ItemList { get; set; }

        public Items()
        {
            ItemList = new List<Item>();
        }
    }
}
