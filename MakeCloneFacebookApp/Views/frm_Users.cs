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
            gv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (var user in dBHelper.GetUsers())
            {
                gv_users.Rows.Add(user.UserName, user.Password);
            }
        }
        private void Gv_users_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gv_users.Columns[e.ColumnIndex].Index == 1 && e.Value != null)
            {
                gv_users.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
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
                if(row.Cells["username"].Value == null || row.Cells["password"].Value == null)
                {
                    continue;
                }
                User user = new User()
                {
                    UserName = row.Cells["username"].Value.ToString(),
                    Password = row.Cells["password"].Value.ToString()
                };
                if(!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                {
                    users.Add(user);
                }
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (frm_UserAction frm = new frm_UserAction(frm_UserAction.UserAction.Add))
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    //TODO
                    gv_users.Rows.Add(frm.Result.UserName, frm.Result.Password);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gv_users.SelectedRows.Count > 0)
            {
                using (frm_UserAction frm = new frm_UserAction(frm_UserAction.UserAction.Edit, new User()
                {
                    UserName = gv_users.SelectedRows[0].Cells["username"].Value.ToString(),
                    Password = gv_users.SelectedRows[0].Cells["password"].Value.ToString()
                }))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //TODO
                        gv_users.SelectedRows[0].Cells["username"].Value = frm.Result.UserName;
                        gv_users.SelectedRows[0].Cells["password"].Value = frm.Result.Password;
                    }
                }
            }
            else Until.ShowErrorBox("Please choose data first");
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (gv_users.SelectedRows.Count > 0)
            {
                gv_users.Rows.Remove(gv_users.SelectedRows[0]);
            }
            else Until.ShowErrorBox("Please choose data first");
        }
    }
}
