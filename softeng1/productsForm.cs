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
    public partial class productsForm : Form
    {
        public productsForm()
        {
            InitializeComponent();
        }
        public static homeForm fromProduct { get; set; }
        private void productsForm_Load(object sender, EventArgs e)
        {

        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromProduct.Show();
        }
        private void productsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromProduct.Show();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromProduct.Show();
            this.Show();
        }

        private void productsForm_Load_1(object sender, EventArgs e)
        {

        }

        private void productsForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromProduct.Show();
        }
    }
}
