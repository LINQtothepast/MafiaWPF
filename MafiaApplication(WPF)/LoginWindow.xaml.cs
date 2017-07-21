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
        private List<User> CheckForUser = new List<User>();
        private string sessionUser;
        private string enteredUsername;
        private SqlConnection connect;
        private string tempName;
        private string tempEmail;

        public LoginWindow()
        {
            InitializeComponent();
            //connect to database
            string connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Mafia");

            using (connect = new SqlConnection(connetionString))
            {
                connect.Open();
                string readString = "select * from Users";
                SqlCommand readCommand = new SqlCommand(readString, connect);

                using (SqlDataReader dataRead = readCommand.ExecuteReader())
                {
                    if (dataRead != null)
                    {
                        while (dataRead.Read())
                        {
                            tempEmail = dataRead["Email"].ToString();
                            tempName = dataRead["Name"].ToString();
                            UserCollection.addUser(tempEmail, tempName);
                        }
                    }
                }
                connect.Close();
            }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            enteredUsername = Username_Textbox.Text;
            CheckForUser = UserCollection.ReturnUserList();

            var tempList =
                from player in CheckForUser
                where player.UserName == enteredUsername
                select player;

            if (tempList != null)
            {
                foreach (var element in tempList)
                {
                    UserCollection.addPlayer(element);
                }
                sessionUser = enteredUsername;
                MainMenu main = new MainMenu(sessionUser);
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
