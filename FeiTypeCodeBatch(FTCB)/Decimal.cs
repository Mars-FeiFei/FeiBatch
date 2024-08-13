using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class Decimal : BasicType
    {
        public Decimal() { }
        public override object GetVarCore(string value)
        {
            return decimal.Parse(value);
        }
    }
}
