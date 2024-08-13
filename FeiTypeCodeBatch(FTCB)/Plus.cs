using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Plus : BasicType
    {
        public Plus()
        {
            
        }
        public override object MethodReturn(object[] values)
        {
            return Convert.ToInt32(values[0]) + Convert.ToInt32(values[1]);
        }
    }
}
