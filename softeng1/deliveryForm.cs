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
    public partial class deliveryForm : Form
    {
        public deliveryForm()
        {
            InitializeComponent();
        }
        public static homeForm fromDelivery { get; set; }
        private void deliveryForm_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromDelivery.Show();
        }

        private void deliveryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromDelivery.Show();
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromDelivery.Show();
            this.Hide();
        }

        private void deliveryForm_Load_1(object sender, EventArgs e)
        {

        }

        private void deliveryForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromDelivery.Show();
        }
    }
}
