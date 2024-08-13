using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public static class U2
    {
        public static double ToDouble(this object o)
        {
            return Convert.ToDouble(o);
        }
    }
    public class Pow : BasicType
    {
        public Pow()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return Math.Pow(values[0].ToDouble(), values[1].ToDouble());
        }
    }
}
