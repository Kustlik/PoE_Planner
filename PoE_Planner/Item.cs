using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_Planner
{
    public class Item
    {
        public bool Verified { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public string Icon { get; set; }
        public string League { get; set; }
        public string Id { get; set; } // 	item id, will NOT change if you use currency on it 
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int FrameType { get; set; }
        public bool Identified { get; set; }
        public int Ilvl { get; set; }
        public string TypeLine { get; set; }

        //Not Always Present Below
       
        public bool AbyssJewel { get; set; }
        public Property[] AdditionalProperties { get; set; } 
        public string ArtFilename { get; set; } //Divination Card 
        public bool Corrupted { get; set; }
        public string[] CosmeticMods { get; set; }
        public string[] CraftedMods { get; set; } //Master Mods
        public string DescrText { get; set; } //Description Text
        public bool Duplicated { get; set; }
        public bool Elder { get; set; } //item was dropped in elder map 
        public string[] EnchantMods { get; set; } //labyrinth mods
        public string[] ExplicitMods { get; set; } //Mods under the line 
        public string[] FlavourText { get; set; }
        public string[] ImplicitMods { get; set; }
        public string InventoryId { get; set; } //slot. 'Stash25', 'Stash3', etc. 
        public bool IsRelic { get; set; }
        public bool LockedToCharacter { get; set; }
        public int MaxStackSize { get; set; }
        public Property[] NextLevelRequirements { get; set; }
        public string Note { get; set; } //Mostly item price 
        public Property[] Properties { get; set; }
        public string ProphecyDiffText { get; set; } //prophecy difficulty text 
        public string ProphecyText { get; set; }
        public Property[] Requirements { get; set; }
        public string SecDescrText { get; set; } //second description text 
        public bool Shaper { get; set; } //item was dropped in shaper map 
        public Item[] SocketedItems { get; set; }
        public Socket[] Sockets { get; set; } //array of sockets
        public int StackSize { get; set; }
        public bool Support { get; set; }
        public int TalismanTier { get; set; }
        public string[] UtilityMods { get; set; }
        
        private Object[] GetSections()
        {
            return new Object[] { Properties, UtilityMods, Requirements, SecDescrText, EnchantMods, ImplicitMods, ExplicitMods, FlavourText, DescrText };
        }

        private void SelectSections()
        {
            for (int i = 0; i < GetSections().Length; i++)
            {
                switch (i)
                {
                    /* TODO
                    case 0:
                        GenerateProperties();
                        break;
                    case 1:
                        GenerateUtilityMods();
                        break;
                    case 2:
                        GenerateRequirements();
                        break;
                    case 3:
                        GenerateSecDescrText();
                        break;
                    case 4:
                        GenerateEnchantMods();
                        break;
                    case 5:
                        GenerateImplicitMods();
                        break;
                    case 6:
                        GenerateExplicitMods();
                        break;
                    case 7:
                        GenerateFlavourText();
                        break;
                    case 8:
                        GenerateDescrText();
                        break;
                    */
                }
            }
        }

        private void GenerateProperties()
        {

        }
    }
}
