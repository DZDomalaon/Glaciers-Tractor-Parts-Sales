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
            
            dgProducts.Columns.Add("ProductName", "Product Name");
            dgProducts.Columns.Add("Price", "Price");
            dgProducts.Columns.Add("SubTotal", "Sub Total");
            dgProducts.Columns.Add("Quantity", "Quantity");
            loadsupplier();

            

            snameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            snameTxt.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgProducts.Visible = true;           
        }
       
        public void loadsupplier()
        {
            String query = "SELECT firstname, lastname FROM person, supplier where person_id=supplier_person_id";
             


            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            snameTxt.Items.Clear();
            while (drd.Read())
            {

                snameTxt.Items.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }
            conn.Close();
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

        /*public void loadPurchase()
        {
            String query = "select * from purchase";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseDG.DataSource = dt;

            //purchaseDG.Columns["purchase_id"].Visible = false;
            purchaseDG.Columns["product_name"].HeaderText = "Product Name";

            purchaseDG.Columns["price"].HeaderText = "Price";
            purchaseDG.Columns["quantity"].HeaderText = "Quantity";
            purchaseDG.Columns["purchase_supplier_id"].HeaderText = "Supplier";
            purchaseDG.Columns["purchase_emp_id"].HeaderText = "Employee";
            purchaseDG.Columns["purchase_date"].HeaderText = "Purchase Date";
        }*/

        private void addBtn_Click(object sender, EventArgs e)
        {
            checkProduct();
            if (pname.Text != "" || priceTxt.Text != "" || pquant.Text != "" || ptotal.Text != "")
            {
                string firstColumn = pname.Text;
                string secondColumn = priceTxt.Text;
                string thirdColumn = ptotal.Text;
                string fourthColumn = pquant.Text;

                string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn };

                dgProducts.Rows.Add(row);

                pname.Clear();
                priceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();

                calcSum();
            }
            else
            {
                MessageBox.Show("Please fill up all the data", "Add Purchase Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static int quant;
        public static double tot, p, q;

        public static int rowIndex;
        private void dgsearchprod_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        //private void pnameTxt_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string sort = pname.Text;
            

        //    String query = "SELECT * FROM products WHERE client_name LIKE '%" + sort + "' ";


        //    conn.Open();
        //    MySqlCommand comm = new MySqlCommand(query, conn);
        //    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
        //    conn.Close();
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //}
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
            DataGridViewRow row = dgProducts.Rows[rowIndex];

            pname.Text = row.Cells[0].Value.ToString();
            priceTxt.Text = row.Cells[1].Value.ToString();
            ptotal.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgProducts.SelectedRows)
            {
                dgProducts.Rows.RemoveAt(item.Index);
            }
        }

        private void pname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cPanel.Hide();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            cPanel.Visible = true;
            cPanel.Enabled = true;
        }

        private void dgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            DataGridViewRow row = dgProducts.Rows[rowIndex];

            pname.Text = row.Cells[0].Value.ToString();
            priceTxt.Text = row.Cells[1].Value.ToString();
            ptotal.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updateRow = dgProducts.Rows[rowIndex];

            updateRow.Cells[0].Value = pname.Text;
            updateRow.Cells[1].Value = priceTxt.Text;
            updateRow.Cells[2].Value = ptotal.Text;
            updateRow.Cells[3].Value = pquant.Text;

            calcSum();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int maxOrderId = 0;
            int OrderIncrement = 0;
            int empId = loginForm.user_id;
            int supId;


            conn.Open();
            //Get max id from sales_order
            MySqlCommand maxIDOrder = new MySqlCommand("SELECT MAX(purchase_id) FROM purchase", conn);
            maxOrderId = Convert.ToInt16(maxIDOrder.ExecuteScalar());
            OrderIncrement = maxOrderId + 1;

            String today = DateTime.Now.Date.ToString("yyyy-MM-dd");


            MySqlCommand getSupID = new MySqlCommand("SELECT supplier_id FROM supplier, person where(CONCAT(FIRSTNAME, ' ', LASTNAME) LIKE '%" + snameTxt.Text + "%') and person_type = 'supplier' and person_id = supplier_person_id ", conn);
            supId = Convert.ToInt16(getSupID.ExecuteScalar());

            conn.Close();

            double total = double.Parse(totalpriceTxt.Text.ToString());
            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                conn.Open();
                using (MySqlCommand addToPurchase = new MySqlCommand("INSERT INTO purchase(purchase_id, purchase_date, product_name, quantity, price, status, purchase_emp_id, purchase_supplier_id) VALUES('" + OrderIncrement + "', '" + today + "', @ProductName, @Quantity, @Price, 'To be delivered', '" + empId + "', '" + supId + "')", conn))
                {
                    addToPurchase.Parameters.AddWithValue("@ProductName", (row.Cells[0].Value.ToString()));
                    addToPurchase.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    addToPurchase.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                    addToPurchase.ExecuteNonQuery();
                }
                conn.Close();
            }
            cPanel.Hide();
            
            oPanel.Enabled = true;
            oPanel.Visible = true;
            oPanel.Location = new Point(279, 191);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            oPanel.Hide();
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
        private void calcSum()
        {
            double a = 0, b = 0;
            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                a = Convert.ToDouble(row.Cells[2].Value);
                b = b + a;
            }
            totalpriceTxt.Text = b.ToString("#,0.00");
        }
        public void checkProduct()
        {
            string prodname = pname.Text;
            double prodprice = double.Parse(priceTxt.Text.ToString());

            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                if(prodname == row.Cells[0].Value.ToString() && prodprice == double.Parse(row.Cells[1].Value.ToString()))
                {
                    //MessageBox.Show("Duplicate entry!");
                    errorPanel.Enabled = true;
                    errorPanel.Visible = true;
                }
            }
        }
    }
}

