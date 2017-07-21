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

namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for NightWindow.xaml
    /// </summary>
    public partial class NightWindow : Window
    {
        private string SessionUser;
        private User tempPlayer;
        private User targetUser;
        private DispatcherTimer gameTimer;
        private List<User> PlayersList = new List<User>();
        private TimeSpan timeAmount;
        private static int night = 0;
        private string result = "";

        public NightWindow(string passedUser, User passedPlayer)
        {
            InitializeComponent();
            tempPlayer = passedPlayer;
            SessionUser = passedUser;
            PlayersList = UserCollection.ReturnUserList();
            timeAmount = TimeSpan.FromSeconds(15);
            RoleLabel.Content = passedPlayer.UserRoleName;
            night += 1;
            NightCount.Content = night.ToString();

            gameTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = timeAmount.ToString("c");

                //enable roles at the very start
                if (timeAmount == TimeSpan.FromSeconds(15))
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
                    if (tempPlayer.UserRole == 13)
                    {
                        //veteran activates
                        if (tempPlayer.UserRoleActive == true)
                        {
                            Veteran.VetNightTime(tempPlayer);
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(8))
                {
                    //bard role goes
                    if (tempPlayer.UserRole == 11)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            Bard.BardNightTime(targetUser, tempPlayer);
                        }
                    }
                }

                if (timeAmount == TimeSpan.FromSeconds(5))
                {
                    //jailor
                    if (tempPlayer.UserRole == 4)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                Jailor.JailorNightTime(targetUser, tempPlayer);
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
                    //conartist
                    if (tempPlayer.UserRole == 7)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                ConArtist.ConNightTime(targetUser, tempPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //doctor
                    else if (tempPlayer.UserRole == 2)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                Doctor.DocNightTime(targetUser, tempPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //godfather
                    else if (tempPlayer.UserRole == 6)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                Godfather.GodFatherNightTime(targetUser, tempPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //townpsycho
                    else if (tempPlayer.UserRole == 12)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                TownPsycho.TownPsychoNightTime(targetUser, tempPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //vigilante
                    else if (tempPlayer.UserRole == 14)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                Vigilante.VigNightTime(targetUser, tempPlayer);
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
                    if (tempPlayer.UserRole == 1)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                result = Sheriff.SheriffNightTime(targetUser, tempPlayer);
                            }
                            else
                            {
                                result = "You were role blocked";
                            }
                        }
                    }
                    //investigator
                    else if (tempPlayer.UserRole == 3)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                result = Investigator.InvNightTime(targetUser, tempPlayer);
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
                    if (tempPlayer.UserRole == 15)
                    {
                        if (tempPlayer.UserRoleActive == true)
                        {
                            if (tempPlayer.UserBlocked == false)
                            {
                                result = TownWatch.TownWatchNightTime(targetUser, tempPlayer);
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
                    foreach (var element in PlayersList)
                    {
                        if (element.UserSaved != true)
                        {
                            if (element.UserKilled == true)
                            {
                                element.UserStatus = true;
                            }
                        }
                    }
                    GameWindow main = new GameWindow(SessionUser, result);
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
            tempPlayer.UserRoleActive = true;

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
