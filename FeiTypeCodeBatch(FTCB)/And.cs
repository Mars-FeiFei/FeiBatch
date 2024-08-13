using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public static class BoolToObj
    {
        public static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }
    }
    public class And : BasicType
    {
        public And()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToBool() && values[1].ToBool();
        }
    }
}
