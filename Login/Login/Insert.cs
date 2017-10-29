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
    public partial class Insert : Form
    {
        public int eid;
        public Insert(int abc)
        {
            InitializeComponent();
            eid = abc;
            //String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            //OleDbConnection obj1 = new OleDbConnection(connection);
            //try
            {

                if (eid == 200)
                {
                    //string q = "select max(eid) from employee where job_type='Waiter';";
                    //obj1.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter(q, obj1);
                    //int x;
                    //da.Fill(x);
                    //label5.Text = "200";
                    label6.Text = "Waiter";
                    textBox2.Enabled = true;
                }
                else if (eid == 300)
                {
                    //label5.Text = "300";
                    label6.Text = "Cashier";
                    textBox4.Enabled = true;
                }
                else if (eid == 100)
                {
                    //label5.Text = "100";
                    label6.Text = "Chef";
                    textBox3.Enabled = true;
                }
            }
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=SYSTEM;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            OleDbConnection obj2 = new OleDbConnection(connection);

            string type="",query="",x="";                        //set the job type based on manager id
            if (eid == 100)
            {
                type = "Chef";
            }
            else if (eid == 200)
            {
                type = "Waiter";
                x = "insert into waiter values (" + textBox5.Text + "," + textBox2.Text + ")";
            }
            else if (eid == 300)
            {
                type = "Cashier";
            }
            
            
            query = "insert into employee values ("+ textBox5.Text + ",'" + textBox1.Text + "','" + textBox6.Text + "','" + type + "',"+eid+")";
            obj1.Open();
            obj2.Open();
            try
            {
                OleDbCommand cm1 = new OleDbCommand(query, obj1);
                cm1.ExecuteNonQuery();
                OleDbCommand cm2 = new OleDbCommand(x, obj2);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Record Insert");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            obj1.Close();
            obj2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Insert_Load(object sender, EventArgs e)
        {

        }
    }
}
