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

namespace PoE_Planner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Connect_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var myStashes = await AppendConnectHttp(LeagueComboBox.Text, AccountTextBox.Text)
                .WithCookie("POESESSID", SessionIDTextBox.Text) // SESSIONID dc9c724aaf50aa41790959af043c7c9e
                .GetAsync()
                .ReceiveJson<ProfileStashes>();

                var itemIcon = myStashes.Items[38].Icon;
                ResultTextBox.Text = itemIcon.ToString();

                System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(itemIcon, UriKind.Absolute);
                bitmap.EndInit();

                StashWindow.Child = myImage;
                myImage.Source = bitmap;
                myImage.HorizontalAlignment = HorizontalAlignment.Left;
                myImage.VerticalAlignment = VerticalAlignment.Top;
                myImage.Width = 70;
                myImage.Height = 105;
                myImage.Margin = new Thickness(0, 0, 0, 0);
            }
            catch(FlurlHttpException)
            {
                SessionIDTextBox.Text = InsertStartText(SessionIDTextBox);
                AccountTextBox.Text = InsertStartText(AccountTextBox);
                SessionIDTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8A9999");
            }
        }
        //                <Image HorizontalAlignment="Left" Height="100" VerticalAlignment="Top" Width="100" Source="/Blueprint_Repository_inventory_icon.png" Margin="-1,-1,0,0"/>
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

        private void Simulation_Button(object sender, RoutedEventArgs e)
        {

        }

        private async Task<string> ReturnCurrentChangeId()
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,-]+");
            e.Handled = regex.IsMatch(e.Text);
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
