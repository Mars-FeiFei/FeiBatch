using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeiTypeCodeBatch_FTCB_;
namespace Using
{
    public class Int32 : BasicType
    {
        public Int32() { }
        public override object GetVarCore(string value)
        {
            return int.Parse(value);
        }
    }
}
