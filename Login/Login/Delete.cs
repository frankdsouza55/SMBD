using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Delete : Form
    {
        public int eid;
        public Delete(int id)
        {
            InitializeComponent();
            eid = id;
            string a = id.ToString();
            label3.Text = a;
            if (eid == 200)
            {
                label5.Text = "Waiter";
            }
            else if (eid == 300)
            {
                label5.Text = "Cashier";
            }
            else if (eid == 100)
            {
                label5.Text = "Chef";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from employee where eid =" + textBox1.Text;
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                button2.Enabled = true;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string delete = "delete from employee where eid = " + textBox1.Text;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            try
            {
                if (eid == 200)                                                     //delete from tables which references from employye table first
                {
                    string w = "delete from waiter where eid = " + textBox1.Text;
                    OleDbCommand a1 = new OleDbCommand(w, obj1);
                    a1.ExecuteNonQuery();
                }
                else if (eid == 300)
                {
                    string c = "delete from cashier where eid = " + textBox1.Text;
                    OleDbCommand a1 = new OleDbCommand(c, obj1);
                    a1.ExecuteNonQuery();
                }
                else if (eid == 100)
                {
                    string ch = "delete from chef where eid = " + textBox1.Text;
                    OleDbCommand a1 = new OleDbCommand(ch, obj1);
                    a1.ExecuteNonQuery();
                }
                OleDbCommand cm2 = new OleDbCommand(delete, obj1);              //delete from employee table
                cm2.ExecuteNonQuery();
                textBox1.Clear();
                button2.Enabled = false;
                MessageBox.Show("Record Delete");
                String q1 = "select * from employee";

                OleDbDataAdapter da = new OleDbDataAdapter(q1, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                obj1.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (eid == 200)
            {
                Waiter w = new Waiter(eid);
                this.Close();
                w.Show();
            }
            else if (eid == 300)
            {
                Cashier c = new Cashier(eid);
                this.Close();
                c.Show();
            }
            else if (eid == 100)
            {
                Chef ch = new Chef(eid);
                this.Close();
                ch.Show();
            }
        }
    }
}
