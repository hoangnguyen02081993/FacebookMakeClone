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
    public partial class frm_main : Form
    {
        private JsonDBHelper dBHelper = new JsonDBHelper();
        public frm_main()
        {
            InitializeComponent();
            this.Load += Frm_main_Load;
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            dBHelper.ReadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FacebookWebBrowser frm = new FacebookWebBrowser(tbuser.Text, tb_pass.Text, tb_message.Text, tb_sendm.Text, Int32.Parse(tb_count.Text)))
            {
                frm.ShowDialog();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_Users frm = new frm_Users(ref dBHelper))
            {
                frm.ShowDialog();
            }
        }

        private void SendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
