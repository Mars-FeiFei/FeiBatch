using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Using
{
    public class Div : BasicType
    {
        public Div()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return values[0].ToInt32() / values[1].ToInt32();
        }
    }
}
