using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IikoServerApi
{
    [DataContract]
    public class ReportModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string InvariantName { get; set; }

        [DataMember]
        public List<Сondition> Conditions { get; set; }

        public ReportModel()
        {
            Conditions = new List<Сondition>();
        }

        public ReportModel(string name, string invariantName) : this()
        {
            Name = name;
            InvariantName = invariantName;
        }

        public void AddCondition(string name, object value)
        {
            Conditions.Add(new Сondition(name, value));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
