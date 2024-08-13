using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Bool : BasicType
    {
        public Bool() { }
        public override object GetVarCore(string value)
        {
            return bool.Parse(value);
        }
    }
}
