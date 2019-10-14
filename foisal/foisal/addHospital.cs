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
    public partial class addHospital : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\foisal\foisal\foisal\nahid.accdb");
        int count = 0;
        public addHospital()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from Table2 ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_show a_s = new Admin_show();
            a_s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table2 values('" + name.Text + "','" + location.Text + "','" + phone.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Hospital information inserted.");
            name.Text = "";
            location.Text = "";
            phone.Text = "";
        }

        private void search_Click(object sender, EventArgs e)
        {
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " delete from Table2 where Phone = '" + pnumber.Text + "' ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Hospital deletion successful.");
            con.Close();
        }
    }
}
