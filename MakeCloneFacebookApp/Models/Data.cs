﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Models
{
    public class Data
    {
        public List<User> Users { set; get; }
        public List<string> PostWallContentsTemplate { set; get; }
        public List<string> SendMessageTemplate { set; get; }
        public Data()
        {
            Users = new List<User>();
            PostWallContentsTemplate = new List<string>();
            SendMessageTemplate = new List<string>();
        }
    }
}
