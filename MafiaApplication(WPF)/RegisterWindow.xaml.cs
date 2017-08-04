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
        private SqlConnection connect;
        private User sessionPlayer;

        public RegisterWindow()
        {
            InitializeComponent();
            UserCollection.fillListFromDB();
        }

        //checks if username is already in use
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            bool validCredentials = false;
            string enteredUsername;
            string enteredEmail;
            int nextID = 0;
            enteredUsername = Username_Textbox.Text;
            enteredEmail = Email_Textbox.Text;

            List<User> ListOfPlayers = UserCollection.ReturnUserList();

            ListOfPlayers = UserCollection.ReturnUserList();

            foreach (User element in ListOfPlayers)
            {
                if (element.UserID > nextID)
                {
                    nextID = element.UserID;
                }
            }

            validCredentials = UserCollection.checkCredentials(enteredUsername);

            if (validCredentials == true)
            {
                MessageBox.Show("Username already used. Please Retry");
            }
            else
            {
                sessionPlayer = UserCollection.addRegisteredUser(1, enteredEmail, enteredUsername);
                string connetionString = null;
                connetionString = ("user id=Derek;" +
                                    "server=localhost;" +
                                    "Trusted_Connection=yes;" +
                                    "database=Test");

                using (connect = new SqlConnection(connetionString))
                {
                    connect.Open();
                    string command = "INSERT INTO UserTable"
                    + " (Email, Name, ID) " +
                     "VALUES (@Email, @Name, @ID)";
                    SqlCommand insertCommand = new SqlCommand(command, connect);
                    insertCommand.Parameters.AddWithValue("@Email", enteredEmail);
                    insertCommand.Parameters.AddWithValue("@Name", enteredUsername);
                    insertCommand.Parameters.AddWithValue("@ID", (nextID + 1));
                    insertCommand.ExecuteNonQuery();
                    connect.Close();
                }

                MainMenu main = new MainMenu(sessionPlayer);
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
