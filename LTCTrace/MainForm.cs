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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xbtn_Click(object sender, EventArgs e)
        {
            exitBtn_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new formSample(this);
            frm.Show();
        }

        public static bool CloseCancel()
        {
            const string message = "Biztosan be akarod zárni az alkalmazást?";
            const string caption = "Kilépés";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    if (CloseCancel() == false)
        //    {
        //        e.Cancel = true;
        //    };
        }
    }
}
