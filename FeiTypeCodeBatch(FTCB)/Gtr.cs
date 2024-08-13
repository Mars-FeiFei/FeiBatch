using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Gtr : BasicType
    {
        public Gtr()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToDouble() > values[1].ToDouble();
        }
    }
}
