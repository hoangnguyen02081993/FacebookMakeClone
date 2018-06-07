using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Models
{
    public class LisenceResult
    {
        //[CheckLisence] -3: Can't connect serrver; -2: parameter isn't correct; -1: Fail; 0: OK; 1:Trial; 2: Active on time;
        //[Active] -3: Can't connect serrver; -2: parameter isn't correct; -1: Account is active forever; 0: OK; 1: Key isn't exist; 2: Serial isn't exist; 3: Key is Expired
        public int Result { set; get; } = -3;
        public string Message { set; get; }
        public string ExpiredDateString { set; get; }
        public DateTime ExpiredDate => DateTime.Parse(ExpiredDateString);
    }
}
