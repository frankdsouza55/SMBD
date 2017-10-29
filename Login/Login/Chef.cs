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
    public partial class Chef : Form
    {
        public int eid;
        public Chef(int id)
        {
            InitializeComponent();
            eid = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn x = new LogIn();
            x.Show();
            this.Hide();
        }

        private void Chef_Load(object sender, EventArgs e)
        {

        }
    }
}
