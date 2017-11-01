using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Order_Details : Form
    {
        public int cid,wid;
        public String cname="";
        public Order_Details(int a, String n,int w)
        {
            InitializeComponent();
            cid = a;
            cname = n;
            wid = w;
            label7.Text = cid.ToString();
            label8.Text = cname;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void SetButton()
        {
            button1.Enabled = (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SetButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "insert into orders values(" + Int32.Parse(textBox1.Text) + ",sysdate," + cid + ",'" + cname + "'," + Int32.Parse(textBox2.Text) + "," + Int32.Parse(textBox3.Text) + "," + Int32.Parse(textBox4.Text) + "," + 0 + ")";
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            String del = "delete from customer where cid="+cid;
            OleDbConnection obj1 = new OleDbConnection(connection);
            try
            {
                obj1.Open();
                OleDbCommand cm3 = new OleDbCommand(query, obj1);
                cm3.ExecuteNonQuery();
                obj1.Close();
                obj1.Open();
                OleDbCommand cm2 = new OleDbCommand(del, obj1);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Order taken successfully");
                obj1.Close();

                Waiter w = new Waiter(wid);
                w.Show();
                this.Hide();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
