using GetKeyMakeCloneFacebookApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetKeyMakeCloneFacebookApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Helpers.LisenceHelper lisenceHelper = new Helpers.LisenceHelper();
            //var result = lisenceHelper.AddKey(new Models.Key() {
            //    Id = Guid.NewGuid(),
            //    Count = 1,
            //    IsActive = 1,
            //    IsActiveForever = 0,
            //    LisenceKey = "12345-12345-12346",
            //    MonthCount = 3
            //});

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
