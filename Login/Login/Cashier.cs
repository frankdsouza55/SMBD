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
    public partial class Cashier : Form
    {
        public int eid;
        public String a1 = "select oid,order_date,cid,did,quantity from orders where finished = 2";
        private void sync()
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            OleDbCommand cm3 = new OleDbCommand(a1, obj1);
            cm3.ExecuteNonQuery();
            OleDbDataAdapter da1 = new OleDbDataAdapter(a1, obj1);
            DataTable d1 = new DataTable();
            da1.Fill(d1);
            dataGridView2.DataSource = d1;
            obj1.Close();

            String q1="select sum(amount) as sum from prepares_bill where oid IN ( select distinct oid from orders where extract(day from order_date) = extract(day from sysdate))";
            obj1.Open();                                                   //update earnings
            OleDbCommand cm1 = new OleDbCommand(q1, obj1);
            cm1.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(q1, obj1);
            DataSet dset1 = new DataSet();
            da.Fill(dset1, "prepares_bill");
            label5.Text = dset1.Tables["prepares_bill"].Rows[0]["sum"].ToString();
            obj1.Close();
        }
        public Cashier(int id)
        {
            InitializeComponent();
            eid = id;
            string a = eid.ToString();
            if (eid == 300)
                panel1.Visible = true;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            String fetch = "select e.eid,e.ename,e.join_date,c.years_of_experience from employee e,cashier c where e.eid=c.eid AND e.eid =" + a;
            //String years_of_experience = "select years_of_experience from cashier where eid =" + a;
            
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                obj1.Close();

                sync();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Logout_Click(object sender, EventArgs e)       //logout button
        {
            LogIn x = new LogIn();
            x.Show();
            this.Hide();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)      //Insert button
        {
            Insert obj = new Insert(eid);
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)      //delete button
        {
            Delete obj = new Delete(eid);
            this.Hide();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int amt, price, qty, did, cid;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String q1 = "select did from orders where oid=" + Int32.Parse(textBox1.Text);
            String q2 = "select quantity from orders where oid=" + Int32.Parse(textBox1.Text);
            String q4 = "select cid from orders where oid=" + Int32.Parse(textBox1.Text);
            try
            {
                obj1.Open();                                                   //get dish id
                OleDbCommand cm1 = new OleDbCommand(q1, obj1);
                cm1.ExecuteNonQuery();
                OleDbDataAdapter da1 = new OleDbDataAdapter(q1, obj1);
                DataSet dset1 = new DataSet();
                da1.Fill(dset1, "orders");
                did = Int32.Parse(dset1.Tables["orders"].Rows[0]["did"].ToString());
                obj1.Close();

                String q3 = "select price from dish where did=" + did;

                obj1.Open();                                                //get quantity
                OleDbCommand cm2 = new OleDbCommand(q2, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da2 = new OleDbDataAdapter(q2, obj1);
                DataSet dset2 = new DataSet();
                da2.Fill(dset2, "orders");
                qty = Int32.Parse(dset2.Tables["orders"].Rows[0]["quantity"].ToString());
                obj1.Close();

                obj1.Open();                                                //get price
                OleDbCommand cm3 = new OleDbCommand(q3, obj1);
                cm3.ExecuteNonQuery();
                OleDbDataAdapter da3 = new OleDbDataAdapter(q3, obj1);
                DataSet dset3 = new DataSet();
                da3.Fill(dset3, "dish");
                price = Int32.Parse(dset3.Tables["dish"].Rows[0]["price"].ToString());
                obj1.Close();

                obj1.Open();                                                //get customer id
                OleDbCommand cm4 = new OleDbCommand(q4, obj1);
                cm4.ExecuteNonQuery();
                OleDbDataAdapter da4 = new OleDbDataAdapter(q4, obj1);
                DataSet dset4 = new DataSet();
                da4.Fill(dset4, "orders");
                cid = Int32.Parse(dset4.Tables["orders"].Rows[0]["cid"].ToString());
                obj1.Close();

                amt = price * qty;

                String insrt = "insert into prepares_bill values(" + eid + "," + cid + "," + Int32.Parse(textBox1.Text) + "," + amt + ")";
                obj1.Open();                                                //insert into prepares_bill
                OleDbCommand cm5 = new OleDbCommand(insrt, obj1);
                cm5.ExecuteNonQuery();
                obj1.Close();

                sync();

                String updt = "update orders set finished = 3 where oid=" + Int32.Parse(textBox1.Text);
                obj1.Open();                                                //insert into prepares_bill
                OleDbCommand cm7 = new OleDbCommand(updt, obj1);
                cm7.ExecuteNonQuery();
                obj1.Close();

                MessageBox.Show("Bill prepared successfully");
                textBox1.Clear();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
