using FeiTypeCodeBatch_FTCB_;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Using
{
    public abstract class BasicType
    {
        public object GetVar(string value)
        {
            try
            {
                return GetVarCore(value);
            }
            catch(Exception ex)
            {
                Form1 f = new Form1();
                f.label2.Text = "Error:" + ex.Source + ":" + ex.ToString() + "Stack:" + ex.StackTrace;
                return null;
            }
        }
        public virtual object GetVarCore(string value) { return null; }
        public virtual void Method(object[] values) { }
        public virtual object MethodReturn(object[] values) { return new object(); }
    }
}
