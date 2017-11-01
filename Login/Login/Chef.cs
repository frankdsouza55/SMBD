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
        public Chef(int id)
        {
            InitializeComponent();
            eid = id;
            string a = eid.ToString();
            if (eid == 100)
                panel1.Visible = true;
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select e.eid,e.ename,e.join_date,c.specialty from employee e,chef c where e.eid=c.eid AND e.eid =" + a;
            //String speciality = "select speciality from chef where eid =" + a;
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;

                //OleDbCommand cm3 = new OleDbCommand(speciality, obj1);
                //cm3.ExecuteNonQuery();
                //OleDbDataAdapter da1 = new OleDbDataAdapter(speciality, obj1);
                //DataSet dset = new DataSet();
                //da1.Fill(dset, "waiter");
                //label3.Text = dset.Tables["waiter"].Rows[0]["speciality"].ToString();

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

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Chef_Load(object sender, EventArgs e)
        {

        }
    }
}
