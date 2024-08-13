using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Using
{
    public class NRoot : BasicType
    {
        public NRoot()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return Math.Pow(values[0].ToDouble(),1.0 / values[1].ToDouble());
        }
    }
}
