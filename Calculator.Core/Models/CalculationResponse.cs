using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Core.Models
{
    [XmlRoot("Maths")]
    public class CalculationResponse
    {
        [XmlElement("Operation")]
        [JsonProperty("Operation")]
        public MathsOperation Operation { get; set; }
    }
}
