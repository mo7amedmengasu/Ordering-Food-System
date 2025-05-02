using Db_Project.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SignupForm());
            //Application.Run(new LoginForm());
            //Application.Run(new UserProfileForm());
            /*try
            {
                Application.Run(new AdminDashboard());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Startup error: " + ex.Message);
            }*/
            try
            {
<<<<<<< HEAD
                Application.Run(new MangeUserForm());
=======
                //Application.Run(new LoginForm());
>>>>>>> origin/renad2
                //Application.Run(new Form1());
                //Application.Run(new TrialForm());
                Application.Run(new ManageRestaurantsForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup error: " + ex.Message);
            }


        }
    }
}
