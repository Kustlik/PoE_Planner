using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Flurl.Http;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;

namespace PoE_Planner
{
    public partial class MainWindow : Window
    {
        private static string GetStartupPath() { return Environment.CurrentDirectory; }
        private string GetStashContentJsonPath() { return GetStartupPath() + @"\StashContent.json"; }
        private ProfileStashes CurrentStash { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Connect_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentStash = await AppendConnectHttp(LeagueComboBox.Text, AccountTextBox.Text)
                .WithCookie("POESESSID", SessionIDTextBox.Text) // SESSIONID dc9c724aaf50aa41790959af043c7c9e
                .GetAsync()
                .ReceiveJson<ProfileStashes>();

                // string json = JsonConvert.SerializeObject(myStashes);
                // File.WriteAllText(GetStashContentJsonPath(), json);

                InstantiateItems(CurrentStash.Items);
            }
            catch(FlurlHttpException)
            {
                SessionIDTextBox.Text = InsertStartText(SessionIDTextBox);
                AccountTextBox.Text = InsertStartText(AccountTextBox);
                SessionIDTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8A9999");
            }
        }

        private void InstantiateItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                System.Windows.Controls.Image itemIcon = new();

                BitmapImage bitmap = new();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(item.Icon, UriKind.Absolute);
                bitmap.EndInit();

                itemIcon.Source = bitmap;
                AllocateItemInStash(item, itemIcon);
            }
        }

        private void AllocateItemInStash(Item item, System.Windows.Controls.Image itemIcon)
        {
            int sizePerCubeUnit = 35;

            itemIcon.Name = "Item" + item.Id.ToString();
            itemIcon.IsHitTestVisible = false;
            StashCanvas.Children.Add(itemIcon);

            itemIcon.HorizontalAlignment = HorizontalAlignment.Left;
            itemIcon.VerticalAlignment = VerticalAlignment.Top;

            itemIcon.Width = sizePerCubeUnit * item.W;
            itemIcon.Height = sizePerCubeUnit * item.H;

            var itemXAllocation = item.X * sizePerCubeUnit;
            var itemYAllocation = item.Y * sizePerCubeUnit;

            Canvas.SetLeft(itemIcon, itemXAllocation);
            Canvas.SetTop(itemIcon, itemYAllocation);
        }

        private string AppendConnectHttp(string league, string account)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("https://www.pathofexile.com/character-window/get-stash-items?league=");
            sb.Append(league);
            sb.Append("&accountName=");
            sb.Append(account);
            sb.Append("&tabs=1,0&tabIndex=0");

            return sb.ToString();
        }

        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            var currentCell = (System.Windows.Shapes.Rectangle)sender;

            if (CurrentStash != null)
            {
                HighlightItem(currentCell, true);
            }
        }

        private void Cell_MouseLeave(object sender, MouseEventArgs e)
        {
            var currentCell = (System.Windows.Shapes.Rectangle)sender;

            if (CurrentStash != null)
            {
                HighlightItem(currentCell, false);
            }
        }

        private (int, int) GetCellPosition(System.Windows.Shapes.Rectangle cell) 
        {
            var splittedCellName = cell.Name.Split(new char[] { 'x', 'y' });
            var xPos = int.Parse(splittedCellName[1]);
            var yPos = int.Parse(splittedCellName[2]);

            return (xPos, yPos);
        }

        private void HighlightItem(System.Windows.Shapes.Rectangle currentCell, bool highlight)
        {
            var position = GetCellPosition(currentCell);

            var item = CurrentStash.Items.FirstOrDefault
                (i => i.X <= position.Item1 && position.Item1 < i.X + i.W &&
                      i.Y <= position.Item2 && position.Item2 < i.Y + i.H);

            if (item != null)
            {
                HighlightAllItemCells(item, highlight);
                Tooltip.ShowTooltip(item, TooltipStackPanel);
            }
        }

        private void HighlightAllItemCells(Item item, bool highlight)
        {
            var highlightColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#4C0076FF");
            var disabledColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#000076FF");

            for(int x = item.X; x < item.X + item.W; x++)
            {
                for (int y = item.Y; y < item.Y + item.H; y++)
                {
                    var currentCell = (System.Windows.Shapes.Rectangle)FindName("Cellx" + x + "y" + y);
                    currentCell.Fill = highlight ? highlightColor : disabledColor;
                }
            }
        }

        private void Simulation_Button(object sender, RoutedEventArgs e)
        {

        }

        private static async Task<string> ReturnCurrentChangeId()
        {
            var poeNinjaApi = "https://poe.ninja/api/Data/GetStats";
            var poeNinjaPost = await poeNinjaApi.GetAsync().ReceiveJson<PoeNinjaPost>();

            var currentChangeId = poeNinjaPost.NextChangeId;

            return currentChangeId.ToString();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextBox = (TextBox)sender;
            if (focusedTextBox.Text == InsertStartText(focusedTextBox))
            {
                focusedTextBox.Text = "";
                focusedTextBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox focusedTextBox = (TextBox)sender;
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                Keyboard.ClearFocus();
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(focusedTextBox), null);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextBox = (TextBox)sender;
            if (focusedTextBox.Text == "")
            {
                focusedTextBox.Text = InsertStartText(focusedTextBox);
                focusedTextBox.Foreground = (SolidColorBrush) new BrushConverter().ConvertFrom("#FF8A9999");
            }
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private string InsertStartText(TextBox currentTextBox)
        {
            switch (currentTextBox.Name)
            {
                case "SessionIDTextBox":
                    return "Enter Your SessionID...";

                case "AccountTextBox":
                    return "Enter Your Account...";

                case "CategoryTextBox":
                    return "Category Name";

                default:
                    if (currentTextBox.Name.EndsWith("MinTextBox"))
                    {
                        return "Min";
                    }
                    else if (currentTextBox.Name.EndsWith("MaxTextBox"))
                    {
                        return "Max";
                    }
                    else
                    {
                        return "Wrong Name";
                    }
            }
        }

        /*
        private async Task<Stashes> FollowTheRiver(string account, string league, string character)
        {
            var currentChangeId = await ReturnCurrentChangeId();
            var poeStashApi = "http://www.pathofexile.com/api/public-stash-tabs";
            var topOfTheRiver = poeStashApi + "?id=" + currentChangeId;

            return stashes;
        }
        */









        private static async Task Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, RoutedEventArgs e)
        {

        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }
    }
}
