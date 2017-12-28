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
    public partial class warrantyForm : Form
    {
        MySqlConnection conn;
        public warrantyForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromWarranty { get; set; }
        private void warrantyForm_Load(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT firstname, lastname, warranty, product_name FROM person, inventory WHERE firstname LIKE '%" + nameTxt.Text + "%' or lastname LIKE '%" + nameTxt.Text + "%' AND  person_type = 'CUSTOMER'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            String query = "SELECT firstname, lastname, warranty, product_name FROM person, inventory WHERE person_type = 'CUSTOMER'";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            warrantyData.DataSource = dt;
            warrantyData.Columns["firstname"].HeaderText = "Firstname";
            warrantyData.Columns["lastname"].HeaderText = "Lastname";
            warrantyData.Columns["product_name"].HeaderText = "Product";
            warrantyData.Columns["warranty"].HeaderText = "Date";
        }
    }
}
