using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Linq;

namespace PoE_Planner
{
    class Tooltip
    {
        static int textHeightSpacing = 20;
        static int textWidthSpacing = 54;
        static int lineSpacing = 5;

        static int tooltipCellSpacing = 35;

        public static void ShowTooltip(Item item, Viewbox tooltip)
        {
            tooltip.Visibility = System.Windows.Visibility.Visible;
            PlaceTooltip(item, tooltip);
        }

        private static void PlaceTooltip(Item item, Viewbox tooltip)
        {
            Canvas.SetLeft(tooltip, (item.X + item.W) * tooltipCellSpacing);
            Canvas.SetTop(tooltip, item.Y * tooltipCellSpacing);
        }
        private static void ResizeTooltipHeight(Item item, Viewbox tooltip)
        {
            int amountOfLines = 0;

            foreach()
            amountOfLines = 
        }
    }
}
