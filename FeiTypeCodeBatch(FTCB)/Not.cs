﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    /// <summary>
    /// Not char
    /// </summary>
    public class Not : BasicType
    {
        public Not()
        {
        }
        public override object MethodReturn(object[] values)
        {
            return !values[0].ToBool();
        }
    }
}
