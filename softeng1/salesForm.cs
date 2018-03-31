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
    public partial class salesForm : Form
    {
        public salesForm()
        {
            InitializeComponent();
        }
        public static homeForm fromSales { get; set; }
        private void salesForm_Load(object sender, EventArgs e)
        {

        }

        private void salesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromSales.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            fromSales.Show();            
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromSales.Show();
            this.Hide();
        }

        private void salesForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromSales.Show();
        }
    }
}
