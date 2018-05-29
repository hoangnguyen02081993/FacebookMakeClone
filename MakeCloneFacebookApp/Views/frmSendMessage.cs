using MakeCloneFacebookApp.Helpers;
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
    public partial class frmSendMessage : Form
    {
        private JsonDBHelper dBHelper;
        public frmSendMessage(ref JsonDBHelper dBHelper)
        {
            InitializeComponent();
            this.dBHelper = dBHelper;
            this.Load += Frm_Users_Load;
        }
        private void Frm_Users_Load(object sender, EventArgs e)
        {
            gv_message.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (var user in dBHelper.GetUsers())
            {
                gv_message.Rows.Add(user.UserName);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            List<string> messages = new List<string>();
            foreach (DataGridViewRow row in gv_message.Rows)
            {
                if (row.Cells["message"].Value == null)
                {
                    continue;
                }
                messages.Add(row.Cells["message"].Value.ToString());
            }
            if (dBHelper.SaveUsers(users))
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
