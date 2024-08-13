using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Times : BasicType
    {
        public Times()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToInt32() * values[1].ToInt32();
        }
    }
}
