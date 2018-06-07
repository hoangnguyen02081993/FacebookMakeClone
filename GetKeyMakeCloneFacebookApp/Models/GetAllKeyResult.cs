using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetKeyMakeCloneFacebookApp.Models
{
    public class GetAllKeyResult
    {
        public int Result { set; get; }
        public string Message { set; get; }
        public IEnumerable<Key> Data { set; get; }
    }
}
