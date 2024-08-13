using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public static class U
    {
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }
    }
    public class Sub : BasicType
    {
        public Sub()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToInt32() - values[1].ToInt32();
        }
    }
}
