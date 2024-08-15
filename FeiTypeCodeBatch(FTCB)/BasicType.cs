using FeiTypeCodeBatch_FTCB_;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Using
{
    public abstract class BasicType
    {
        /// <summary>
        /// Get the value of type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object GetVar(string value)
        {
            try
            {
                return GetVarCore(value);
            }
            catch(Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Get the var of type core.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual object GetVarCore(string value) { return null; }
        /// <summary>
        /// Not return method(c# class).
        /// </summary>
        /// <param name="values"></param>
        public virtual void Method(object[] values) { }
        /// <summary>
        /// Has return method(c# class).
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual object MethodReturn(object[] values) { return new object(); }
    }
}
