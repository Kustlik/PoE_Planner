using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_Planner
{
    public class Socket
    {
        public int Group { get; set; } //group id 
        public string Attr { get; set; } //S, I, D, G, false (type is boolean for abyss). Stands for str, int, dex, generic?. G - white socket. 
        public string SColour { get; set; } //G, W, R, B, A. Stands for: green, white, red, blue, abyss (though not a colour but type). 
    }
}
