using GetKeyMakeCloneFacebookApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetKeyMakeCloneFacebookApp.Models
{
    public class KeyActionRequest
    {
        public string u { set; get; }
        public string p { set; get; }
        public Key Key { set; get; }
        public KeyAction Action { set; get; }
    }
}
