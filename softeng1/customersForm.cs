using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softeng1
{
    public partial class customersForm : Form
    {
        public customersForm()
        {
            InitializeComponent();
        }
        public static homeForm fromCustomer { get; set; }
        private void customersForm_Load(object sender, EventArgs e)
        {

        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromCustomer.Show();
        }
        private void customersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void customersForm_Load_1(object sender, EventArgs e)
        {

        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromCustomer.Show();
            this.Hide();
        }

        private void customersForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }
    }
}
