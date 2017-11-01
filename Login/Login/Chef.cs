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
    public partial class Chef : Form
    {
        public int eid;
        public String q2 = "select oid,did,quantity from orders where finished=0";
        public Chef(int id)
        {
            InitializeComponent();
            eid = id;
            string a = eid.ToString();
            if (eid == 100)
                panel1.Visible = true;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            string fetch = "select e.eid,e.ename,e.join_date,c.specialty from employee e,chef c where e.eid=c.eid AND e.eid =" + a;
            
            try
            {
                obj1.Open();
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                obj1.Close();

                obj1.Open();
                OleDbCommand cm3 = new OleDbCommand(q2, obj1);
                cm3.ExecuteNonQuery();
                OleDbDataAdapter da1 = new OleDbDataAdapter(q2, obj1);
                DataTable d1 = new DataTable();
                da1.Fill(d1);
                dataGridView2.DataSource = d1;
                obj1.Close();

                //button2.Enabled = true;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn x = new LogIn();
            x.Show();
            this.Hide();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insert obj = new Insert(eid);
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete obj = new Delete(eid);
            this.Hide();
            obj.Show();
        }


        private void Chef_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                button3.Enabled = true;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            try
            {
                obj1.Open();
                String query = "update orders set finished = 1 where oid="+ Int32.Parse(textBox1.Text);
                OleDbCommand cm3 = new OleDbCommand(query, obj1);
                cm3.ExecuteNonQuery();
                obj1.Close();

                obj1.Open();                                        // Sync available orders
                OleDbCommand cm2 = new OleDbCommand(q2, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da1 = new OleDbDataAdapter(q2, obj1);
                DataTable d1 = new DataTable();
                da1.Fill(d1);
                dataGridView2.DataSource = d1;
                obj1.Close();
                textBox1.Clear();
                MessageBox.Show("Dish prepared");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
