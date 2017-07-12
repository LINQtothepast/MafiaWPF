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

namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string sessionUser;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool validCredentials = false;
            string enteredUsername;
            enteredUsername = Username_Textbox.Text;
            validCredentials = UserCollection.checkCredentials(enteredUsername);

            if (validCredentials == false)
            {
                MessageBox.Show("Invalid Input. Please Retry");
            }
            else
            {
                sessionUser = enteredUsername;
                MainMenu main = new MainMenu(sessionUser);
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow main = new RegisterWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
