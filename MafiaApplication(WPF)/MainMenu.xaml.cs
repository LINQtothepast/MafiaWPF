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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private List<User> ListOfPlayers = new List<User>();
        private string result = "";
        private User sessionPlayer;

        public MainMenu(User passedPlayer)
        {
            UserCollection.AssignRoles();
            UserCollection.ChangeRoleName();
            InitializeComponent();
            sessionPlayer = passedPlayer;

            //set listing of current players
            ListOfPlayers = UserCollection.ReturnUserList();

            var tempList =
                from player in ListOfPlayers
                orderby player.UserName
                select new
                {
                    Name = player.UserName,
                    Email = player.UserEmail,
                    ID = player.UserID
                };

            this.PlayerListBox.ItemsSource = tempList;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GameWindow main = new GameWindow(sessionPlayer, result);
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }   
    }
}
