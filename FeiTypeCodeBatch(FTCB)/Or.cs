using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using { 
    public class Or : BasicType
    {
        public Or() { }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToBool() || values[1].ToBool();
        }
    }
}
