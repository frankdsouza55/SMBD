using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Airline_Reservation_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "test" && textBox2.Text == "test")
            {
                this.Hide();
                Form2 obj = new Form2();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
