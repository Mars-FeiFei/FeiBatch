using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FeiTypeCodeBatch_FTCB_;
namespace Using
{
    public class ArrayVal : BasicType
    {

        public ArrayVal()
        {
        }
        public override object MethodReturn(object[] values)
        {
            object[] arr = V.v[values[0].ToString()] as object[];
            foreach (var v in V.vn)
            {
                if (values[1].ToString() == v)
                {
                    object a = (object)V.v[v].ToString();
                    values[1] = a;
                }
            }
            return arr[values[1].ToInt32()];
        }
    }
}
