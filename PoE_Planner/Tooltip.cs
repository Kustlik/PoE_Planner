using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PoE_Planner
{
    class Tooltip
    {
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
    }
}
