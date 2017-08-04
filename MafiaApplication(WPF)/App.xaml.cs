using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace MafiaApplication_WPF_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow wnd = new LoginWindow();

            /*
            UserCollection.addUser("a", "Derek");
            UserCollection.addUser("b", "Tara");
            UserCollection.addUser("c", "Rowan");
            UserCollection.addUser("d", "Elsie");
            UserCollection.addUser("e", "Mike");
            UserCollection.addUser("f", "Krista");
            UserCollection.addUser("g", "Tom");
            UserCollection.addUser("h", "Fran");
            UserCollection.addUser("i", "Austin");
            UserCollection.addUser("j", "Tanner");
            UserCollection.addUser("k", "Gracen");
            UserCollection.addUser("l", "Conner");
            UserCollection.addUser("m", "Cameron");
            UserCollection.addUser("n", "Lisa");
            UserCollection.addUser("o", "Jill");
            */

            wnd.Show();
        }
    }
}
