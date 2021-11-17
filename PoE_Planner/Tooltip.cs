using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PoE_Planner
{
    class Tooltip
    {
        static int tooltipCellSpacing = 35;

        public static void ShowTooltip(Item item, StackPanel tooltip)
        {
            tooltip.Visibility = System.Windows.Visibility.Visible;
            PlaceTooltip(item, tooltip);

        }

        private static void PlaceTooltip(Item item, StackPanel tooltip)
        {
            Canvas.SetLeft(tooltip, (item.X + item.W) * tooltipCellSpacing);
            Canvas.SetTop(tooltip, item.Y * tooltipCellSpacing);
        }

        private static void InstantiateTextBox(StackPanel tooltip)
        {
            StackPanel affixStackPanel = (StackPanel)tooltip.Children[1];

            TextBox itemText = new TextBox();
            itemText.Name = "ItemText0";
            itemText.Foreground = new SolidColorBrush(Colors.White);
            itemText.Background = null;
            itemText.BorderBrush = null;
            itemText.TextAlignment = System.Windows.TextAlignment.Center;
            itemText.FontFamily = new FontFamily("Fontin SmallCaps");
            affixStackPanel.Children.Add(itemText);
        }
    }
}
