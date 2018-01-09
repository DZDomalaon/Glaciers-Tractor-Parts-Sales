﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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
        public string ConnString { get; private set; }

        private void purchasingForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");

            purchaseData.Columns.Add("Employee", "Employee");
            purchaseData.Columns.Add("Supplier Name", "Supplier Name");
            purchaseData.Columns.Add("Product Name", "Product Name");
            purchaseData.Columns.Add("Price", "Price");
            purchaseData.Columns.Add("Quantity", "Quantity");
            purchaseData.Columns.Add("Sub Total", "Sub Total");
            purchaseData.Columns.Add("Date", "Date");
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
        private SqlDataAdapter adapt;

        public void loadPurchase()
        {
            conn.Open();
            DataTable dt = new DataTable();

            string query = "select * from purchase";
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adapt.Fill(dt);
            purchaseData.DataSource = dt;
            conn.Close();
            /*String query =
                "SELECT * FROM purchase, supplier, employee WHERE purchase.purchase_supplier_id = supplier.supplier_id AND purchase.purchase_emp_id = employee.emp_id";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;
            purchaseData.Columns["purchase_id"].Visible = false;
            purchaseData.Columns["purchase_supplier_id"].Visible = false;
            purchaseData.Columns["purchase_emp_id"].Visible = false;
            purchaseData.Columns["purchase_date"].HeaderText = "Purchase Date";
            purchaseData.Columns["product_name"].HeaderText = "Product Name";
            purchaseData.Columns["quantity"].HeaderText = "Quantity";
            purchaseData.Columns["price"].HeaderText = "Price";*/
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (pnameTxt.Text == "" || priceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "" || snameTxt.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Purchased Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query =
                    "INSERT INTO purchase(purchase_emp_id, purchase_supplier_id, product_name, price, quantity, purchase_date) VALUES" +
                    "('" + usernameLbl.Text + "','" + (snameTxt.Text) + "','" + pnameTxt.Text + "','" + ptotal.Text + "','" + pquant.Text + "','" + dateLbl.Text + "')";

                MySqlCommand comm = new MySqlCommand(query, conn);
                conn.Open();

                /*comm.Parameters.AddWithValue("purchase_emp_id", int.Parse(usernameLbl.Text));
                comm.Parameters.AddWithValue("purchase_supplier_id", int.Parse(snameTxt.Text));
                comm.Parameters.AddWithValue("product_name", pnameTxt.Text);
                comm.Parameters.AddWithValue("price", ptotal.Text);
                comm.Parameters.AddWithValue("quantity", pquant.Text);
                comm.Parameters.AddWithValue("purchase_date", dateLbl.Text);*/

                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record Inserted Successfully");

                loadPurchase();
            }
        }
        public static int quant;
        public static double tot, p, q;

        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.purchaseData.SelectedRows)
            {
                purchaseData.Rows.RemoveAt(item.Index);
            }
        }
        private void pquant_TextChanged(object sender, EventArgs e)
        {
            if (pquant.Text != "")
            {
                quant = int.Parse(pquant.Text);
                p = double.Parse(priceTxt.Text);
                q = quant;
                tot = q * p;
                ptotal.Text = tot.ToString();
            }
            else if (pquant.Text == "")
            {
                ptotal.Text = "";
            }
        }
    }
}
