﻿using MakeCloneFacebookApp.Common;
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
    public partial class frmSendMessage : Form
    {
        private JsonDBHelper dBHelper;
        public frmSendMessage(ref JsonDBHelper dBHelper)
        {
            InitializeComponent();
            this.dBHelper = dBHelper;
            this.Load += FrmSendMessage_Load;
        }

        private void FrmSendMessage_Load(object sender, EventArgs e)
        {
            gv_message.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (var message in dBHelper.GetSendMessages())
            {
                gv_message.Rows.Add(message.Message);
            }
        }
        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_save_Click(object sender, EventArgs e)
        {
            List<SendMessage> messages = new List<SendMessage>();
            foreach (DataGridViewRow row in gv_message.Rows)
            {
                if (row.Cells["message"].Value == null)
                {
                    continue;
                }
                messages.Add(new SendMessage() { Id = Guid.NewGuid(), Message = row.Cells["message"].Value.ToString()});
            }
            if (dBHelper.SaveSendMessages(messages))
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
            if (gv_message.SelectedRows.Count > 0)
            {
                gv_message.Rows.Remove(gv_message.SelectedRows[0]);
            }
            else Until.ShowErrorBox("Please choose data first");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (gv_message.SelectedRows.Count > 0)
            {
                using (frmSendMessageAction frm = new frmSendMessageAction(AppConfigAction.Edit, new SendMessage()
                {
                    Message = gv_message.SelectedRows[0].Cells["message"].Value.ToString()
                }))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //TODO
                        gv_message.SelectedRows[0].Cells["message"].Value = frm.Result.Message;
                    }
                }
            }
            else Until.ShowErrorBox("Please choose data first");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (frmSendMessageAction frm = new frmSendMessageAction(AppConfigAction.Add))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //TODO
                    gv_message.Rows.Add(frm.Result.Message);
                }
            }
        }
    }
}
