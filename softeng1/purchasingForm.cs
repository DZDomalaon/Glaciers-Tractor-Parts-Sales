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
using System.Text.RegularExpressions;

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
            datetime.Value = DateTime.Now;
            loadPurchase();
            loadproducts();
            pnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pnameTxt.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        public void loadproducts()
        {
            prodpanel.Enabled = true;
            prodpanel.Visible = true;
            prodpanel.Location = new Point(140, 56);
            prodpanel.Size = new Size(681, 297);

            String query = "SELECT * FROM inventory";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsearchprod.DataSource = dt;

            dgsearchprod.Columns["product_id"].Visible = false;
            dgsearchprod.Columns["product_name"].HeaderText = "Product Name";
            dgsearchprod.Columns["price"].HeaderText = "Price";
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


        //private SqlDataAdapter adapt;

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
            //purchaseData.Columns["price"].HeaderText = "Price";
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
                    "INSERT INTO purchase(purchase_emp_id, purchase_supplier_id, product_name, quantity, purchase_date) VALUES" +
                    "('" + loginForm.user_id + "','"+ supplier_id + "','" + pnameTxt.Text + "','" + pquant.Text + "','" + datetime.Text + "')";

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

            String query = "SELECT supplier_id, contact_person, organization FROM supplier, person where (contact_person like '%" + snameTxt.Text + "%' or contact_person like '%" + snameTxt.Text + "%') and person_type = 'Supplier' and supplier_person_id = person_id";
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
        private int selected_supplier_id;

        private void purchaseData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex > -1)
            {
                //selected_supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                pnameTxt.Text = dgsname.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                ptotal.Text = dgsname.Rows[e.RowIndex].Cells["price"].Value.ToString();
                pquant.Text = dgsname.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                dateLbl.Text = dgsname.Rows[e.RowIndex].Cells["purchase_date"].Value.ToString();
            }
            */
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

        private void closename_Click(object sender, EventArgs e)
        {
            spanel.Enabled = false;
            spanel.Visible = false;
            spanel.Location = new Point(434, 85);
            spanel.Size = new Size(521, 44);
        }
        

        private void dgsearchprod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static int product_id;
        private void dgsearchprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product_id = int.Parse(dgsearchprod.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
            pnameTxt.Text = dgsearchprod.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
            dgsearchprod.Rows[e.RowIndex].Cells["description"].Value.ToString();
            priceTxt.Text = dgsearchprod.Rows[e.RowIndex].Cells["price"].Value.ToString();
           // pnameTxt.Text = prod;
           // ppriceTxt.Text = price;
            prodpanel.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Location = new Point(434, 152);
            prodpanel.Size = new Size(521, 44);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prodpanel.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Location = new Point(434, 152);
            prodpanel.Size = new Size(521, 44);

        }

        private void purchaseData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void priceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(priceTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void pnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(pnameTxt.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
                pnameTxt.Text.Remove(pnameTxt.Text.Length - 1);
            }
        }

        private void pnameTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sort = pnameTxt.Text;
            

            String query = "SELECT * FROM products WHERE client_name LIKE '%" + sort + "' ";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
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
