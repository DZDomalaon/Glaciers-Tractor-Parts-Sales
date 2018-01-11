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
        private void purchasingForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");

            loadPurchase();
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
        public void loadPurchase()
        {
            String query = "select * from purchase";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["purchase_id"].Visible = false;
            purchaseData.Columns["purchase_emp_id"].HeaderText = "Employee";
            purchaseData.Columns["purchase_supplier_id"].HeaderText = "Supplier";
            purchaseData.Columns["purchase_date"].HeaderText = "Purchase Date";
            purchaseData.Columns["product_name"].HeaderText = "Product Name";
            purchaseData.Columns["quantity"].HeaderText = "Quantity";
            purchaseData.Columns["price"].HeaderText = "Price";
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
                    "('" + selected_emp_id + "', '" + selected_supplier_id + "','" + pnameTxt.Text + "','" + ptotal.Text + "','" + pquant.Text + "','" + dateLbl.Text + "')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadPurchase();

                usernameLbl.Text = "";
                snameTxt.Text = "";
                pnameTxt.Text = "";
                ptotal.Text = "";
                pquant.Text = "";
                dateLbl.Text = "";
            }
        }
        public static int quant;
        public static double tot, p, q;

        private void searchBtn_Click(object sender, EventArgs e)
        {
            spanel.Enabled = true;
            spanel.Visible = true;
            spanel.Location = new Point(140, 56);
            spanel.Size = new Size(681, 297);

            String query = "SELECT supplier_id, contact_person, organization FROM supplier where (contact_person like '%" + snameTxt.Text + "%' or contact_person like '%" + snameTxt.Text + "%')";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsname.DataSource = dt;

            dgsname.Columns["supplier_id"].Visible = false;
            dgsname.Columns["contact_person"].HeaderText = "Name";
            dgsname.Columns["organization"].HeaderText = "Organization";
        }

        public static int supplier_id;
        public static String name;
        private int selected_emp_id, selected_supplier_id;
        private void purchaseData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected_emp_id = int.Parse(purchaseData.Rows[e.RowIndex].Cells["purchase_emp_id"].Value.ToString());
                selected_supplier_id = int.Parse(purchaseData.Rows[e.RowIndex].Cells["purchase_supplier_id"].Value.ToString());
                pnameTxt.Text = purchaseData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                ptotal.Text = purchaseData.Rows[e.RowIndex].Cells["price"].Value.ToString();
                pquant.Text = purchaseData.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                dateLbl.Text = purchaseData.Rows[e.RowIndex].Cells["purchase_date"].Value.ToString();
            }
        }

        private void dgsearchname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                name = dgsname.Rows[e.RowIndex].Cells["contact_person"].Value.ToString();
                snameTxt.Text = name;

                spanel.Enabled = false;
                spanel.Visible = false;
                spanel.Location = new Point(434, 85);
                spanel.Size = new Size(521, 44);
            }
        }

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
