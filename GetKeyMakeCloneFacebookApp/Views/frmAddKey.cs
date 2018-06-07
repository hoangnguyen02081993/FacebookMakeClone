using GetKeyMakeCloneFacebookApp.Helpers;
using GetKeyMakeCloneFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetKeyMakeCloneFacebookApp.Views
{
    public partial class frmAddKey : Form
    {
        public Key Key { private set; get; }
        public frmAddKey()
        {
            InitializeComponent();
            this.Load += FrmAddKey_Load;
        }

        private void FrmAddKey_Load(object sender, EventArgs e)
        {
            tbKey.Text = string.Format("{0}-{1}-{2}", Until.GetRanDomHex(5), Until.GetRanDomHex(5), Until.GetRanDomHex(5));
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Key = new Key()
            {
                Id = Guid.NewGuid(),
                LisenceKey = tbKey.Text,
                Count = (int)nudcount.Value,
                MonthCount = (int)nudmonth.Value,
                IsActive = chbactive.Checked ? 1 : 0,
                IsActiveForever = chbforver.Checked ? 1 :0
            };
            DialogResult = DialogResult.OK;
        }
    }
}
