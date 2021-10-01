using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoE_Planner
{
    public class Post
    {
        [JsonProperty("next_change_id")]
        public string NextChangeId { get; set; }
        [JsonProperty("stashes")]
        public List<Stashes> Stashes { get; set; }
    }
}
