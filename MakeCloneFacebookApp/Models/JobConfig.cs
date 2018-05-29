using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Models
{
    public class JobConfig
    {
        public int Type { set; get; }
        public TimmingConfig TimmingConfig { set; get; }
        public IntervalConfig IntervalConfig { set; get; }
        public int NotifyBeforeTime { set; get; }
        public List<User> UserConfigs { set; get; }
        public bool IsSendMessage { set; get; }
        public int CountPeople { set; get; }
        public bool IsPostWall { set; get; }
    }
}
