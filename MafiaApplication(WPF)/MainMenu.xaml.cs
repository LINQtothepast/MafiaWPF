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

namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private string sessionUser;

        public MainMenu(string passedUserLogin)
        {
            UserCollection.AssignRoles();
            UserCollection.ChangeRoleName();
            InitializeComponent();
            sessionUser = passedUserLogin;

            List<User> ListOfPlayers = new List<User>();
            ListOfPlayers = UserCollection.ReturnPlayerList();

            this.PlayerListBox.ItemsSource = ListOfPlayers;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GameWindow main = new GameWindow(sessionUser);
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        
    }
}
