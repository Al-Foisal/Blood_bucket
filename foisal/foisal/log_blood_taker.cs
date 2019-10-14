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
    public partial class log_blood_taker : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\foisal\foisal\foisal\nahid.accdb");
        int count = 0;
        string foisal12;
        public log_blood_taker()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
             cmd.CommandText = " select Type from Table1 where Email =  '"+ email.Text +"' and Password =  '"+password.Text+"' ";
            
            OleDbDataReader reader = cmd.ExecuteReader();
            
            count = 0;
            while (reader.Read())
            {
                count++;
                string foisal12 = (string)reader["Type"];


                if (count == 1)
                {
                    if (foisal12 == "donor")
                    {
                        
                        MessageBox.Show("Donor login.");
                        //con.Close();
                        this.Hide();
                        find_donor find = new find_donor();
                        find.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Admin login.");
                        //con.Close();
                        this.Hide();
                        Admin_show admin = new Admin_show();
                        admin.Show();
                    }
                    
                }

            }
            if(count == 0)
            {
                con.Close();
                MessageBox.Show("You are not registered.");
            }
            
            //con.Close();
        }

        private void varchar(int v)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            be_a_donor donor = new be_a_donor();
            donor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            passwordupdate pass = new passwordupdate();
            pass.Show();
        }
    }

    internal class DECLARE
    {
    }
}
