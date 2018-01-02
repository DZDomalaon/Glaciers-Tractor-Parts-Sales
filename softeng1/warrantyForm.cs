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
            MySqlCommand comm =
                new MySqlCommand(
                    "SELECT firstname, lastname, warranty, product_name, status FROM person, inventory WHERE firstname LIKE '%" +
                    nameTxt.Text + "%' or lastname LIKE '%" + nameTxt.Text + "%' AND person_type = 'CUSTOMER'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            IsExpired();
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
            IsExpired();

            String query =
                "SELECT firstname, lastname, warranty, product_name, status FROM person, inventory, customer WHERE person_type = 'CUSTOMER' and person_id = customer_person_id";
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
            warrantyData.Columns["status"].HeaderText = "Status";
        }

        private void sDate_Click(object sender, EventArgs e)
        {
            IsExpired();
            String date = wDate.Text;
            String query =
                "SELECT firstname, lastname, warranty, product_name, status FROM person, inventory WHERE person_type = 'CUSTOMER' AND warranty LIKE '%" +
                date + "%'";

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
            warrantyData.Columns["status"].HeaderText = "Status";
        }
        public void IsExpired()
        {
            //DataTable dt = new DataTable();
            //foreach (DataRow row in dt.Rows)
            //{
                var now = DateTime.Now;
                DateTime warrDate = DateTime.Parse(wDate.Text);
                if (now > warrDate)
                {
                    String query = "UPDATE inventory SET status = 'Expired'";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();

                    DataTable dtTable = new DataTable();
                    adp.Fill(dtTable);
                }
                else
                {
                    String query = "UPDATE inventory SET status = 'Can avail'";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();

                    DataTable dtTable = new DataTable();
                    adp.Fill(dtTable);
                }
            //}
        }
    }
}

