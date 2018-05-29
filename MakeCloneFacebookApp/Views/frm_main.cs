using MakeCloneFacebookApp.Helpers;
using MakeCloneFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            Cbtype.SelectedIndex = 0;
            chblusers.Items.Clear();
            foreach (var item in dBHelper.GetUsers())
            {
                chblusers.Items.Add(item.UserName);
            }

            dBHelper.ReadData();
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

                var items = new List<string>();
                foreach (var item in chblusers.CheckedItems)
                {
                    items.Add((string)item);
                }

                chblusers.Items.Clear();

                foreach (var item in dBHelper.GetUsers())
                {
                    chblusers.Items.Add(item.UserName);
                }

                foreach (var item in items)
                {
                    for (int i = 0; i < chblusers.Items.Count; i++)
                    {
                        if((string)item == (string)chblusers.Items[i])
                        {
                            chblusers.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void SendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSendMessage frm = new frmSendMessage(ref dBHelper))
            {
                frm.ShowDialog();
            }
        }

        private void PostWallMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPostWallMessage frm = new frmPostWallMessage(ref dBHelper))
            {
                frm.ShowDialog();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Facebook App File | *.fajob";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    JobConfig jobConfig = new JobConfig()
                    {
                        Type = Cbtype.SelectedIndex,
                        TimmingConfig = new TimmingConfig()
                        {
                            IsUsedOne = chbtimming1.Checked,
                            IsUsedTwo = chbtimming2.Checked,
                            IsUsedThree = chbtimming3.Checked,
                            IsUsedFour = chbtimming4.Checked,
                            TimeOne = (int)dttimming1.Value.TimeOfDay.TotalSeconds,
                            TimeTwo = (int)dttimming2.Value.TimeOfDay.TotalSeconds,
                            TimeThree = (int)dttimming3.Value.TimeOfDay.TotalSeconds,
                            TimeFour = (int)dttimming4.Value.TimeOfDay.TotalSeconds
                        },
                        IntervalConfig = new IntervalConfig()
                        {
                            IsRunNow = chbRunNow.Checked,
                            Interval = (int)nudinterval.Value
                        },
                        NotifyBeforeTime = (int)nudnotify.Value,
                        UserConfigs = new List<User>(),
                        IsSendMessage = chbsendmessage.Checked,
                        IsPostWall = chbpostwall.Checked,
                        CountPeople = (int)nudpeoplecount.Value
                    };

                    var users = dBHelper.GetUsers();
                    foreach (string item in chblusers.CheckedItems)
                    {
                        var user = users.Where(u => u.UserName.Equals((string)item)).FirstOrDefault();
                        if(user != null)
                        {
                            jobConfig.UserConfigs.Add(user);
                        }
                    }
                    if(jobConfig.Save(sfd.FileName))
                    {
                        Until.ShowInfoBox("Save successfully");
                    }
                    else
                    {
                        Until.ShowErrorBox("Save failed");
                    }
                }
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Facebook App File | *.fajob";
                ofd.Multiselect = false;
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    JobConfig jobConfig = new JobConfig();
                    if(jobConfig.Open(ref jobConfig, ofd.FileName))
                    {
                        Cbtype.SelectedIndex = jobConfig.Type;

                        chbtimming1.Checked = jobConfig.TimmingConfig.IsUsedOne;
                        chbtimming2.Checked = jobConfig.TimmingConfig.IsUsedTwo;
                        chbtimming3.Checked = jobConfig.TimmingConfig.IsUsedThree;
                        chbtimming4.Checked = jobConfig.TimmingConfig.IsUsedFour;
                        dttimming1.Value = DateTime.Now.Date.AddSeconds(jobConfig.TimmingConfig.TimeOne);
                        dttimming2.Value = DateTime.Now.Date.AddSeconds(jobConfig.TimmingConfig.TimeTwo);
                        dttimming3.Value = DateTime.Now.Date.AddSeconds(jobConfig.TimmingConfig.TimeThree);
                        dttimming4.Value = DateTime.Now.Date.AddSeconds(jobConfig.TimmingConfig.TimeFour);

                        nudinterval.Value = jobConfig.IntervalConfig.Interval;
                        chbRunNow.Checked = jobConfig.IntervalConfig.IsRunNow;

                        nudnotify.Value = jobConfig.NotifyBeforeTime;

                        for (int i = 0; i < chblusers.Items.Count; i++)
                        {
                            chblusers.SetItemChecked(i, false);
                        }

                        foreach (var user in jobConfig.UserConfigs)
                        {
                            for (int i = 0; i < chblusers.Items.Count; i++)
                            {
                                if(user.UserName == (string)chblusers.Items[i])
                                {
                                    chblusers.SetItemChecked(i, true);
                                    break;
                                }
                            }
                        }

                        chbsendmessage.Checked = jobConfig.IsSendMessage;
                        chbpostwall.Checked = jobConfig.IsPostWall;
                        nudpeoplecount.Value = jobConfig.CountPeople;

                        Until.ShowInfoBox("Open successfully");
                    }
                    else
                    {
                        Until.ShowErrorBox("Open Failed");
                    }
                }
            }
        }

        private void Cbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(Cbtype.SelectedIndex)
            {
                case 0:
                    pntimming.Visible = true;
                    pninterval.Visible = false;
                    break;
                case 1:
                    pntimming.Visible = false;
                    pninterval.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void SimpleFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\ATP",
                                                  "ATP-FACEBOOK",
                                                  string.Format("ATP-FACEBOOK-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}",
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar(),
                                                                GetRanDomFourChar()),
                                                  Microsoft.Win32.RegistryValueKind.String);
                var process = Process.Start("\"" + Application.StartupPath + "/" + "Simple Facebook.exe\"");
                process.WaitForExit();
            }
            catch(Exception ex)
            {
                string hoang1 = ex.Message;
            }
        }
        private string GetRanDomFourChar()
        {
            Thread.Sleep(10);
            return new Random().Next(4096, 65534).ToString("X");
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if(BtnRun.Text == "Run")
            {
                // TODO Run
                JobConfig jobConfig = new JobConfig()
                {
                    Type = Cbtype.SelectedIndex,
                    TimmingConfig = new TimmingConfig()
                    {
                        IsUsedOne = chbtimming1.Checked,
                        IsUsedTwo = chbtimming2.Checked,
                        IsUsedThree = chbtimming3.Checked,
                        IsUsedFour = chbtimming4.Checked,
                        TimeOne = (int)dttimming1.Value.TimeOfDay.TotalSeconds,
                        TimeTwo = (int)dttimming2.Value.TimeOfDay.TotalSeconds,
                        TimeThree = (int)dttimming3.Value.TimeOfDay.TotalSeconds,
                        TimeFour = (int)dttimming4.Value.TimeOfDay.TotalSeconds
                    },
                    IntervalConfig = new IntervalConfig()
                    {
                        IsRunNow = chbRunNow.Checked,
                        Interval = (int)nudinterval.Value
                    },
                    NotifyBeforeTime = (int)nudnotify.Value,
                    UserConfigs = new List<User>(),
                    IsSendMessage = chbsendmessage.Checked,
                    IsPostWall = chbpostwall.Checked,
                    CountPeople = (int)nudpeoplecount.Value
                };

                var users = dBHelper.GetUsers();
                foreach (string item in chblusers.CheckedItems)
                {
                    var user = users.Where(u => u.UserName.Equals((string)item)).FirstOrDefault();
                    if (user != null)
                    {
                        jobConfig.UserConfigs.Add(user);
                    }
                }

                using (FacebookWebBrowser frm = new FacebookWebBrowser(jobConfig, dBHelper.GetPostWallMessages().ToList(), dBHelper.GetSendMessages().ToList()))
                {
                    frm.ShowDialog();
                }

                    BtnRun.Text = "Stop";
            }
            else
            {
                // TODO Stop

                BtnRun.Text = "Run";
            }
        }
    }
}
