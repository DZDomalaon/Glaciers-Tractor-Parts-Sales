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
    public partial class unpaidForm : Form
    {
        public unpaidForm()
        {
            InitializeComponent();
        }
        public static homeForm fromUnpaid { get; set; }
        private void unpaidForm_Load(object sender, EventArgs e)
        {

        }

        private void unpaidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromUnpaid.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromUnpaid.Show();
        }
    }
}
