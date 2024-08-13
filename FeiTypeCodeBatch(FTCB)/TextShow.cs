using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeiTypeCodeBatch_FTCB_
{
    public partial class TextShow : Form
    {
        public Button btnShow = Button.CANCEL;
        public TextShow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnShow = Button.OK;
            Close();
        }
        public void Show(string text)
        {
            label1.Text = text+"(Click 'OK' button mean yes,otherwise mean no.)";
            base.Show();
        }
    }
    public enum Button
    {
        OK,
        CANCEL
    }
}
