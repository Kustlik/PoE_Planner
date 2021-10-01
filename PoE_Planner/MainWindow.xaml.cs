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
                var myStashes = await "https://www.pathofexile.com/character-window/get-stash-items?league=Expedition&accountName=Ikestius&tabs=1,21&tabIndex=1,21"
                .WithCookie("POESESSID", SessionIDTextBox.Text) // SESSIONID dc9c724aaf50aa41790959af043c7c9e
                .GetAsync()
                .ReceiveJson<ProfileStashes>();

                var numTabs = myStashes.NumTabs;
                ResultTextBox.Text = numTabs.ToString();
            }
            catch(FlurlHttpException)
            {
                SessionIDTextBox.Text = "Enter Your SessionID...";
                SessionIDTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8A9999");
            }
        }

        private async void Simulation_Button(object sender, RoutedEventArgs e)
        {
            var stashes = await "http://www.pathofexile.com/api/public-stash-tabs"
            .GetAsync()
            .ReceiveJson<Post>();

            System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();



            var myStashes = await "https://www.pathofexile.com/character-window/get-stash-items?league=Expedition&accountName=Ikestius&tabs=1,21&tabIndex=1,21"
                .WithCookie("POESESSID", "dc9c724aaf50aa41790959af043c7c9e")
                .GetAsync()
                .ReceiveJson<ProfileStashes>();

            var numTabs = myStashes.NumTabs;
            ResultTextBox.Text = numTabs.ToString();
        }

        private async Task<string> ReturnCurrentChangeId()
        {
            var poeNinjaApi = "https://poe.ninja/api/Data/GetStats";
            var poeNinjaPost = await poeNinjaApi.GetAsync().ReceiveJson<PoeNinjaPost>();

            var currentChangeId = poeNinjaPost.NextChangeId;

            return currentChangeId.ToString();
        }

        private void SessionIDTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextBox = (TextBox)sender;
            if (focusedTextBox.Text == "Enter Your SessionID...")
            {
                focusedTextBox.Text = "";
                focusedTextBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void SessionID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                Keyboard.ClearFocus();
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(SessionIDTextBox), null);
            }
        }

        private void SessionIDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextBox = (TextBox)sender;
            if (focusedTextBox.Text == "")
            {
                focusedTextBox.Text = "Enter Your SessionID...";
                focusedTextBox.Foreground = (SolidColorBrush) new BrushConverter().ConvertFrom("#FF8A9999");
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
