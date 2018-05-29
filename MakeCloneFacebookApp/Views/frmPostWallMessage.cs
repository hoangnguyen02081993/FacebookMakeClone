using MakeCloneFacebookApp.Common;
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
    public partial class frmPostWallMessage : Form
    {
        private JsonDBHelper dBHelper;
        public frmPostWallMessage(ref JsonDBHelper dBHelper)
        {
            InitializeComponent();
            this.dBHelper = dBHelper;
            this.Load += FrmPostWallMessage_Load;
        }

        private void FrmPostWallMessage_Load(object sender, EventArgs e)
        {
            gv_postwallmessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (var user in dBHelper.GetPostWallMessages())
            {
                gv_postwallmessages.Rows.Add(user.Message);
            }
        }
        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_save_Click(object sender, EventArgs e)
        {
            List<PostWallMessage> messages = new List<PostWallMessage>();
            foreach (DataGridViewRow row in gv_postwallmessages.Rows)
            {
                if (row.Cells["message"].Value == null)
                {
                    continue;
                }
                messages.Add(new PostWallMessage() { Id = Guid.NewGuid(), Message = row.Cells["message"].Value.ToString() });
            }
            if (dBHelper.SavePostWallMessages(messages))
            {
                Until.ShowInfoBox("Saves users successfully");
            }
            else
            {
                Until.ShowErrorBox("Saves users failed");
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (gv_postwallmessages.SelectedRows.Count > 0)
            {
                gv_postwallmessages.Rows.Remove(gv_postwallmessages.SelectedRows[0]);
            }
            else Until.ShowErrorBox("Please choose data first");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (gv_postwallmessages.SelectedRows.Count > 0)
            {
                using (frmPostWallMessageAction frm = new frmPostWallMessageAction(AppConfigAction.Edit, new PostWallMessage()
                {
                    Message = gv_postwallmessages.SelectedRows[0].Cells["message"].Value.ToString()
                }))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //TODO
                        gv_postwallmessages.SelectedRows[0].Cells["message"].Value = frm.Result.Message;
                    }
                }
            }
            else Until.ShowErrorBox("Please choose data first");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (frmPostWallMessageAction frm = new frmPostWallMessageAction(AppConfigAction.Add))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //TODO
                    gv_postwallmessages.Rows.Add(frm.Result.Message);
                }
            }
        }
    }
}
