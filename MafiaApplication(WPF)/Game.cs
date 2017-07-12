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
    public class Game
    {
        private static List<User> GameUsersList = new List<User>();
        public static bool GameOngoing = true;

        public static void SetUsersForGame()
        {
            GameUsersList = UserCollection.ReturnPlayerList();
        }

        public static void CheckWhoIsDead()
        {
            List<User> CheckIfDeadList = new List<User>();
            CheckIfDeadList = UserCollection.ReturnPlayerList();

            foreach (var element in CheckIfDeadList)
            {
                if (element.UserStatus == "dead")
                {
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

        public static string GameStart(string currentUser)
        {
            MessageBox.Show(currentUser);
            string rolename;
            rolename = Sheriff.SheriffRole(currentUser);

            //not currently working
            foreach (var element in GameUsersList)
            {
                if (element.UserName == currentUser)
                {
                    switch (element.UserRole)
                    {
                        case 1:
                            rolename = Sheriff.SheriffRole(element.UserName);
                            break;
                        case 2:
                            rolename = Doctor.DoctorRole(element.UserName);
                            break;
                        case 3:
                            rolename = Investigator.InvestigatorRole(element.UserName);
                            break;
                        case 4:
                            rolename = Jailor.JailorRole(element.UserName);
                            break;
                        case 5:
                            rolename = Medium.MediumRole(element.UserName);
                            break;
                        case 6:
                            rolename = Godfather.GodfatherRole(element.UserName);
                            break;
                        case 7:
                            rolename = ConArtist.ConArtistRole(element.UserName);
                            break;
                        case 8:
                            rolename = Consigliere.ConsigliereRole(element.UserName);
                            break;
                        case 9:
                            rolename = RabbleRouser.RabbleRouserRole(element.UserName);
                            break;
                        case 10:
                            rolename = VillageIdiot.VillageIdiotRole(element.UserName);
                            break;
                        case 11:
                            rolename = Bard.BardRole(element.UserName);
                            break;
                        case 12:
                            rolename = TownPsycho.TownPsychoRole(element.UserName);
                            break;
                        case 13:
                            rolename = Veteran.VeteranRole(element.UserName);
                            break;
                        case 14:
                            rolename = Vigilante.VigilanteRole(element.UserName);
                            break;
                        case 15:
                            rolename = TownWatch.TownWatchRole(element.UserName);
                            break;
                    }
                }
            }
            return rolename;
        }
    }
}
