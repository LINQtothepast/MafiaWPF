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
            GameUsersList = UserCollection.ReturnUserList();
        }

        /*
        public static string GameStart(string currentUser)
        {
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
        }*/
    }
}
