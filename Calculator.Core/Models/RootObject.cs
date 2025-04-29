using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Calculator.Core.Models
{
    public class RootObject
    {
        [XmlElement("Maths")]
        [JsonProperty("Maths")]
        public CalculationResponse Response { get; set; }
    }
}
