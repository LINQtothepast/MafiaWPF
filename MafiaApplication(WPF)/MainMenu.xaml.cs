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
using System.Windows.Threading;
using System.Diagnostics;


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
        private DispatcherTimer gameTimer;
        private int timeConversion;
        private int minuteTracker;
        private int lowestID = 10000;


        public MainMenu(User passedPlayer)
        {
            InitializeComponent();
            sessionPlayer = passedPlayer;
            SqlConnection connect;
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            //set listing of current players
            ListOfPlayers = UserCollection.ReturnUserList();

            foreach (var element in ListOfPlayers)
            {
                if (lowestID > element.UserID)
                {
                    lowestID = element.UserID;
                }
            }

            if (sessionPlayer.UserID == lowestID)
            {
                UserCollection.AssignRoles();
                UserCollection.ChangeRoleName();
                foreach (var element in ListOfPlayers)
                {
                    using (connect = new SqlConnection(connetionString))
                    {
                        connect.Open();
                        using (SqlCommand cmd =
                                            new SqlCommand("UPDATE UserStatus SET Role=@Role, RoleName=@RoleName" +
                                            " WHERE Id=@Id", connect))
                        {
                            cmd.Parameters.AddWithValue("@Id", element.UserID);
                            cmd.Parameters.AddWithValue("@Role", element.UserRole);
                            cmd.Parameters.AddWithValue("@RoleName", element.UserRoleName);

                            int rows = cmd.ExecuteNonQuery();
                        }
                        connect.Close();
                    }
                }
            }

            var tempList =
                from player in ListOfPlayers
                orderby player.UserName
                select new
                {
                    Name = player.UserName,
                    Email = player.UserEmail,
                    ID = player.UserID,
                    //RoleName = player.UserRoleName
                };

            gameTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Clock.Content = DateTime.Now.ToString("H:mm:ss");
                timeConversion = Convert.ToInt32(DateTime.Now.ToString("ss"));
                if (timeConversion == 0)
                {
                    minuteTracker += 1;
                }
                test.Content = minuteTracker.ToString();
                
                if (minuteTracker > 1)
                {
                    if (timeConversion == 0)
                    {     
                        gameTimer.Stop();
                        GameWindow main = new GameWindow(sessionPlayer, result);
                        App.Current.MainWindow = main;
                        this.Close();
                        main.Show();
                    }
                }
                

            }, Application.Current.Dispatcher);

            this.PlayerListBox.ItemsSource = tempList;
        }
    }
}
