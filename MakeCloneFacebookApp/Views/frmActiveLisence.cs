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
    public partial class frmActiveLisence : Form
    {
        private LisenceHelper<LisenceResult> lisenceHelper;
        private bool ActiveResult = false;
        public frmActiveLisence(ref LisenceHelper<LisenceResult> lisenceHelper)
        {
            InitializeComponent();
            this.lisenceHelper = lisenceHelper;
            this.Load += FrmActiveLisence_Load;
        }

        private void FrmActiveLisence_Load(object sender, EventArgs e)
        {
            if(LisenceHelper<LisenceResult>.Information != null && LisenceHelper<LisenceResult>.Information.Result == 0)
            {
                pnactive.Visible = false;
                lable.Visible = true;
            }
            else
            {
                pnactive.Visible = true;
                pnactived.Visible = false;
            }
        }

        private void BtnActive_Click(object sender, EventArgs e)
        {
            BtnActive.Enabled = false;

            try
            {
                var result = lisenceHelper.SetLisenceResult(string.Format("{0}-{1}-{2}", TbKey1.Text, TbKey2.Text, TbKey3.Text));
                if(result.Result == 0)
                {
                    ActiveResult = true;
                }
                switch(result.Result)
                {
                    case -2:
                        Until.ShowErrorBox("Format active is incorrect!");
                        break;
                    case -1:
                        Until.ShowInfoBox("This lisence is actived forever!");
                        break;
                    case 0:
                        Until.ShowInfoBox("This lisence is actived!");
                        break;
                    case 1:
                        Until.ShowErrorBox("Key isn't exist!");
                        break;
                    case 2:
                        Until.ShowErrorBox("Serial isn't exist!");
                        break;
                    case 3:
                        Until.ShowErrorBox("Key is Expired!");
                        break;
                    default:
                        Until.ShowErrorBox("Can't connect to server!");
                        break;
                }
            }
            catch(Exception ex)
            {
                Until.ShowErrorBox(ex.Message);
            }

            BtnActive.Enabled = true;
        }

        private void TbKey1_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbKey1.Text.Length == 5)
            {
                TbKey2.Focus();
            }
        }

        private void TbKey2_KeyUp(object sender, KeyEventArgs e)
        {
            if(TbKey2.Text.Length == 5)
            {
                TbKey3.Focus();
            }
        }

        private void FrmActiveLisence_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ActiveResult)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
