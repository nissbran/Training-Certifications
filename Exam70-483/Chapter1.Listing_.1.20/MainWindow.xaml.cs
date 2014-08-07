using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Chapter1.Listing_._1._20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // This example throws an exception; the Output.Content line is not executed on the UI thread because of the ConfigureAwait(false).
            // If you do something else, such as writing the content to file, you don’t need to set the SynchronizationContext to be set.
            // ConfigureAwait false means that the returning data can be executed on any thread.

            HttpClient client = new HttpClient();

            string content = await client.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);

            Output.Content = content;
        }

    }
}
