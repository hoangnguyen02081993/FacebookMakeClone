using MakeCloneFacebookApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MakeCloneFacebookApp
{
    static class Program
    {
        private const string URL_LISENSE = "http://decorbiz.vn";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.frm_main());
        }
    }
}
