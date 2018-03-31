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
            dgProducts.Columns.Add("ProductCategory", "Category");
            dgProducts.Columns.Add("ProductVariant", "Variant");
            dgProducts.Columns.Add("ProductType", "Type");
            dgProducts.Columns.Add("Price", "Price");
            dgProducts.Columns.Add("SubTotal", "Sub Total");
            dgProducts.Columns.Add("Quantity", "Quantity");
            loadSupplier();

            proLbl.Visible = false;
            dgProducts.Visible = true;
            supLbl.Visible = false;

            AutoCompleteStringCollection prodCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getPname = "SELECT PRODUCT_NAME, PRICE FROM PRODUCT, SUPPLIER, PRODUCT_HAS_SUPPLIER WHERE PRODUCT_ID = PHS_PRODUCT_ID AND SUPPLIER_ID = PHS_SUPPLIER_ID";
            MySqlCommand comm = new MySqlCommand(getPname, conn);
            comm.CommandText = getPname;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    prodCollection.Add(drd["PRODUCT_NAME"].ToString());
                }
            }

            drd.Close();
            conn.Close();
            
            pname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            pname.AutoCompleteCustomSource = prodCollection;
        }

        public void loadSupplier()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getCustomer = "SELECT ORGANIZATION FROM supplier";
            MySqlCommand comm = new MySqlCommand(getCustomer, conn);
            comm.CommandText = getCustomer;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["ORGANIZATION"].ToString());
            }

            drd.Close();
            conn.Close();

            snameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            snameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            snameTxt.AutoCompleteCustomSource = namesCollection;
        }

        public void checkSupplier()
        {
            conn.Close();
            conn.Open();

            int countSupplier;
            MySqlCommand getCustomer = new MySqlCommand("SELECT COUNT(*) FROM PERSON, SUPPLIER WHERE CONCAT(FIRSTNAME, ' ', LASTNAME) = '" + snameTxt.Text + "' AND PERSON_TYPE = 'SUPPLIER' AND PERSON_ID = SUPPLIER_PERSON_ID", conn);
            countSupplier = Convert.ToInt16(getCustomer.ExecuteScalar());

            conn.Close();

            if (snameTxt.Text == "" || countSupplier == 0)
            {
                supLbl.Visible = true;
                this.supLbl.ForeColor = Color.Red;
                supLbl.Text = "This supplier is not recognized.";
            }
            else
            {
                supLbl.Visible = true;
                this.supLbl.ForeColor = Color.Green;
                supLbl.Text = "Supplier found";
            }
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            checkProduct();
            if (pname.Text != "" || priceTxt.Text != "" || pquant.Text != "" || ptotal.Text != "")
            {
                string firstColumn = pname.Text;
                string secondColumn = categTxt.Text;
                string thirdColumn = variantTxt.Text;
                string fourthColumn = typeTxt.Text;
                string fifthColumn = priceTxt.Text;
                string sixthColumn = ptotal.Text;
                string seventhColumn = pquant.Text;

                string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn, fifthColumn, sixthColumn, seventhColumn };

                dgProducts.Rows.Add(row);

                pname.Clear();
                priceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();
                categTxt.Text = "";
                variantTxt.Text = "";
                ptypeTxt.Text = "";

                calcSum();
            }
            else
            {
                MessageBox.Show("Please fill up all the data", "Add Purchase Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static int quant;
        public static double tot, p, q;


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

        public static int rowIndex;
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

        public void checkSupProd()
        {
            conn.Close();
            conn.Open();

            int countProd;
            MySqlCommand getProduct = new MySqlCommand("SELECT COUNT(*) FROM PRODUCT, SUPPLIER, PRODUCT_HAS_SUPPLIER WHERE PRODUCT_ID = PHS_PRODUCT_ID AND PHS_SUPPLIER_ID = SUPPLIER_ID", conn);
            countProd = Convert.ToInt16(getProduct.ExecuteScalar());

            

            if (pname.Text == "" || countProd == 0)
            {
                proLbl.Visible = true;
                this.proLbl.ForeColor = Color.Red;
                proLbl.Text = "Not recognized.";
            }
            else
            {
                proLbl.Visible = true;
                this.proLbl.ForeColor = Color.Green;
                proLbl.Text = "Product found";



            }
            conn.Close();

        }

        private void pname_TextChanged(object sender, EventArgs e)
        {
            checkSupProd();

            if (snameTxt.Text == "")
            {
                proLbl.Visible = false;
            }
            else
            {
                conn.Open();
                int prodID;
                MySqlCommand getID = new MySqlCommand("SELECT product_id FROM PRODUCT WHERE PRODUCT_NAME = '" + pname.Text + "'", conn);
                prodID = Convert.ToInt16(getID.ExecuteScalar());

                String getProdData = "select pc_category, pc_variant, pc_type, price from product_catalogue, product where pc_id = product_id and pc_id = '" + prodID + "'";
                MySqlCommand comm = new MySqlCommand(getProdData, conn);
                comm.CommandText = getProdData;
                MySqlDataReader drd = comm.ExecuteReader();

                if (drd.HasRows == true)
                {
                    while (drd.Read())
                    {
                        categTxt.Text = drd["pc_category"].ToString();
                        variantTxt.Text = drd["pc_variant"].ToString();
                        ptypeTxt.Text = drd["pc_type"].ToString();
                        priceTxt.Text = drd["price"].ToString();

                    }
                }

                drd.Close();
                conn.Close();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cPanel.Hide();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (double.Parse(totalpriceTxt.Text) > 0)
            {
                cPanel.Visible = true;
                cPanel.Enabled = true;
            } else if (double.Parse(totalpriceTxt.Text) == 0)
            {
                invalidpanel.Visible = true;
                invalidpanel.Enabled = true;
            }
            
        }

        private void dgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            DataGridViewRow row = dgProducts.Rows[rowIndex];

            pname.Text = row.Cells[0].Value.ToString();
            categTxt.Text = row.Cells[1].Value.ToString();
            variantTxt.Text = row.Cells[2].Value.ToString();
            typeTxt.Text = row.Cells[3].Value.ToString();
            priceTxt.Text = row.Cells[4].Value.ToString();
            ptotal.Text = row.Cells[5].Value.ToString();
            pquant.Text = row.Cells[6].Value.ToString();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updateRow = dgProducts.Rows[rowIndex];

            updateRow.Cells[0].Value = pname.Text;
            updateRow.Cells[1].Value = categTxt.Text;
            updateRow.Cells[2].Value = variantTxt.Text;
            updateRow.Cells[3].Value = typeTxt.Text;
            updateRow.Cells[4].Value = priceTxt.Text;
            updateRow.Cells[5].Value = ptotal.Text;
            updateRow.Cells[6].Value = pquant.Text;

            calcSum();
        }
        
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int maxOrderId = 0;
            int OrderIncrement = 0;
            int empId = loginForm.user_id;
            int supId;
            string product = pname.Text;

            conn.Open();
            //Get max id from sales_order
            MySqlCommand maxIDOrder = new MySqlCommand("SELECT MAX(purchase_id) FROM purchase", conn);
            maxOrderId = Convert.ToInt16(maxIDOrder.ExecuteScalar());
            OrderIncrement = maxOrderId + 1;

            String today = DateTime.Now.Date.ToString("yyyy-MM-dd");


            MySqlCommand getSupID = new MySqlCommand("SELECT supplier_id FROM supplier, person where(CONCAT(FIRSTNAME, ' ', LASTNAME) LIKE '%" + snameTxt.Text + "%') and person_type = 'supplier' and person_id = supplier_person_id ", conn);
            supId = Convert.ToInt16(getSupID.ExecuteScalar());

            string insertPurch = "INSERT INTO purchase(purchase_id, purchase_date, status, purchase_emp_id, purchase_supplier_id) VALUES('" + OrderIncrement + "', '" + today + "', 'To be delivered', '" + empId + "', '" + supId + "')";
            MySqlCommand insertPurchComm = new MySqlCommand(insertPurch, conn);
            insertPurchComm.ExecuteNonQuery();

            conn.Close();

            double total = double.Parse(totalpriceTxt.Text.ToString());
            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                conn.Open();
                
                using (MySqlCommand addToSales = new MySqlCommand("INSERT INTO PURCHASE_DETAILS VALUES(@ProductName, @Price, '"+ double.Parse(totalpriceTxt.Text) + "', @Subtotal, '"+ totalQuantity() +"', @Quantity, @ProductCategory, @ProductVariant , @ProductType, '"+ OrderIncrement +"')", conn))
                {
                    addToSales.Parameters.AddWithValue("@ProductName", row.Cells[0].Value.ToString());
                    addToSales.Parameters.AddWithValue("@ProductCategory", row.Cells[1].Value.ToString());
                    addToSales.Parameters.AddWithValue("@ProductVariant", row.Cells[2].Value.ToString());
                    addToSales.Parameters.AddWithValue("@ProductType", row.Cells[3].Value.ToString());
                    addToSales.Parameters.AddWithValue("@Price", double.Parse(row.Cells[4].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                    addToSales.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[5].Value.ToString()));
                    addToSales.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[6].Value.ToString()));
                    addToSales.ExecuteNonQuery();
                }

                conn.Close();
            }
            categTxt.Text = "";
            variantTxt.Text = "";
            ptypeTxt.Text = "";
            priceTxt.Clear();
            pquant.Clear();
            ptotal.Clear();
            snameTxt.Clear();
            supLbl.Visible = false;
            proLbl.Visible = false;

            cPanel.Hide();

            oPanel.Enabled = true;
            oPanel.Visible = true;
            oPanel.Location = new Point(279, 191);
        }

        private int totalQuantity()
        {
            int a = 0, b = 0;
            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                a = int.Parse(row.Cells[6].Value.ToString());
                b = b + a;
            }
            return b;
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

        private void snameTxt_TextChanged(object sender, EventArgs e)
        {
            checkSupplier();

            if (snameTxt.Text == "")
            {
                supLbl.Visible = false;
            }
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            errorPanel.Hide();
        }

        private void errorPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void closePanel_Click_1(object sender, EventArgs e)
        {
            errorPanel.Hide();
        }

        private void proLbl_Click(object sender, EventArgs e)
        {

        }

        private void supLbl_Click(object sender, EventArgs e)
        {

        }

        private void errorPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void totalpriceTxt_Click(object sender, EventArgs e)
        {

        }

        private void calcSum()
        {
            double a = 0, b = 0;
            foreach (DataGridViewRow row in dgProducts.Rows)
            {
                a = Convert.ToDouble(row.Cells[5].Value);
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
                if (prodname == row.Cells[0].Value.ToString() && prodprice == double.Parse(row.Cells[1].Value.ToString()))
                {                    
                    errorPanel.Enabled = true;
                    errorPanel.Visible = true;
                }
            }
        }
    }
}

