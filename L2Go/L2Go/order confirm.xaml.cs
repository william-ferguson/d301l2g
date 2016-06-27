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
using SQLite.Net;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class order_confirm : Page
    {
        SQLite.Net.SQLiteConnection conn;
        string path;
        public order_confirm()
        {
            this.InitializeComponent();
            List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
            CurrentCustomer c = cl.First();
            tbxName.Text = "name";
            tbxOrder.Text = "order";
            tbxRegion.Text = "region";
            tbxTime.Text = "time";
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
