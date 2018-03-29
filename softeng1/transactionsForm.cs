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
    public partial class transactionsForm : Form
    {
        public transactionsForm()
        {
            InitializeComponent();
        }
        public static homeForm fromTransactions { get; set; }
        private void transactionsForm_Load(object sender, EventArgs e)
        {

        }
        private void ctransBtn_Click(object sender, EventArgs e)
        {
            ctransactionsForm cust = new ctransactionsForm();
            cust.Show();
            this.Hide();
        }

        private void stransBtn_Click(object sender, EventArgs e)
        {
            ptransactionsForm purchase = new ptransactionsForm();
            purchase.Show();
            this.Hide();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromTransactions.Show();
        }
        private void transactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            fromTransactions.Show();
        }
    }
}
