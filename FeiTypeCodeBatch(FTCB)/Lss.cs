using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Lss : BasicType
    {
        public Lss()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToInt32() < values.ToInt32();
        }
    }
}
