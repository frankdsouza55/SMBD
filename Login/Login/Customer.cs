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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            label3.Visible = true;              //Comment this line to hide the message

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from dish";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn x = new LogIn();
            x.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)                  //Function to view the menu
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from dish";
            if (comboBox1.Text == "Veg")
                fetch = "select * from (select * from dish where category='Veg')";
            else if (comboBox1.Text == "Non-Veg")
                fetch = "select * from (select * from dish where category='Non-Veg')";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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

        private void button5_Click(object sender, EventArgs e)                  //Function to view all drinks
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from dish where type='Drinks'";
            if (comboBox1.Text == "Veg")
                fetch = "select * from (select * from dish where category='Veg') where type='Drinks'";
            else if (comboBox1.Text == "Non-Veg")
                fetch = "select * from (select * from dish where category='Non-Veg') where type='Drinks'";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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
        
        private void button2_Click(object sender, EventArgs e)              //Function to view starters
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from dish where type='Starters'";
            if (comboBox1.Text == "Veg")
                fetch = "select * from (select * from dish where category='Veg') where type='Starters'";
            else if (comboBox1.Text == "Non-Veg")
                fetch = "select * from (select * from dish where category='Non-Veg') where type='Starters'";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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

        private void button3_Click(object sender, EventArgs e)              //Function to view the main course
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            String fetch = "select * from dish where type='Main Course'";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                if(comboBox1.Text=="Veg")
                    fetch = "select * from (select * from dish where category='Veg') where type='Main Course'";
                else if(comboBox1.Text=="Non-Veg")
                    fetch = "select * from (select * from dish where category='Non-Veg') where type='Main Course'";
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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

        private void button4_Click(object sender, EventArgs e)              //Function to view the dessert
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            string fetch = "select * from dish where type='Dessert'";
            if (comboBox1.Text == "Veg")
                fetch = "select * from (select * from dish where category='Veg') where type='Dessert'";
            else if (comboBox1.Text == "Non-Veg")
                fetch = "select * from (select * from dish where category='Non-Veg') where type='Dessert'";
            try
            {
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(fetch, obj1);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button7.Enabled = false;
            else
                button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String f1 = "select max(cid) as cid from customer";
            try
            {
                obj1.Open();
                OleDbCommand cm3 = new OleDbCommand(f1, obj1);
                cm3.ExecuteNonQuery();
                OleDbDataAdapter da1 = new OleDbDataAdapter(f1, obj1);
                DataSet dset = new DataSet();
                da1.Fill(dset, "customer");
                int id = Int32.Parse(dset.Tables["customer"].Rows[0]["cid"].ToString());        //get last id
                id++;
                Console.Write(id);
                String insrt = "insert into customer values(" + id + ",'" + textBox1.Text + "')";
                OleDbCommand cm1 = new OleDbCommand(insrt, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Kindly wait till a waiter arrives!");

                obj1.Close();
                textBox1.Clear();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
