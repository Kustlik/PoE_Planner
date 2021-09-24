using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_Planner
{
    public class Stashes
    {
        public string Id { get; set; }
        public bool Public { get; set; }
        public string AccountName { get; set; }
        public string LastCharacterName { get; set; }
        public string Stash { get; set; }
        public string StashType { get; set; }
        public string League { get; set; }
        public List<object> Items { get; set; }
    }
}
