﻿using MakeCloneFacebookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeCloneFacebookApp.Views
{
    public partial class FacebookWebBrowser : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private enum FacebookAction
        {
            Postwall,
            SendMessage,
            NoAction,
            AllActionCompleted
        };
        private const string FBURL = "https://www.facebook.com";

        public JobConfig Config { private set; get; }
        public List<PostWallMessage> PostWallMessages { private set; get; }
        public List<SendMessage> SendMessages { private set; get; }
        public User CurrentRunUser { private set; get; }
        private int userIndex;

        private int _Step = -1;
        private int Step
        {
            set
            {
                _Step = value;
                if(_Step == -1)
                {
                    ActionCompleted();
                }
            }
            get
            {
                return _Step;
            }
        }
        private FacebookAction Action = FacebookAction.NoAction;
        public FacebookWebBrowser(JobConfig config, List<PostWallMessage> postWallMessages, List<SendMessage> sendMessages)
        {
            InitializeComponent();
            this.Config = config;
            this.PostWallMessages = postWallMessages;
            this.SendMessages = sendMessages;
            userIndex = 0;
            this.Load += FacebookWebBrowser_Load;
        }

        private void FacebookWebBrowser_Load(object sender, EventArgs e)
        {
            if (IsNextUser())
            {
                ActionCompleted();
            }
        }
        private bool IsNextUser()
        {
            if (userIndex < Config.UserConfigs.Count)
            {
                CurrentRunUser = Config.UserConfigs[userIndex];
                userIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ActionCompleted()
        {
            if(Action == FacebookAction.NoAction)
            {
                if (Config.IsPostWall)
                {
                    BeginPostWall();
                }
                else if(Config.IsSendMessage)
                {
                    BeginSendMessage();
                }
                else
                {
                    Action = FacebookAction.AllActionCompleted;
                    if (IsNextUser())
                    {
                        Action = FacebookAction.NoAction;
                        ActionCompleted();
                    }
                    else
                    {
                        SetStatus("Completed", true);
                    }
                }
            }
            else if(Action == FacebookAction.Postwall)
            {
                if (Config.IsSendMessage)
                {
                    BeginSendMessage();
                }
                else
                {
                    Action = FacebookAction.AllActionCompleted;
                    if (IsNextUser())
                    {
                        Action = FacebookAction.NoAction;
                        ActionCompleted();
                    }
                    else
                    {
                        SetStatus("Completed", true);
                    }
                }
            }
            else if(Action == FacebookAction.SendMessage)
            {
                Action = FacebookAction.AllActionCompleted;
                if (IsNextUser())
                {
                    Action = FacebookAction.NoAction;
                    ActionCompleted();
                }
                else
                {
                    SetStatus("Completed", true);
                }
            }
        }
        private void BeginPostWall()
        {
            Action = FacebookAction.Postwall;
            Step = 0;
            SetStatus("Posting Wall...");
            wb.Navigate(FBURL);
        }
        private void BeginSendMessage()
        {
            Action = FacebookAction.SendMessage;
            Step = 0;
            SetStatus("Sending message...");
            wb.Navigate(FBURL);
        }

        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (Action == FacebookAction.Postwall)
            {
                if (wb.Document.GetElementById("pass") != null)
                {
                    // Logined but not go wall => incorrect password
                    if(Step == 1)
                    {
                        Step = -1;
                    }

                    SetStatus("Login");
                    wb.Document.GetElementById("email").SetAttribute("value", CurrentRunUser.UserName);
                    wb.Document.GetElementById("pass").SetAttribute("value", CurrentRunUser.Password);
                    var login_form = wb.Document.GetElementById("login_form");
                    if (login_form != null)
                    {
                        login_form.InvokeMember("submit");
                    }
                    Step = 1;
                }
                else
                {
                    if (Step == 0) // Login before; Go logout.
                    {
                        SetStatus("Logout");
                        System.Threading.Thread thrun = new System.Threading.Thread(() =>
                        {
                            System.Threading.Thread.Sleep(2000);
                            HtmlElement setting = null;

                            // Get the setting action;
                            this.Invoke(new Action(() =>
                            {
                                setting = wb.Document.GetElementById("pageLoginAnchor");
                            }));
                            if (setting != null)
                            {
                            // Click the setting action for auto genate logout form
                            this.Invoke(new Action(() =>
                                {
                                    setting.InvokeMember("Click");
                                }));

                                // get logout form and submit
                                HtmlElement login_form = null;
                                HtmlElementCollection a_s = null;
                                while (login_form == null)
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    try
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            a_s = wb.Document.GetElementsByTagName("form");
                                        }));
                                        foreach (HtmlElement item in a_s)
                                        {
                                            if (item.GetAttribute("classname") == "_w0d _w0d")
                                            {
                                                login_form = item;
                                                break;
                                            }
                                        }
                                    }
                                    catch { }
                                }

                                // Logout this user
                                this.Invoke(new Action(() =>
                                {
                                    login_form.InvokeMember("submit");
                                }));
                            }
                        });
                        thrun.Start();
                    }
                    else if (Step == 1) // Login completed; go to home
                    {
                        SetStatus("Go to Home");
                        var a_s = wb.Document.GetElementsByTagName("a");
                        foreach (HtmlElement item in a_s)
                        {
                            if (item.GetAttribute("classname") == "_2s25 _606w")
                            {
                                item.InvokeMember("Click");
                                Step = 2;
                                break;
                            }
                        }
                    }
                    else if (Step == 2) // go to write in your wall.
                    {
                        SetStatus("Posting wall");
                        var div_s = wb.Document.GetElementsByTagName("div");
                        foreach (HtmlElement item in div_s)
                        {
                            if (item.GetAttribute("classname") == "notranslate _5rpu" && item.GetAttribute("data-testid") == "status-attachment-mentions-input")
                            {
                                item.InvokeMember("Click");
                                Step = 3;
                                break;
                            }
                        }

                        // Go to write and post
                        if (Step == 3)
                        {
                            Step = -2; //Pending

                            SetForegroundWindow(wb.Handle);
                            SendKeys.SendWait(RandomPostWallMessage());

                            ////Click button Post
                            System.Threading.Thread thrun = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                            {
                                HtmlElement buttonPost = null;
                                while (buttonPost == null)
                                {
                                    HtmlElementCollection button_s = null;
                                    this.Invoke(new Action(() =>
                                    {
                                        button_s = wb.Document.GetElementsByTagName("button");
                                    }));
                                    foreach (HtmlElement item in button_s)
                                    {
                                        if (item.GetAttribute("classname") == "_1mf7 _4r1q _4jy0 _4jy3 _4jy1 _51sy selected _42ft")
                                        {
                                            buttonPost = item;
                                            break;
                                        }
                                    }
                                    System.Threading.Thread.Sleep(1000);
                                }

                                // sleep 10s make sure all related this post is loaded.
                                System.Threading.Thread.Sleep(10000);

                                buttonPost.InvokeMember("Click");

                                System.Threading.Thread.Sleep(10000); // wait for this post completed
                                Step = -1;
                            }));
                            thrun.Start();
                        }
                    }
                }
            }
            else if(Action == FacebookAction.SendMessage)
            {
                if (wb.Document.GetElementById("pass") != null)
                {
                    // Logined but not go wall => incorrect password
                    if (Step == 1)
                    {
                        Step = -1;
                    }
                    SetStatus("Login");
                    wb.Document.GetElementById("email").SetAttribute("value", CurrentRunUser.UserName);
                    wb.Document.GetElementById("pass").SetAttribute("value", CurrentRunUser.Password);
                    var login_form = wb.Document.GetElementById("login_form");
                    if (login_form != null)
                    {
                        login_form.InvokeMember("submit");
                    }
                    Step = 1;
                }
                else
                {
                    if (Step == 0) // Login before; Go logout.
                    {
                        SetStatus("Logout");
                        System.Threading.Thread thrun = new System.Threading.Thread(() =>
                        {
                            try
                            {

                                System.Threading.Thread.Sleep(2000);
                                HtmlElement setting = null;

                                // Get the setting action;
                                this.Invoke(new Action(() =>
                                {
                                    setting = wb.Document.GetElementById("pageLoginAnchor");
                                }));
                                if (setting != null)
                                {
                                    // Click the setting action for auto genate logout form
                                    this.Invoke(new Action(() =>
                                    {
                                        setting.InvokeMember("Click");
                                    }));

                                    // get logout form and submit
                                    HtmlElement login_form = null;
                                    HtmlElementCollection a_s = null;
                                    while (login_form == null)
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                        try
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                a_s = wb.Document.GetElementsByTagName("form");
                                            }));
                                            foreach (HtmlElement item in a_s)
                                            {
                                                if (item.GetAttribute("classname") == "_w0d _w0d")
                                                {
                                                    login_form = item;
                                                    break;
                                                }
                                            }
                                        }
                                        catch { }
                                    }

                                    // Logout this user
                                    this.Invoke(new Action(() =>
                                    {
                                        login_form.InvokeMember("submit");
                                    }));
                                }
                            }
                            catch { }
                        });
                        thrun.Start();
                    }
                    else if (Step == 1) // Login completed;
                    {
                        Step = -2; //Pending

                        System.Threading.Thread thrun = new System.Threading.Thread(new System.Threading.ThreadStart(() => {

                            try
                            {
                                System.Threading.Thread.Sleep(5000); // wait for load completed
                                                                     // Close all messge window
                                this.Invoke(new Action(() =>
                                {
                                    var a_s = wb.Document.GetElementsByTagName("a");
                                    foreach (HtmlElement a in a_s)
                                    {
                                        if (a.GetAttribute("classname") == "_3olu _3olv close button _4vu4")
                                        {
                                            a.InvokeMember("Click");
                                        }
                                    }
                                }));


                                int sendCount = 0;
                                HtmlElementCollection ul_s = null;
                                this.Invoke(new Action(() =>
                                {
                                    ul_s = wb.Document.GetElementsByTagName("ul");
                                }));
                                foreach (HtmlElement ul in ul_s)
                                {
                                    if (ul.GetAttribute("donotdisturbmap") == "[object Object]")
                                    {
                                        HtmlElementCollection a_s = null;
                                        this.Invoke(new Action(() =>
                                        {
                                            a_s = ul.GetElementsByTagName("a");
                                        }));
                                        foreach (HtmlElement a in a_s)
                                        {
                                            if (a.GetAttribute("classname") == "_55ln _qhr")
                                            {
                                                // Click to other people for chat
                                                this.Invoke(new Action(() =>
                                                {
                                                    a.InvokeMember("Click");
                                                }));

                                                // Wait loading
                                                System.Threading.Thread.Sleep(3000);

                                                HtmlElementCollection div_s = null;
                                                this.Invoke(new Action(() =>
                                                {
                                                    div_s = wb.Document.GetElementsByTagName("div");
                                                }));
                                                System.Threading.Thread.Sleep(5000);
                                                foreach (HtmlElement item in div_s)
                                                {
                                                    SetStatus("Sending message");
                                                    if (item.GetAttribute("classname") == "notranslate _5rpu" && item.GetAttribute("data-testid") == "")
                                                    {
                                                        this.Invoke(new Action(() =>
                                                        {
                                                            item.InvokeMember("Click");
                                                        }));

                                                        System.Threading.Thread.Sleep(5000);

                                                        this.Invoke(new Action(() =>
                                                        {
                                                            SetForegroundWindow(wb.Handle);
                                                            SendKeys.SendWait(RandomSendMessage());
                                                        }));

                                                        System.Threading.Thread.Sleep(1000);

                                                        this.Invoke(new Action(() =>
                                                        {
                                                            SetForegroundWindow(wb.Handle);
                                                            SendKeys.SendWait("{ENTER}");
                                                        }));

                                                        System.Threading.Thread.Sleep(5000);

                                                        // Close all messge window
                                                        this.Invoke(new Action(() =>
                                                        {
                                                            var a_s_1 = wb.Document.GetElementsByTagName("a");
                                                            foreach (HtmlElement a1 in a_s_1)
                                                            {
                                                                if (a1.GetAttribute("classname") == "_3olu _3olv close button _4vu4")
                                                                {
                                                                    a1.InvokeMember("Click");
                                                                }
                                                            }
                                                        }));

                                                        sendCount++;
                                                        if (sendCount >= Config.CountPeople)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }

                                            }
                                            if (sendCount >= Config.CountPeople)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    if (sendCount >= Config.CountPeople)
                                    {
                                        break;
                                    }
                                }
                            }
                            catch { }
                            Step = -1;
                        }));
                        thrun.Start();
                    }
                }
            }
        }
        private string RandomPostWallMessage()
        {
            return PostWallMessages[new Random().Next(0, PostWallMessages.Count() - 1)].Message;
        }
        private string RandomSendMessage()
        {
            return SendMessages[new Random().Next(0, SendMessages.Count() - 1)].Message;
        }
        private void SetStatus(string message, bool AllCompleted = false)
        {
            this.Invoke(new Action(() =>
            {
                lbstatus.Text = string.Format("User: '{0}' => Action: '{1}' => Status: '{2}'", CurrentRunUser.UserName, Action.ToString(), message);
            }));
            if (AllCompleted)
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    int totalSecondLeft = 10;
                    while (totalSecondLeft-- > 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lbstatus.Text = string.Format("The website will be close in {0}", totalSecondLeft);
                        }));
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                })).Start();
            }
        }
    }
}
