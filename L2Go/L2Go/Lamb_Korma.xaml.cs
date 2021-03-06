﻿using System;
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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Lamb_Korma : Page
    {
        public Lamb_Korma()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(page_2));
        }

        SQLite.Net.SQLiteConnection conn;
        string path;

        private async void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            Meals m = new Meals();
            m.Meal = "Lamb korma";
            if (radHot.IsChecked == true)

            {
                m.Flavour = "Hot";

                List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
                CurrentCustomer c = cl.First();
                m.ID = c.ID;
                conn.Insert(m);

                this.Frame.Navigate(typeof(Delivery_time));
            }

            else if (radMedium.IsChecked == true)
            {
                m.Flavour = "Medium";

                List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
                CurrentCustomer c = cl.First();
                m.ID = c.ID;
                conn.Insert(m);

                this.Frame.Navigate(typeof(Delivery_time));
            }

            else if (radMild.IsChecked == true)
            {
                m.Flavour = "Mild";

                List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
                CurrentCustomer c = cl.First();
                m.ID = c.ID;
                conn.Insert(m);

                this.Frame.Navigate(typeof(Delivery_time));
            }

            else
            {
                var messageDialog = new MessageDialog("Please make a selection", "Lunch to go");
                messageDialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                await messageDialog.ShowAsync();
            }

            
        }
    }
}
