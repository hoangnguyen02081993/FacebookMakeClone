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
        public frm_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FacebookWebBrowser frm = new FacebookWebBrowser(tbuser.Text, tb_pass.Text, tb_message.Text, tb_sendm.Text, Int32.Parse(tb_count.Text)))
            {
                frm.ShowDialog();
            }
        }
    }
}
