using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
    /// Interaction logic for NightWindow.xaml
    /// </summary>
    public partial class NightWindow : Window
    {
        private User sessionPlayer;
        private User targetUser;
        private DispatcherTimer gameTimer;
        private List<User> PlayersList = new List<User>();
        private TimeSpan timeAmount;
        private static int night = 0;
        private string result = "";
        private int lowestID = 10000;
        private bool isBlocked = false;
        private bool isSaved = false;
        private bool isKilled = false;

        public NightWindow(User passedPlayer)
        {
            InitializeComponent();

            sessionPlayer = passedPlayer;
            PlayersList = UserCollection.ReturnUserList();
            timeAmount = TimeSpan.FromSeconds(60);
            RoleLabel.Content = passedPlayer.UserRoleName;
            night += 1;
            NightCount.Content = night.ToString();
            Username.Content = sessionPlayer.UserName;
            SqlConnection connect;
            string connetionString = null;
            connetionString = ("user id=Derek;" +
                                "server=localhost;" +
                                "Trusted_Connection=yes;" +
                                "database=Test");

            gameTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = timeAmount.ToString("c");

                //enable roles at the very start
                if (timeAmount == TimeSpan.FromSeconds(60))
                {
                    Player1Button.Content = PlayersList[0].UserName;
                    Player2Button.Content = PlayersList[1].UserName;
                    Player3Button.Content = PlayersList[2].UserName;
                    Player4Button.Content = PlayersList[3].UserName;
                    Player5Button.Content = PlayersList[4].UserName;
                    Player6Button.Content = PlayersList[5].UserName;
                    Player7Button.Content = PlayersList[6].UserName;
                    Player8Button.Content = PlayersList[7].UserName;
                    Player9Button.Content = PlayersList[8].UserName;
                    Player10Button.Content = PlayersList[9].UserName;
                    Player11Button.Content = PlayersList[10].UserName;
                    Player12Button.Content = PlayersList[11].UserName;
                    Player13Button.Content = PlayersList[12].UserName;
                    Player14Button.Content = PlayersList[13].UserName;
                    Player15Button.Content = PlayersList[14].UserName;

                    if (PlayersList[0].UserStatus == false) Player1Button.IsEnabled = true;
                    if (PlayersList[1].UserStatus == false) Player2Button.IsEnabled = true;
                    if (PlayersList[2].UserStatus == false) Player3Button.IsEnabled = true;
                    if (PlayersList[3].UserStatus == false) Player4Button.IsEnabled = true;
                    if (PlayersList[4].UserStatus == false) Player5Button.IsEnabled = true;
                    if (PlayersList[5].UserStatus == false) Player6Button.IsEnabled = true;
                    if (PlayersList[6].UserStatus == false) Player7Button.IsEnabled = true;
                    if (PlayersList[7].UserStatus == false) Player8Button.IsEnabled = true;
                    if (PlayersList[8].UserStatus == false) Player9Button.IsEnabled = true;
                    if (PlayersList[9].UserStatus == false) Player10Button.IsEnabled = true;
                    if (PlayersList[10].UserStatus == false) Player11Button.IsEnabled = true;
                    if (PlayersList[11].UserStatus == false) Player12Button.IsEnabled = true;
                    if (PlayersList[12].UserStatus == false) Player13Button.IsEnabled = true;
                    if (PlayersList[13].UserStatus == false) Player14Button.IsEnabled = true;
                    if (PlayersList[14].UserStatus == false) Player15Button.IsEnabled = true;
                }

                if (timeAmount == TimeSpan.FromSeconds(10))
                {
                    Player1Button.IsEnabled = false;
                    Player2Button.IsEnabled = false;
                    Player3Button.IsEnabled = false;
                    Player4Button.IsEnabled = false;
                    Player5Button.IsEnabled = false;
                    Player6Button.IsEnabled = false;
                    Player7Button.IsEnabled = false;
                    Player8Button.IsEnabled = false;
                    Player9Button.IsEnabled = false;
                    Player10Button.IsEnabled = false;
                    Player11Button.IsEnabled = false;
                    Player12Button.IsEnabled = false;
                    Player13Button.IsEnabled = false;
                    Player14Button.IsEnabled = false;
                    Player15Button.IsEnabled = false;
                    if (sessionPlayer.UserRole == 13)
                    {
                        //veteran activates
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            Veteran.VetNightTime(sessionPlayer);
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(8))
                {
                    //bard role goes
                    if (sessionPlayer.UserRole == 11)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            Bard.BardNightTime(targetUser, sessionPlayer);
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(5))
                {
                    using (connect = new SqlConnection(connetionString))
                    {
                        connect.Open();

                        //read if the passed User is Armed and get their VisitedBy
                        SqlCommand command = new SqlCommand("Select Blocked FROM [UserStatus] WHERE ID=@ID", connect);
                        command.Parameters.AddWithValue("@ID", sessionPlayer.UserID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isBlocked = Convert.ToBoolean(reader["Blocked"]);
                            }
                        }
                        connect.Close();
                    }
                        //jailor
                    if (sessionPlayer.UserRole == 4)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                Jailor.JailorNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(6))
                {
                    using (connect = new SqlConnection(connetionString))
                    {
                        connect.Open();

                        //read if the passed User is Armed and get their VisitedBy
                        SqlCommand command = new SqlCommand("Select Blocked FROM [UserStatus] WHERE ID=@ID", connect);
                        command.Parameters.AddWithValue("@ID", sessionPlayer.UserID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isBlocked = Convert.ToBoolean(reader["Blocked"]);
                            }
                        }
                        connect.Close();
                    }
                    //conartist
                    if (sessionPlayer.UserRole == 7)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                ConArtist.ConNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //doctor
                    else if (sessionPlayer.UserRole == 2)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                Doctor.DocNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //godfather
                    else if (sessionPlayer.UserRole == 6)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                Godfather.GodFatherNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //townpsycho
                    else if (sessionPlayer.UserRole == 12)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                TownPsycho.TownPsychoNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //vigilante
                    else if (sessionPlayer.UserRole == 14)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                Vigilante.VigNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(4))
                {
                    //sheriff
                    if (sessionPlayer.UserRole == 1)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                result = Sheriff.SheriffNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //investigator
                    else if (sessionPlayer.UserRole == 3)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                result = Investigator.InvNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(2))
                {
                    //town watch
                    if (sessionPlayer.UserRole == 15)
                    {
                        if (sessionPlayer.UserRoleActive == true)
                        {
                            if (isBlocked == false)
                            {
                                result = TownWatch.TownWatchNightTime(targetUser, sessionPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                       
                    }
                }

                if (timeAmount == TimeSpan.Zero)
                {
                    gameTimer.Stop();
                    //find lowest ID number so table is only accessed and updated by that ID
                    foreach (var element in PlayersList)
                    {
                        if (lowestID > element.UserID)
                        {
                            lowestID = element.UserID;
                        }
                    }
                    if (sessionPlayer.UserID == lowestID)
                    {
                        foreach (var element in PlayersList)
                        {
                            isKilled = false;
                            isSaved = false;
                            using (connect = new SqlConnection(connetionString))
                            {
                                connect.Open();

                                //read if the passed User is Armed and get their VisitedBy
                                SqlCommand command = new SqlCommand("Select Killed, Saved FROM [UserStatus] WHERE ID=@ID", connect);
                                command.Parameters.AddWithValue("@ID", element.UserID);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        isKilled = Convert.ToBoolean(reader["Killed"]);
                                        isSaved = Convert.ToBoolean(reader["Saved"]);
                                    }
                                }


                                if (isSaved == false)
                                {
                                    if (isKilled == true)
                                    {
                                        //element.UserStatus = true;
                                        using (SqlCommand cmd =
                                            new SqlCommand("UPDATE UserStatus SET Status=@Status" +
                                            " WHERE Id=@Id", connect))
                                        {
                                            cmd.Parameters.AddWithValue("@Id", element.UserID);
                                            cmd.Parameters.AddWithValue("@Status", 1);

                                            int rows = cmd.ExecuteNonQuery();
                                        }
                                    }
                                }

                                using (SqlCommand cmd =
                                    new SqlCommand("UPDATE UserStatus SET " +
                                    "Blocked=@Blocked, Conned=@Conned, Saved=@Saved, Killed=@Killed, " +
                                    "Armed=@Armed, VisitedBy=@VisitedBy" +
                                    " WHERE Id=@Id", connect))
                                {
                                    cmd.Parameters.AddWithValue("@Id", element.UserID);
                                    cmd.Parameters.AddWithValue("@Blocked", 0);
                                    cmd.Parameters.AddWithValue("@Conned", 0);
                                    cmd.Parameters.AddWithValue("@Saved", 0);
                                    cmd.Parameters.AddWithValue("@Killed", 0);
                                    cmd.Parameters.AddWithValue("@Armed", 0);
                                    cmd.Parameters.AddWithValue("@VisitedBy", "");

                                    int rows = cmd.ExecuteNonQuery();
                                    connect.Close();
                                }
                            }
                        }
                    }
                    GameWindow main = new GameWindow(sessionPlayer, result);
                    App.Current.MainWindow = main;
                    this.Close();
                    main.Show();
                }


                timeAmount = timeAmount.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

        }

        //figure out the role of session user and then do an action based on it
        private void PlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Button B = sender as Button;
            targetUser = PlayersList[0];
            sessionPlayer.UserRoleActive = true;

            foreach (var element in PlayersList)
            {
                if (B.Content.ToString() == element.UserName)
                {
                    targetUser = element;
                }
            }
        }
    }
}
