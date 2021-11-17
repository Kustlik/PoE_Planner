using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_Planner
{
    public class Property
    {
        public string Name { get; set; }
        public object[] Values { get; set; }
        public int DisplayMode { get; set; }
        public int Type { get; set; }
        // public int Progress { get; set; } //additionalProperties's Experience - TODO something is wrong right there
    }
}
