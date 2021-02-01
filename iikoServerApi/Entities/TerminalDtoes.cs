using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IikoServerApi
{
    [Serializable]
    [XmlRoot("terminalDtoes")]
    public class TerminalDtoes
    {
        [XmlElement("terminalDto")]
        public TerminalDto[] TerminalDtoList { get; set; }
    }
}
