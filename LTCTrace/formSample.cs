using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;

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

        private void exitBtn_Click(object sender, EventArgs e) //exit btn
        {
            this.Close();
        }

        private void xbtn_Click(object sender, EventArgs e)  //exit btn
        {
            exitBtn_Click(sender, e);
        }

        private void db_insert(string table) //DB insert
        {
            try
            {
                string connstring = ConfigurationManager.ConnectionStrings["CCTrace.Properties.Settings.CCDBConnectionString"].ConnectionString;
                // Making connection with Npgsql provider
                var conn = new NpgsqlConnection(connstring);
                conn.Open();
                // building SQL query
                var cmd = new NpgsqlCommand("INSERT INTO " + table + " (prod_dm, carr_dm, timestamp) VALUES(:prod_dm, :carr_dm, :timestamp)", conn);
                //cmd.Parameters.Add(new NpgsqlParameter("prod_dm", prodTbx.Text));
                //cmd.Parameters.Add(new NpgsqlParameter("carr_dm", carrTbx.Text));
                cmd.Parameters.Add(new NpgsqlParameter("timestamp", DateTime.Now));
                cmd.ExecuteNonQuery();
                //closing connection ASAP
                conn.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
        }

        private void placeholderTextBox1_KeyUp(object sender, KeyEventArgs e)  //jumps between controls and validates
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                //if (ActiveControl == saveBtn)
                //    updateLbl(sender, e);
            }
        }

        private bool dataValid() //checks if txtbx values are legit
        {
            if (TextBox1.TextLength > 1 && TextBox2.TextLength > 1)
                return true;
            else
                return false;
        }

        private void updateLbl(object sender, EventArgs e) //updates label based on info
        {
            if (dataValid())
            {
                outputMsgLbl.ForeColor = System.Drawing.Color.Black;
                //outputMsgLbl.Text = "Az adatok megfelelőek kattints a mentés gombra!";
                //saveBtn_Click(sender, e);

            }
            else
            {
                outputMsgLbl.ForeColor = System.Drawing.Color.Red;
                outputMsgLbl.Text = "Nem megfelelő adatok!";
            }
        }
    }
}
