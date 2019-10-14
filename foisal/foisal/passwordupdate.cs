using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace foisal
{
    public partial class passwordupdate : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\foisal\foisal\foisal\nahid.accdb");
        public passwordupdate()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            log_blood_taker taker = new log_blood_taker();
            taker.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = " update Table1 set  Password = '" + u_pass.Text + "'  where Phone = '" + u_p.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Donor information updated successful.");
            con.Close();
            u_pass.Text = "";
            
            u_p.Text = "";

        }
    }
}
