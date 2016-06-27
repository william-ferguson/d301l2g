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
using L2Go.Models;
    

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Delivery_time : Page
    {
        string time;
        public Delivery_time()
        {
            this.InitializeComponent();
            cmbRegion.Items.Add("Manawatu");
            cmbRegion.Items.Add("Whanganui");
            cmbRegion.Items.Add("Wairarapa");
            cmbRegion.SelectedIndex = 0;
            time = "11.45am - 12.15pm";
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(page_2));
        }
        SQLite.Net.SQLiteConnection conn;
        string path;
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            order o = new order()
            {
                // OrderDate = ,
                OrderRegion = cmbRegion.SelectedItem.ToString()
            };

            conn.CreateTable<order>();

            List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
            CurrentCustomer c = cl.First();
            o.CustomerID = c.ID;
            conn.Insert(o);

            this.Frame.Navigate(typeof(order_confirm));
        }

        private void rad11_45_12_15_Checked(object sender, RoutedEventArgs e)
        {
            time = "11.45am - 12.15pm";
        }

        private void rad12_15_12_45_Checked(object sender, RoutedEventArgs e)
        {
            time = "12.15pm - 12.45pm";
        }

        private void rad12_45_1_15_Checked(object sender, RoutedEventArgs e)
        {
            time = "12.45am - 1.15pm";
        }

        private void rad1_15_1_45_Checked(object sender, RoutedEventArgs e)
        {
            time = "1.15am - 1.45pm";
        }
    }
}
