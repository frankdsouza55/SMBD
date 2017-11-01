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
    public partial class Waiter : Form
    {
        public int eid;
        public Waiter(int abc)
        {
            InitializeComponent();
            eid = abc;
            string a = eid.ToString();
            if (eid == 200)
                panel1.Visible = true;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select e.eid,e.ename,e.join_date,w.rating from employee e,waiter w where e.eid=w.eid AND e.eid =" + a;
            //String rating = "select rating from waiter where eid =" + a;
            String cust = "select * from customer";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);           //Fill the details
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                obj1.Close();

                obj1.Open();
                OleDbCommand cm3 = new OleDbCommand(cust, obj1);           //Fill the customer table
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da1 = new OleDbDataAdapter(cust, obj1);
                DataTable d1 = new DataTable();
                da1.Fill(d1);
                dataGridView2.DataSource = d1;

                //OleDbCommand cm3 = new OleDbCommand(rating, obj1);
                //cm3.ExecuteNonQuery();
                //OleDbDataAdapter da1 = new OleDbDataAdapter(rating, obj1);
                //DataSet dset = new DataSet();
                //da1.Fill(dset, "waiter");
                //label3.Text = dset.Tables["waiter"].Rows[0]["rating"].ToString();
                
                button2.Enabled = true;
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                button4.Enabled = true;
        }
    }
}
