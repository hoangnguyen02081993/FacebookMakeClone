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
    public partial class frm_PostWallMessage : Form
    {
        private JsonDBHelper dBHelper = null;
        public frm_PostWallMessage(ref JsonDBHelper dBHelper)
        {
            InitializeComponent();
            this.dBHelper = dBHelper;
            this.Load += Frm_PostWallMessage_Load;
        }

        private void Frm_PostWallMessage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
