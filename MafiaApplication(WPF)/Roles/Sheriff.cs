using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace MafiaApplication_WPF_
{
    public class Sheriff
    {
        public static string SheriffName;

        public static string SheriffRole(string name)
        {
            SheriffName = name;
            return "Sheriff";
        }

       /*public static void SwitchTo()
        {
            while (Game.GameOngoing == true)C:\Users\Derek\Desktop\MafiaApplication(WPF)\MafiaApplication(WPF)\Roles\Sheriff.cs
            {
                Console.WriteLine("Sheriff");

                Timer GameTime = new Timer();
                GameTime.Interval = 60000;

                GameTime.Elapsed += OnTimedEvent;

                GameTime.AutoReset = true;

                GameTime.Enabled = true;

                Console.WriteLine("Press the Enter key to exit the program at any time... ");
                Console.ReadLine();

                Game.GameOngoing = false;
            }
        }

        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }
        */
    }
}
