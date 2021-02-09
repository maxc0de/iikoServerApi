using System.Runtime.Serialization;

namespace IikoApi
{
    [DataContract]
    public class Сondition
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public object Value { get; set; }

        [DataMember]
        public string[] Variants { get; set; }

        public Сondition(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
