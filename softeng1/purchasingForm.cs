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
using Microsoft.VisualBasic;

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
            
            /*purchaseDG.Columns.Add("Product Name", "Product Name");
            purchaseDG.Columns.Add("Quantity", "Quantity");
            purchaseDG.Columns.Add("Price", "Price");
            purchaseDG.Columns.Add("Date", "Date");
            purchaseDG.Columns.Add("Employee", "Employee");
            purchaseDG.Columns.Add("Supplier", "Supplier");*/
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

            purchaseDG.DataSource = dt;

            purchaseDG.Columns["purchase_id"].Visible = false;
            purchaseDG.Columns["purchase_date"].HeaderText = "Purchase Date";
            purchaseDG.Columns["product_name"].HeaderText = "Product Name";
            purchaseDG.Columns["quantity"].HeaderText = "Quantity";
            purchaseDG.Columns["price"].HeaderText = "Price";
            purchaseDG.Columns["purchase_emp_id"].HeaderText = "Employee";
            purchaseDG.Columns["purchase_supplier_id"].HeaderText = "Supplier";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            /*if (pname.Text == "" || priceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "" || snameTxt.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Purchased Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query =
                    "INSERT INTO purchase(purchase_emp_id, purchase_supplier_id, product_name, quantity, price, purchase_date) VALUES" +
                    "('" + loginForm.user_id + "','"+ supplier_id + "','" + pname.Text + "','" + pquant.Text + "','" + ptotal.Text + "','" + dateLbl.Text + "')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadPurchase();

                usernameLbl.Text = "";
                snameTxt.Text = "";
                pname.Text = "";
                ptotal.Text = "";
                pquant.Text = "";
                dateLbl.Text = "";*/
                if (pname.Text == "" || pquant.Text == "" || ptotal.Text == "" || usernameLbl.Text == "" || snameTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all the data", "Add Purchase Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string firstColumn = pname.Text;
                    string secondColumn = pquant.Text;
                    string thirdColumn = ptotal.Text;
                    string fourthColumn = snameTxt.Text;
                    string fifthColumn = usernameLbl.Text;
                    string sixthColumn = DateTime.Now.Date.ToString();
                    string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn, fifthColumn, sixthColumn };

                    purchaseDG.Rows.Add(row);

                    pname.Clear();
                    pquant.Clear();
                    ptotal.Clear();
                    snameTxt.Clear();
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
        public static int rowIndex;
        private void purchaseData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex > -1)
            {
                //selected_supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                pname.Text = dgsname.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            prodpanel.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Location = new Point(434, 152);
            prodpanel.Size = new Size(521, 44);

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
        private void pnameTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sort = pname.Text;
            

            String query = "SELECT * FROM products WHERE client_name LIKE '%" + sort + "' ";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
        }

        private void pnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private void purchaseDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            DataGridViewRow row = purchaseDG.Rows[rowIndex];

            pname.Text = row.Cells[1].Value.ToString();
            pquant.Text = row.Cells[2].Value.ToString();
            ptotal.Text = row.Cells[3].Value.ToString();
            dateLbl.Text = row.Cells[4].Value.ToString();
            usernameLbl.Text = row.Cells[5].Value.ToString();
            snameTxt.Text = row.Cells[6].Value.ToString();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.purchaseDG.SelectedRows)
            {
                purchaseDG.Rows.RemoveAt(item.Index);
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
