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
using SQLite.Net;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Open_Chicken_Sandwitch : Page
    {
        public Open_Chicken_Sandwitch()
        {
            this.InitializeComponent();
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
            m.Meal = "Open chicken sandwitch";
            if (radRye.IsChecked == true)

            {
                m.Flavour = "Rye";
                // retrive current customer id and put itno the meal object 
                // "note; select all from current customer table then get id from the first item in the list.
                //insert into db

                List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
                CurrentCustomer c = cl.First();
                m.ID = c.ID;
                conn.Insert(m);

                this.Frame.Navigate(typeof(Delivery_time));
            }

            else if (radWhite.IsChecked == true)
            {
                m.Flavour = "White";
                List<CurrentCustomer> cl = conn.Query<CurrentCustomer>("select * from CurrentCustomer");
                CurrentCustomer c = cl.First();
                m.ID = c.ID;
                conn.Insert(m);
                this.Frame.Navigate(typeof(Delivery_time));
            }

            else if (radWholemeal.IsChecked == true)
            {
                m.Flavour = "Wholemeal";
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
