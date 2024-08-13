using FeiTypeCodeBatch_FTCB_;
using System.Windows.Forms;

namespace Using
{
    public class Print : BasicType
    {
        public Print() { }
        public override void Method(object[] values)
        {
            MessageBox.Show(values[0].ToString());
        }
    }
}
