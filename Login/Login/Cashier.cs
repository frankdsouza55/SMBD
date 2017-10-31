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
            string fetch = "select * from employee where eid =" + a;
            String years_of_experience = "select years_of_experience from cashier where eid =" + a;
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;

                //OleDbCommand cm3 = new OleDbCommand(years_of_experience, obj1);
                //cm3.ExecuteNonQuery();
                //OleDbDataAdapter da1 = new OleDbDataAdapter(years_of_experience, obj1);
                //DataSet dset = new DataSet();
                //da1.Fill(dset, "waiter");
                //label3.Text = dset.Tables["waiter"].Rows[0]["years_of_experience"].ToString();

                button2.Enabled = true;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogIn x = new LogIn();
            x.Show();
            this.Hide();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
