using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Equals : BasicType
    {
        public Equals() { }
        public override object MethodReturn(object[] values)
        {
            return values[0].Equals(values[1]);
        }
    }
}
