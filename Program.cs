using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbproject
{
    public struct UserInfo
    {
        public int userid;
        public int bookingid;
        public int inqid;
        public string fisrtName;
        public string lastName;
        public string email;
        public string password;
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static UserInfo CurrentUser;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CurrentUser = new UserInfo { userid = 0, bookingid = 0, inqid = 0, fisrtName = "", lastName = "", email = "", password = "" };
            Application.Run(new Login());
        }
    }
}
