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

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(page_2));
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
