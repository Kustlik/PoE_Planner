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

namespace PoE_Planner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static async Task Button_Click(object sender, RoutedEventArgs e)
        {
            var stashes = await "http://www.pathofexile.com/api/public-stash-tabs"
            .GetAsync()
            .ReceiveJson<List<Post>>();

            Console.WriteLine(stashes);
        }

        private async void Simulation_Button(object sender, RoutedEventArgs e)
        {
            var stashes = await "http://www.pathofexile.com/api/public-stash-tabs"
            .GetAsync()
            .ReceiveJson<Post[]>();

            Console.WriteLine(stashes);
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

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
