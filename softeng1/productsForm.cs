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
using System.Text.RegularExpressions;

namespace softeng1
{
    public partial class productsForm : Form
    {
        MySqlConnection conn;
        public productsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromProduct { get; set; }

        private void productsForm_Load(object sender, EventArgs e)
        {
            loadprod();
            loadSupplierData();
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromProduct.Show();
        }
        private void productsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromProduct.Show();
        }

        //load supplier
        public void loadSupplierData()
        {
            String query = "SELECT firstname, lastname FROM person, supplier where person_id = supplier_person_id";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            SupplierCmb.Items.Clear();
            while (drd.Read())
            {

                SupplierCmb.Items.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }
            conn.Close();
        }

        public void loadprod()
        {
            String query = "SELECT concat(firstname, ' ', lastname) as supplier, product_id, product_name, description, price, pc_category , pc_variant, pc_type, serial FROM product " +
                           "inner join product_catalogue on PRODUCT_PC_ID = pc_id " +
                           "inner join product_has_supplier on product_id = PHS_PRODUCT_ID " +
                           "inner join supplier on PHS_SUPPLIER_ID = SUPPLIER_ID " +
                           "inner join person on SUPPLIER_PERSON_ID = person_id";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            prodData.DataSource = dt;
            prodData.Columns["product_id"].Visible = false;
            prodData.Columns["supplier"].Visible = false;
            prodData.Columns["product_name"].HeaderText = "Product Name";
            prodData.Columns["description"].HeaderText = "Description";
            prodData.Columns["price"].HeaderText = "Price";
            prodData.Columns["serial"].HeaderText = "Serial";
            prodData.Columns["pc_category"].HeaderText = "Category";
            prodData.Columns["pc_variant"].HeaderText = "Variant";
            prodData.Columns["pc_type"].HeaderText = "Type";
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update the data ?", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String query = "Update product, product_catalogue SET product_name = '" + pnameTxt.Text + "', description = '" + pdescTxt.Text + "', serial = '" + serialTxt.Text + "', product_catalogue.pc_category = '" + categTxt.Text + "', product_catalogue.pc_variant = '" + variantTxt.Text + "', price = '" + priceTxt.Text + "' WHERE product_id = '" + selected_prod_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Your data has been updated successfully", "Updated Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadprod();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (pnameTxt.Text == "" || pdescTxt.Text == "" || serialTxt.Text == "" || categTxt.Text == "" || variantTxt.Text == "" || typeTxt.Text == "" || priceTxt.Text == "" || SupplierCmb.Text == "")
            {
                invalidpanel.Visible = true;
                invalidpanel.Enabled = true;
            }
            else
            {
                int maxProdID, ProdCatID, supId;

                conn.Open();

                //SuppID
                string selectSupplier = "SELECT SUPPLIER_ID FROM SUPPLIER, PERSON WHERE CONCAT(FIRSTNAME, ' ', LASTNAME) = '" + SupplierCmb.Text + "'";
                MySqlCommand selectSuppliercomm = new MySqlCommand(selectSupplier, conn);
                supId = Convert.ToInt32(selectSuppliercomm.ExecuteScalar());

                //insert pROD CATALOGUE
                string insertPC = "INSERT INTO product_catalogue(pc_category, pc_variant, pc_type) VALUES('" + categTxt.Text + "', '" + variantTxt.Text + "', '" + typeTxt.Text + "')";
                MySqlCommand insertPCComm = new MySqlCommand(insertPC, conn);
                insertPCComm.ExecuteNonQuery();

                //max PC_ID
                MySqlCommand maxPcId = new MySqlCommand("SELECT MAX(pc_id) FROM product_catalogue", conn);
                ProdCatID = Convert.ToInt16(maxPcId.ExecuteScalar());

                //insert product
                string query = "INSERT INTO product(product_name, description, price, serial, product_pc_id)" +
                 "VALUES ('" + pnameTxt.Text + "','" + pdescTxt.Text + "','" + double.Parse(priceTxt.Text) + "','" + serialTxt.Text + "', '" + ProdCatID + "')";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                

                //max product ID
                MySqlCommand maxID = new MySqlCommand("SELECT MAX(product_id) FROM product", conn);
                maxProdID = Convert.ToInt16(maxID.ExecuteScalar());

                //insert product to inventory
                string insertPurch = "INSERT INTO inventory(quantity, inv_product_id) VALUES(0, '" + maxProdID + "')";
                MySqlCommand insertPurchComm = new MySqlCommand(insertPurch, conn);
                insertPurchComm.ExecuteNonQuery();

                //insert tp PHS
                string insertPhs = "INSERT INTO PRODUCT_HAS_SUPPLIER VALUES('" + maxProdID + "', '" + supId + "')";
                MySqlCommand insertPhsComm = new MySqlCommand(insertPhs, conn);
                insertPhsComm.ExecuteNonQuery();

                conn.Close();

                loadprod();

                pnameTxt.Text = "";
                pdescTxt.Text = "";
                priceTxt.Text = "";
                serialTxt.Text = "";
                categTxt.Text = "";
                variantTxt.Text = "";
                typeTxt.Text = "";
                SupplierCmb.Text = "";

                loadprod();
                loadSupplierData();
            }
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            pnameTxt.Clear();
            pdescTxt.Clear();
            priceTxt.Clear();
            categTxt.Text = "";
            serialTxt.Clear();
            variantTxt.Text = "";
            typeTxt.Text = "";
            SupplierCmb.Text = "";
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

        private void pnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //updPanel.Hide();
        }

        private int selected_prod_id;
        private void prodData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_prod_id = int.Parse(prodData.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                pnameTxt.Text = prodData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                pdescTxt.Text = prodData.Rows[e.RowIndex].Cells["description"].Value.ToString();
                priceTxt.Text = prodData.Rows[e.RowIndex].Cells["price"].Value.ToString();
                serialTxt.Text = prodData.Rows[e.RowIndex].Cells["serial"].Value.ToString();
                categTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_category"].Value.ToString();
                variantTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_variant"].Value.ToString();
                typeTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_type"].Value.ToString();
                SupplierCmb.Text = prodData.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
            }
        }
    }
}
