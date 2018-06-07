using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetKeyMakeCloneFacebookApp.Models
{
    public class Key
    {
        public Guid Id { set; get; }
        public string LisenceKey { set; get; }
        public int IsActive { set; get; }
        public int Count { set; get; }
        public int IsActiveForever { set; get; }
        public int MonthCount { set; get; }
    }
}
