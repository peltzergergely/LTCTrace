using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTCTrace
{
    public partial class formSample : Form
    {
        Form opener;

        public formSample(Form parentForm) //form opener
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xbtn_Click(object sender, EventArgs e)
        {
            exitBtn_Click(sender, e);
        }
    }
}
