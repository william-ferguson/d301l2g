using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class page_2 : Page
    {
        public page_2()
        {
            this.InitializeComponent();

        }

        private void tbxGreenSaladLunch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Green_Salad_Lunch));
        }

        private void tbxLambKorma_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Lamb_Korma));
        }

        private void tbxOpenChickenSalad_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Open_Chicken_Sandwitch));
        }

        private void tbxBeefNoodleSoup_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Beef_Noodle_Salad));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnGreenSalad_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Green_Salad_Lunch));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Lamb_Korma));
        }

        private void btnOpenChickenSandwitch_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Open_Chicken_Sandwitch));
        }

        private void btnBeefNoodleSoup_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Beef_Noodle_Salad));
        }
    }
}
