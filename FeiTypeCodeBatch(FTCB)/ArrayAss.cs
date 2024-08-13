using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeiTypeCodeBatch_FTCB_;
namespace Using
{
    public class ArrayAss : BasicType
    {
        public ArrayAss()
        {
        }
        public override void Method(object[] values)
        {
            object[] array = V.v[values[0].ToString()] as object[];
            foreach (var v in V.vn)
            {
                if (values[1].ToString() == v)
                {
                    object a = (object)V.v[v].ToString();
                    values[1] = a;
                }
                if (values[2].ToString() == v)
                {
                    object a = (object)V.v[v].ToString();
                    values[2] = a;
                }
            }
            array[values[1].ToInt32()] = values[2]; 
        }
    }
}
