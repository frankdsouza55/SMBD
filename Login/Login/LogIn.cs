using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Login
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            int x = Int32.Parse(textBox1.Text);
            if (x>=100 && x <200 && textBox2.Text =="chef")
            {
                Chef obj1 = new Chef(x);
                obj1.Show();
            }
            else if (x>=200 && x < 300 && textBox2.Text == "waiter")
            {
                Waiter obj2 = new Waiter(x);
                obj2.Show();
            }
            else if (x >= 300 && x < 400 && textBox2.Text == "cashier")
            {
                Cashier obj3 = new Cashier(x);
                obj3.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username  or password");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer obj4 = new Customer();
            obj4.Show();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
