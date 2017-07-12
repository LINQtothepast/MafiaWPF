using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaApplication_WPF_
{
    class Doctor
    {
        public static string DoctorName;

        public static string DoctorRole(string name)
        {
            DoctorName = name;
            return "Doctor";
        }

        public static void SwitchTo()
        {
            while (Game.GameOngoing == true)
            {
                Console.WriteLine("Doctor");
                Game.GameOngoing = false;

            }
        }
    }
}
