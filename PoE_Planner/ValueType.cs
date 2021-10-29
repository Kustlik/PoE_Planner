using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoE_Planner
{
    public class ValueType
    {
        [JsonProperty("0")]
        public string Value { get; set; }
        [JsonProperty("1")]
        public int Type { get; set; }
    }
}
