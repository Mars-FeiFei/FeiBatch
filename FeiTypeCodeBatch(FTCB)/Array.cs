using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Array : BasicType
    {
        public Array() { }
        public override object GetVarCore(string value)
        {
            return new object[value.ToInt32()];
        }
    }
}
