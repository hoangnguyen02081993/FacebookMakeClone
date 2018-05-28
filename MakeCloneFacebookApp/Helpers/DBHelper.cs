using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Helpers
{
    public abstract class DBHelper
    {
        public DBType Type { protected set; get; }
        public abstract bool Save();
        public abstract bool ReadData();
    }
    public enum DBType
    {
        Xml,
        Json,
        SQLServer
    };
    public enum ActionType
    {
        Add,
        Edit,
        Remove
    }
}
