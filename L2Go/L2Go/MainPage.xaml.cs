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
using SQLite.Net;
using Windows.Storage;
using L2Go.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //databasew conection
        SQLiteConnection conn;
        //points to where the database is
        private string path;



        public MainPage()

        {
            this.InitializeComponent();
            DBConnection();
        }

        private void tbxEmailTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Regestration_Page));
        }

        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string loginEmail = tbxEmailInput.Text;
            string loginPassword = tbxPasswordinput.Text;

            List<Customer> CustomerDetails = conn.Query<Customer>("select * from Customer where EmailAddress = ? and Password = ?", loginEmail, loginPassword);

            if (CustomerDetails.Count == 0)
            {
                //show dialog to tell them to put in correct details
            }
            else
            {
                try
                {
                    /* create currentcustomer table
                     * delete currentcustomer table
                     * create currentcustomer table
                    */
                    conn.CreateTable<CurrentCustomer>();
                    conn.DeleteAll<CurrentCustomer>();
                    conn.CreateTable<CurrentCustomer>();
                } catch {    }

                /*
                 * create current customer variable
                 * put id of first item that is in the customer details list into the current customers id property
                 * insert current customer into the database
                 */


            }
            this.Frame.Navigate(typeof(page_2));
        }
        private string checkInput()
        {
            string result = "valid";
            if (string.IsNullOrWhiteSpace(tbxEmailInput.Text))
                return "Please insert correct email address";


            if (string.IsNullOrWhiteSpace(tbxPasswordinput.Text))
                return "Please insert correct password";

            return result;

        }

        private async void DBConnection()
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            StorageFolder sf = ApplicationData.Current.LocalFolder;
            StorageFile nf = await sf.CreateFileAsync("db.sqlite", CreationCollisionOption.OpenIfExists);
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Customer>();
            conn.CreateTable<Meals>();


        }

    }
}
