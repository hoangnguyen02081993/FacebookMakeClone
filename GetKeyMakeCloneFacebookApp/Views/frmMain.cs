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
    public partial class frmMain : Form
    {
        private LisenceHelper lisenceHelper = new LisenceHelper();
        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                var result = lisenceHelper.GetAllKey();
                if(result.Result == 0)
                {
                    foreach (Key key in result.Data)
                    {
                        gv_data.Rows.Add(key.Id,
                                         key.LisenceKey,
                                         key.Count,
                                         key.IsActiveForever,
                                         key.MonthCount,
                                         key.IsActive);
                    }   
                }
                else
                {
                    Until.ShowErrorBox(result.Message);
                }
            }
            catch(Exception ex)
            {
                Until.ShowErrorBox(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAddKey frm = new frmAddKey())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var result = lisenceHelper.AddKey(frm.Key);
                        if(result.Result == 0)
                        {
                            gv_data.Rows.Add(frm.Key.Id,
                                         frm.Key.LisenceKey,
                                         frm.Key.Count,
                                         frm.Key.IsActiveForever,
                                         frm.Key.MonthCount,
                                         frm.Key.IsActive);
                            Until.ShowInfoBox("Add key successfully");
                        }
                        else
                        {
                            Until.ShowErrorBox(result.Message);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Until.ShowErrorBox(ex.Message);
            }
        }

        private void BtnActive_Click(object sender, EventArgs e)
        {
            try
            {
                if(gv_data.SelectedRows.Count == 0 || gv_data.SelectedRows[0].Cells["Id"].Value == null)
                {
                    Until.ShowErrorBox("Please choose Key first");
                    return;
                }
                Key key = new Key()
                {
                    Id = (Guid)gv_data.SelectedRows[0].Cells["id"].Value,
                    IsActive = ((int)gv_data.SelectedRows[0].Cells["actived"].Value == 1) ? 0 : 1
                };
                var result = lisenceHelper.EditActiveKey(key);
                if (result.Result == 0)
                {
                    gv_data.SelectedRows[0].Cells["actived"].Value = key.IsActive;
                    Until.ShowInfoBox(string.Format("{0} key successfully", key.IsActive == 0 ? "UnActive" : "Active"));
                }
                else
                {
                    Until.ShowErrorBox(result.Message);
                }
            }
            catch (Exception ex)
            {
                Until.ShowErrorBox(ex.Message);
            }
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (gv_data.SelectedRows.Count == 0 || gv_data.SelectedRows[0].Cells["Id"].Value == null)
            {
                Until.ShowErrorBox("Please choose Key first");
                return;
            }
            System.Windows.Forms.Clipboard.SetText((string)gv_data.SelectedRows[0].Cells["key"].Value);
        }
    }
}
