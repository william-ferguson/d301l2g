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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace L2Go
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Regestration_Page : Page
    {
        public Regestration_Page()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        //creates the database connection
        SQLiteConnection conn;
        //points to where the database is
        private string path;




        private async void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            string isValid = checkInput();
            if (isValid == "valid")
            {
                //taking the information provided by the customer during registration and stores it into a new variable called c
                Customer c = new Customer();
                c.Name = tbxNameInput.Text;
                c.Address = tbxAddressInput.Text;
                c.PhoneNumber = tbxPhoneNumberInput.Text;
                c.City = tbxCityInput.Text;
                c.EmailAddress = tbxEmailAddressInput.Text;
                c.CreditCardNumber = tbxCreditCardNumberInput.Text;
                c.CreditCardExpiryMonth = tbxCCExpiryMonthInput.Text;
                c.CreditCardExpiryYear = tbxCCExpiryYearInput.Text;
                c.CreditCardSecurityCode = tbxCCSecurityCodeInput.Text;
                c.Password = tbxPasswordInput.Text;

                //creating a new path to the sqlite database
                path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
                //making the connection to the sqlit database
                conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

                var s = conn.Insert(c);// inserts the customer info into the db table

                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var message = new Windows.UI.Popups.MessageDialog(isValid, "Error");
                message.Commands.Add(new Windows.UI.Popups.UICommand
                {
                    Label = "ok",
                    Id = 0
                });
                await message.ShowAsync();
            }

        }
        private string checkInput()
        {
            string result = "valid";
            if (string.IsNullOrWhiteSpace(tbxNameInput.Text))
                return "Please insert correct name";

            
            if (string.IsNullOrWhiteSpace(tbxAddressInput.Text))
                return "Please insert correct address";

            
            if (string.IsNullOrWhiteSpace(tbxPhoneNumberInput.Text))
                return "Please insert correct phone number";

            
            if (string.IsNullOrWhiteSpace(tbxCityInput.Text))
                return "Please insert correct city";

            
            if (string.IsNullOrWhiteSpace(tbxEmailAddressInput.Text))
                return "Please insert correct email address";

            if (string.IsNullOrWhiteSpace(tbxCreditCardNumberInput.Text))
                return "Please insert correct credit card number";

            if (string.IsNullOrWhiteSpace(tbxCCExpiryMonthInput.Text))
                return "Please insert correct expiry month";

            if (string.IsNullOrWhiteSpace(tbxCCExpiryYearInput.Text))
                return "Please insert correct expiry year";

            if (string.IsNullOrWhiteSpace(tbxCCSecurityCodeInput.Text))
                return "Please insert a security code";

            if (checkCreditCardInput(tbxCCSecurityCodeInput.Text).Length != 3) 
                return "Please insert the correct security code";

            if (checkCreditCardInput(tbxPhoneNumberInput.Text).Length < 7 || (checkCreditCardInput(tbxPhoneNumberInput.Text).Length > 15))
                return "Please insert the correct phone number";

            if (checkCreditCardInput(tbxCCExpiryMonthInput.Text).Length != 2)
                return "Please insert the correct expiry month";

            if (checkCreditCardInput(tbxCCExpiryYearInput.Text).Length != 2)
                return "Please insert the correct expiry year";


            return result;

        
        }

        private string checkCreditCardInput(string Input)
        {
            Input = Input.Trim();
            string checkCreditCardInput = "";

            foreach (char c in Input)
            {
                if (char.IsNumber(c))
                {
                    checkCreditCardInput += c;
                }
            }

            return checkCreditCardInput;
               
        }


    }
}
