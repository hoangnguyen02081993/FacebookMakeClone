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
    public partial class frm_UserAction : Form
    {
        public enum UserAction
        {
            Add,
            Edit
        }
        public UserAction Action { private set; get; }
        public User Result { private set; get; }
        public frm_UserAction(UserAction action, User user = null)
        {
            InitializeComponent();
            this.Action = action;
            this.Result = user;
            this.Load += Frm_UserAction_Load;
        }

        private void Frm_UserAction_Load(object sender, EventArgs e)
        {
            switch(Action)
            {
                case UserAction.Add:
                    BtnOk.Text = "Add";
                    break;
                case UserAction.Edit:
                    TbUserName.Enabled = false;
                    BtnOk.Text = "Edit";
                    TbUserName.Text = Result.UserName;
                    TbPassword.Text = Result.Password;
                    break;
                default:
                    break;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TbUserName.Text) || string.IsNullOrEmpty(TbPassword.Text))
            {
                Until.ShowErrorBox("UserName or Password must be not null or empty!");
            }
            Result = new User()
            {
                UserName = TbUserName.Text,
                Password = TbPassword.Text
            };
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
