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
    public partial class Waiter : Form
    {
        public int eid;
        public Waiter(int abc)
        {
            InitializeComponent();
            eid = abc;
            if (eid == 200)
                panel1.Visible = true;
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
    }
}
