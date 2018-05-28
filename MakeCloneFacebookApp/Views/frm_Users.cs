using MakeCloneFacebookApp.Helpers;
using MakeCloneFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeCloneFacebookApp.Views
{
    public partial class frm_Users : Form
    {
        private JsonDBHelper dBHelper;
        public frm_Users(ref JsonDBHelper dBHelper)
        {
            InitializeComponent();
            this.dBHelper = dBHelper;
            this.Load += Frm_Users_Load;
        }

        private void Frm_Users_Load(object sender, EventArgs e)
        {
            foreach (var user in dBHelper.GetUsers())
            {
                gv_users.Rows.Add(user.UserName, user.Password);
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            foreach (DataGridViewRow row in gv_users.Rows)
            {
                User user = new User()
                {
                    UserName = row.Cells["username"].Value.ToString(),
                    Password = row.Cells["password"].Value.ToString()
                };
                if(string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                {

                }
                users.Add(user);
            }
            if(dBHelper.SaveUsers(users))
            {
                Until.ShowInfoBox("Saves users successfully");
            }
            else
            {
                Until.ShowErrorBox("Saves users failed");
            }
        }
    }
}
