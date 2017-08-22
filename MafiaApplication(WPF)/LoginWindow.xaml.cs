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
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string enteredUsername;
        private User sessionPlayer;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            UserCollection.fillListFromDB();
            enteredUsername = Username_Textbox.Text;
            sessionPlayer = UserCollection.ReturnAUser(enteredUsername);
            
            if (sessionPlayer.UserName == enteredUsername)
            {
                
                MainMenu main = new MainMenu(sessionPlayer);
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
            else
            {
                RegisterWindow main = new RegisterWindow();
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
