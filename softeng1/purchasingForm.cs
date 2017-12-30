using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace softeng1
{
    public partial class purchasingForm : Form
    {
        MySqlConnection conn;
        public purchasingForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromPurchasing { get; set; }
        private void purchasingForm_Load(object sender, EventArgs e)
        {
            userTxt.Text = loginForm.name;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromPurchasing.Show();
        }

        private void purchasingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromPurchasing.Show();
        }
    }
}
