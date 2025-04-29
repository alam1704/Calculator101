using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Calculator.Core.Models
{
    public class MathsOperation
    {
        [XmlAttribute("ID")]
        [JsonProperty("@ID")]
        public OperationType ID { get; set; }

        [XmlElement("Value")]
        [JsonProperty("Value")]
        public List<string> Values { get; set; } = new List<string>();

        [XmlElement("Operation")]
        [JsonProperty("Operation")]
        public MathsOperation SubOperation { get; set; }
    }
}
