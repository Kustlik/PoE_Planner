using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoE_Planner
{
    public class ProfileStashes
    {
        public int NumTabs { get; set; }
        public List<Item> Items { get; set; }
    }
}
