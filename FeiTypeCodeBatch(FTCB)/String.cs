using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class String : BasicType
    {
        public String() { }
        public override object GetVarCore(string value)
        {
            return value;
        }
    }
}
