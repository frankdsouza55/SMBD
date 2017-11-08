using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Airline_Reservation_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=SYSTEM;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();

            String q1="Select * from " + textBox3.Text + " where boarding_from='"+ textBox1.Text +"' and destination='"+textBox2.Text+"';";

            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(q1, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            obj1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=SYSTEM;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();

            String q1 = "select p.pid,p.pname,p.address,p.age from PASSENGER p, RESERVATION r, FLIGHT f where p.pid=r.pid and r.fid=f.fid and boarding_from='" + textBox1.Text + "' and destination='" + textBox2.Text + "';";

            OleDbDataAdapter da = new OleDbDataAdapter(q1, obj1);
            DataTable d = new DataTable();
            da.Fill(d);
            dataGridView1.DataSource = d;
            obj1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
