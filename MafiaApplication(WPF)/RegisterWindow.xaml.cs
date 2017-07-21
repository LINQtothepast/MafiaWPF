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
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private string sessionUser;
        private SqlConnection connect;

        public RegisterWindow()
        {
            InitializeComponent();        
        }

        //checks if username is already in use
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            bool validCredentials = false;
            string enteredUsername;
            string enteredEmail;
            enteredUsername = Username_Textbox.Text;
            enteredEmail = Email_Textbox.Text;
            validCredentials = UserCollection.checkCredentials(enteredUsername);

            if (validCredentials == true)
            {
                MessageBox.Show("Username already used. Please Retry");
            }
            else
            {
                UserCollection.addUser(enteredEmail, enteredUsername);
                sessionUser = enteredUsername;
                string connetionString = null;
                connetionString = ("user id=Derek;" +
                                    "server=localhost;" +
                                    "Trusted_Connection=yes;" +
                                    "database=Mafia");

                using (connect = new SqlConnection(connetionString))
                {
                    connect.Open();
                    string command = "INSERT INTO Users"
                    + " (Email, Name, Role, RoleName, Status, Blocked, Conned, " +
                    "Saved, Killed, Armed, VisitedBy, Win, LynchNominationVotes, LynchVotes) " +
                     "VALUES (@Email, @Name, 0, 'Unset', 0, 0, 0, 0, 0, 0, '', 0, 0, 0)";
                    SqlCommand insertCommand = new SqlCommand(command, connect);
                    insertCommand.Parameters.AddWithValue("@Email", enteredEmail);
                    insertCommand.Parameters.AddWithValue("@Name", enteredUsername);
                    insertCommand.ExecuteNonQuery();
                    connect.Close();
                }
                    
                
                MainMenu main = new MainMenu(sessionUser);
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }

        //clears textbox on click
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
