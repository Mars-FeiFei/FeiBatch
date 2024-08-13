using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Using
{
    public class FileStreamWriter : BasicType
    {
        public FileStreamWriter()
        {
        }
        public override void Method(object[] values)
        {
            File.AppendAllText(values[0].ToString(), values[1].ToString());
        }
    }
}
