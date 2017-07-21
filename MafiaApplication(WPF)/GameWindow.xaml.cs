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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private string sessionUser;
        private DispatcherTimer gameTimer;
        private TimeSpan timeAmount;
        private TimeSpan sixtySeconds;
        private TimeSpan fifteenSeconds;
        private User tempPlayer;
        private List<User> PlayersList = new List<User>();
        private int deadCount;
        private User maxVotes;
        private static int day = 0;
        private string nightResults;

        //handles daytime
        public GameWindow(string passedUser, string passedResult)
        {
            InitializeComponent();
            nightResults = passedResult;
            sessionUser = passedUser;
            deadCount = 0;
            day += 1;
            CurrentVotes.Text = "";
            PlayersList = UserCollection.ReturnUserList();

            //tempPlayer = UserCollection.ReturnAUser(sessionUser);
            foreach (var element in PlayersList)
            {
                if (element.UserName == sessionUser)
                {
                    tempPlayer = element;
                }
            }
            UserNameContent.Content = sessionUser;

            //set current day
            DayContent.Content = day.ToString();
            

            //check who is dead at start of round
            CheckWhoIsDead();

            //set button names for lynching
            SetPlayerNamesToButtons();

            //set description of role for current player
            SetRoleDetails();

            //find role of current user's player
            RoleLabel.Content = tempPlayer.UserRoleName;

            //set a timer that counts down and at the end of the timer switches to new page
            timeAmount = TimeSpan.FromSeconds(15);
            sixtySeconds = TimeSpan.FromSeconds(10);
            fifteenSeconds = TimeSpan.FromSeconds(5);
            maxVotes = PlayersList[0];
            
            gameTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = timeAmount.ToString("c");

                //enable lynching at 60 seconds remaining
                if (timeAmount == sixtySeconds)
                {
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

                //set votes textbox content
                if (timeAmount > fifteenSeconds)
                {
                    CurrentVotes.Text = "";
                    foreach (var element in PlayersList)
                    {
                        if (element.UserLynchNominationVotes >= 1)
                        {
                            CurrentVotes.Text += element.UserName;
                            CurrentVotes.Text += " ";
                            CurrentVotes.Text += element.UserLynchNominationVotes;
                            CurrentVotes.Text += "\n";
                        }
                        if (element.UserLynchNominationVotes > maxVotes.UserLynchNominationVotes)
                        {
                            maxVotes = element;
                        }
                    }
                }
                
               
                //disable lynching nomination at 15 seconds remaining
                //and check if anyone is up for vote
                if (timeAmount == fifteenSeconds)
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
                    foreach (var element in PlayersList)
                    {
                        if (maxVotes.UserLynchNominationVotes >= ((PlayersList.Count - deadCount) / 2))
                        {
                            YesButton.IsEnabled = true;
                            NoButton.IsEnabled = true;
                        }
                    }
                }

                //each second after 15 seconds keep current Lynch Vote Displayed
                if (timeAmount < fifteenSeconds)
                {
                    CurrentVotes.Text = maxVotes.UserName + " " + maxVotes.UserLynchVotes.ToString();
                }


                //at zero time switch windows
                if (timeAmount == TimeSpan.Zero)
                {
                    //kill lynched player if we have enough votes
                    gameTimer.Stop();
                    if (maxVotes.UserLynchVotes >= ((PlayersList.Count - deadCount) / 2))
                    {
                        maxVotes.UserStatus = true;
                    }
                    foreach (var element in PlayersList)
                    {
                        element.UserHasNomVoted = false;
                        element.UserHasVoted = false;
                        element.UserLynchNominationVotes = 0;
                        element.UserLynchVotes = 0;
                    }
                    NightWindow main = new NightWindow(sessionUser, tempPlayer);
                    App.Current.MainWindow = main;
                    this.Close();
                    main.Show();
                }

                timeAmount = timeAmount.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            gameTimer.Start();
        }

        //set player buttons for voting to a player name
        private void SetPlayerNamesToButtons()
        {
            PlayersList = UserCollection.RandomizeList(PlayersList);

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
        }


        //set description of role and win condition based on session user role
        private void SetRoleDetails()
        {
            switch (tempPlayer.UserRole)
            {
                case 1:
                    RoleDescription.Text = "Each night the Sheriff may check any other player's role at night. "
                        + "The investigation will come back as 'Mafia', 'Villager', 'Town Psycho', or 'Village Idiot'. "
                        + "The one exception to this being the Godfather who will always show up as a 'Town's Person'. ";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 2:
                    RoleDescription.Text = "Each night the Doctor may choose one person, including himself up to two times," 
                        + " to heal. No matter who attacks, the target will be healed and survive the night";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 3:
                    RoleDescription.Text = "Each night the Investigator may choose one person and investigate them. "
                        + "The investigation will come back with three choices for each person. One will be true and the "
                        + "other two will be false. Example the Godfather, Jailor, and Village Idiot Roles will show up as "
                        + "'Godfather' or 'Jailor' or 'Veteran'.";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 4:
                    RoleDescription.Text = "Each night the Jailor may choose one person and place them in the jail that night. "
                        + "This person may not perform their role that night and can not be killed. The jailor may choose to "
                        + "kill the person in his cell at any time. Your action does not count as visiting someone but instead as "
                        + "someone visiting you.";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 5:
                    RoleDescription.Text = "At night the Medium may talk to the dead ";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 6:
                    RoleDescription.Text = "Each night the Godfather picks one person to kill. Also a unique property of your role " +
                        "is if you are investigated by the sheriff you show up as a Villager";
                    WinCondition.Text = "Kill everyone but members of the Mafia.";
                    break;
                case 7:
                    RoleDescription.Text = "Each night the Con Artist picks one person to make look like a member of the mafia. "
                        + "This means that both the sheriff and the investigator see your target's role choices as mafia.";
                    WinCondition.Text = "Kill everyone but members of the Mafia.";
                    break;
                case 8:
                    RoleDescription.Text = "You are the back up Godfather. When the original Godfather dies you assume his role. "
                        + "You do nothing while being the Consigliere but it is suggested that you work your hardest during the day "
                        + "to further the cause for your bretheren.";
                    WinCondition.Text = "Kill everyone but members of the Mafia.";
                    break;
                case 9:
                    RoleDescription.Text = "Your job as the Rabble-Rouser is to get your target lynched because lyinching people "
                        + "sounds fun. If your target dies at night then in the morning you will receive a new target.";
                    WinCondition.Text = "Get your target lynched. No need to survive.";
                    break;
                case 10:
                    RoleDescription.Text = "Your job is to get lynched by the mob for you are indeed the Village Idiot and it sounds fun. "
                        + "If you die during the night then it counts as a loss. Feel free to lie, slander, and antagonize "
                        + "in order to get killed. Anything goes. ";
                    WinCondition.Text = "Get lynched. No need to survive.";
                    break;
                case 11:
                    RoleDescription.Text = "Each night the Bard may play his tunes for one person. This person decides to stay in "
                        +"for the night and do nothing else.";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 12:
                    RoleDescription.Text = "You are the murdurous villain worse than the mafia, you are the Town Psycho. Everyone wants "
                        + "you dead. And you want everyone else dead. Each night you may kill one person.";
                    WinCondition.Text = "Kill everyone that isn't you.";
                    break;
                case 13:
                    RoleDescription.Text = "Each night for up to a total of four nights the Veteran may sit at your door with a shotgun. "
                        + "Be warned everyone who comes knocking, good or evil, will die. Only the bard is immune as he greets "
                        + "with a song before knocking and makes you drop your guard for the night.";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 14:
                    RoleDescription.Text = "Each night the Vigilante may choose to shoot and kill one person. Hitting the Village Idiot, "
                        + "Town Psycho, or any member of the Mafia is good. Hit anyone else and you die that night as well.";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
                case 15:
                    RoleDescription.Text = "Each night the Town Watch may choose to watch one person. Anyone who comes to visit will be "
                        + "reported back to you in the daytime";
                    WinCondition.Text = "Kill the Mafia and the Town Psycho.";
                    break;
            }
        }

        //checks which roles are still alive
        //if the person is dead then their role gets marked off
        private void CheckWhoIsDead()
        {
            foreach (var element in PlayersList)
            {
                if (element.UserStatus == true)
                {
                    //deadcount used for lynch voting mechanic
                    deadCount += 1;
                    switch (element.UserRole)
                    {
                        case 1:
                            Player1.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 2:
                            Player2.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 3:
                            Player3.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 4:
                            Player4.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 5:
                            Player5.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 6:
                            Player6.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 7:
                            Player7.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 8:
                            Player8.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 9:
                            Player9.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 10:
                            Player10.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 11:
                            Player11.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 12:
                            Player12.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 13:
                            Player13.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 14:
                            Player14.TextDecorations = TextDecorations.Strikethrough;
                            break;
                        case 15:
                            Player15.TextDecorations = TextDecorations.Strikethrough;
                            break;
                    }
                }
            }
        }

        //get the vote to nominate someone for lynch from button click and properly assign it to that person
        private void PlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Button B = sender as Button;
            //if (tempPlayer.UserHasNomVoted == false)
            {
                foreach (var element in PlayersList)
                {
                    if (B.Content.ToString() == element.UserName)
                    {
                        element.UserLynchNominationVotes += 1;
                    }
                }
                tempPlayer.UserHasNomVoted = true;
            }
        }

        //get the yes or no vote and assign it to person up for lynching
        private void VoteButton_Click(object sender, RoutedEventArgs e)
        {
            Button B = sender as Button;
            //if (tempPlayer.UserHasVoted == false)
            {
                if (B.Content.ToString() == "Vote Yes")
                {
                    maxVotes.UserLynchVotes += 1;
                    //MessageBox.Show(maxVotes.UserLynchVotes.ToString());
                }
                if (B.Content.ToString() == "Vote No")
                {
                    maxVotes.UserLynchVotes -= 1;
                }
            }  
        }
    }
}
