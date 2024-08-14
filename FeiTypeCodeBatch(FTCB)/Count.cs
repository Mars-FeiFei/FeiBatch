using FeiTypeCodeBatch_FTCB_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Count : BasicType
    {
        public Count() { }
        public override object MethodReturn(object[] values)
        {
            return ((object[])V.v[values[0].ToString()]).Length;
        }
    }
}
