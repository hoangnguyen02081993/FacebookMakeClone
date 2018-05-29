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
    public partial class frmSendMessageAction : Form
    {
        public AppConfigAction Action { private set; get; }
        public SendMessage Result { private set; get; }
        public frmSendMessageAction(AppConfigAction action, SendMessage sendMessage = null)
        {
            InitializeComponent();
            this.Action = action;
            this.Result = sendMessage;
            this.Load += FrmSendMessageAction_Load;
        }

        private void FrmSendMessageAction_Load(object sender, EventArgs e)
        {
            switch (Action)
            {
                case AppConfigAction.Add:
                    BtnOk.Text = "Add";
                    break;
                case AppConfigAction.Edit:
                    TbMessage.Enabled = false;
                    BtnOk.Text = "Edit";
                    TbMessage.Text = Result.Message;
                    break;
                default:
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbMessage.Text))
            {
                Until.ShowErrorBox("Message must be not null or empty!");
            }
            Result = new SendMessage()
            {
                 Message = TbMessage.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
