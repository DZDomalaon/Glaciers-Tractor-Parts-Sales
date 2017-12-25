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
    public partial class warrantyForm : Form
    {
        public warrantyForm()
        {
            InitializeComponent();
        }
        public static homeForm fromWarranty { get; set; }
        private void warrantyForm_Load(object sender, EventArgs e)
        {

        }

        private void warrantyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromWarranty.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromWarranty.Show();
        }
    }
}
