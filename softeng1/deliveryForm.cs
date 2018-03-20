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
    public partial class deliveryForm : Form
    {
        MySqlConnection conn;
        public deliveryForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromDelivery { get; set; }
        private void deliveryForm_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromDelivery.Show();
        }

        private void deliveryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromDelivery.Show();
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromDelivery.Show();
            this.Hide();
        }

        public void loadPurchase()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getCustomer = "SELECT firstname, lastname FROM person, supplier where (lastname like '%" + snameTxt.Text + "%' or firstname like '%" + snameTxt.Text + "%') and person_type = 'supplier' and person_id = supplier_person_id ";
            MySqlCommand comm = new MySqlCommand(getCustomer, conn);
            comm.CommandText = getCustomer;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }

            drd.Close();
            conn.Close();

            snameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            snameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            snameTxt.AutoCompleteCustomSource = namesCollection;
        }

        public void loadPurchaseData()
        {
            String query = "select purchase_id, purchase_date, concat(firstname, ' ', lastname)as supplier, product_name, purchase_subquantity from purchase_details, purchase, supplier, person where  pd_purchase_id = purchase_id and supplier_id = PURCHASE_SUPPLIER_ID and PERSON_ID = SUPPLIER_PERSON_ID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["purchase_id"].Visible = true;
            purchaseData.Columns["purchase_date"].Visible = true;
            purchaseData.Columns["supplier"].Visible = true;
            purchaseData.Columns["product_name"].Visible = true;
            purchaseData.Columns["purchase_subquantity"].Visible = true;
            purchaseData.Columns["purchase_id"].HeaderText = "Purchase ID";
            purchaseData.Columns["purchase_date"].HeaderText = "Date of Purchase";
            purchaseData.Columns["supplier"].HeaderText = "Supplier";
            purchaseData.Columns["product_name"].HeaderText = "Product Name";
            purchaseData.Columns["purchase_subquantity"].HeaderText = "Total Quantity";
        }

        private void purchaseData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.RowIndex > -1)
                {
                    purchaseIDtxt.Text = purchaseData.Rows[e.RowIndex].Cells["purchase_id"].Value.ToString();
                    snameTxt.Text = purchaseData.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                    pnameTxt.Text = purchaseData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                }
            }
        }

        private void deliveryForm_Load_1(object sender, EventArgs e)
        {
            loadPurchase();
            loadDelivery();
            loadPurchaseData();
            supLbl.Visible = false;

        }

        public void loadDelivery()
        {
            String query = "SELECT delivery_date, concat(firstname, ' ', lastname)as supplier, delivery.product_name, total_quantity, purchase_subquantity FROM delivery, purchase_details, person, purchase, supplier where  pd_purchase_id = purchase_id and supplier_id = PURCHASE_SUPPLIER_ID and PERSON_ID = SUPPLIER_PERSON_ID and delivery.product_name = purchase_details.PRODUCT_NAME";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            deliveryData.DataSource = dt;

            deliveryData.Columns["delivery_date"].Visible = true;
            deliveryData.Columns["supplier"].Visible = true;
            deliveryData.Columns["product_name"].Visible = true;
            deliveryData.Columns["total_quantity"].Visible = true;
            deliveryData.Columns["purchase_subquantity"].Visible = true;
            deliveryData.Columns["delivery_date"].HeaderText = "Delivery Date";
            deliveryData.Columns["supplier"].HeaderText = "Supplier";
            deliveryData.Columns["product_name"].HeaderText = "Product Name";
            deliveryData.Columns["total_quantity"].HeaderText = "Quantity Delivered";
            deliveryData.Columns["purchase_subquantity"].HeaderText = "Expected Quantity";
        }

        private void deliveryForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromDelivery.Show();
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
        private void snameTxt_TextChanged(object sender, EventArgs e)
        {
            checkSupplier();

            if (snameTxt.Text == "")
            {
                supLbl.Visible = false;
            }
        }

        private void pnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private void pquantTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            succPanel.Hide();
            succPanel.Enabled = false;
        }
        public static int product_id, maxinv, quantity, updquant;

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmPanel.Hide();
            confirmPanel.Enabled = false;
            succPanel.Show();
            succPanel.Enabled = true;
            int prodID, prodQuant, updQuant;
            conn.Open();
            string insertDelivery = "INSERT INTO delivery(product_name, total_quantity, delivery_date, delivery_purchase_id) VALUES('" + pnameTxt.Text + "', '" + pquantTxt.Text + "', '" + deliveryDate.Text + "', '" + purchaseIDtxt.Text + "')";
            MySqlCommand insertDelComm = new MySqlCommand(insertDelivery, conn);
            insertDelComm.ExecuteNonQuery();

            //kuha product id
            MySqlCommand pID = new MySqlCommand("SELECT product_id FROM product where product_name = '" + pnameTxt.Text+ "'", conn);
            prodID = Convert.ToInt16(pID.ExecuteScalar());

            //kuha quantity from inv
            MySqlCommand pQuant = new MySqlCommand("SELECT quantity FROM inventory where inv_product_id = '" + prodID + "'", conn);
            prodQuant = Convert.ToInt16(pQuant.ExecuteScalar());
            updQuant = prodQuant + int.Parse(pquantTxt.Text);

            //update quant
            string updQuantity = "update inventory set quantity = '" + updQuant + "'";
            MySqlCommand updQuantityComm = new MySqlCommand(updQuantity, conn);
            updQuantityComm.ExecuteNonQuery();

            conn.Close();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            confirmPanel.Hide();
            confirmPanel.Enabled = false;
        }

        private void okBtn_Click_1(object sender, EventArgs e)
        {
            snameTxt.Text = "";
            pnameTxt.Text = "";
            pquantTxt.Text = "";
            purchaseIDtxt.Text = "";
            succPanel.Hide();
            succPanel.Enabled = false;

            loadPurchase();
            loadDelivery();
            loadPurchaseData();



        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            confirmPanel.Show();
            confirmPanel.Enabled = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand getProductID = new MySqlCommand("SELECT product_id FROM product where product_name LIKE '%" + pnameTxt.Text + "%'", conn);
            product_id = Convert.ToInt16(getProductID.ExecuteScalar());
            MySqlCommand maxID = new MySqlCommand("SELECT MAX(si_inventory_id) FROM stock_in", conn);
            maxinv = Convert.ToInt16(maxID.ExecuteScalar());
            String insertToStock_in = "INSERT INTO stock_in(si_quantity,si_product_id, si_inventory_id) VALUES('" + pquantTxt.Text + "', '" + product_id + "', '" + (maxinv+1) + "')";
            MySqlCommand insert_si = new MySqlCommand(insertToStock_in, conn);
            insert_si.ExecuteNonQuery();
            MySqlCommand getquant = new MySqlCommand("SELECT quantity FROM inventory where inventory_id = '" + product_id + "'", conn);
            quantity = Convert.ToInt16(getquant.ExecuteScalar());
            updquant = quantity + int.Parse(pquantTxt.Text);
            String updInventory = "update inventory set quantity = '" + updquant + "' where inventory_id = '" + product_id + "'";
            MySqlCommand upd_in = new MySqlCommand(updInventory, conn);
            upd_in.ExecuteNonQuery();
            //look for purchase_id
            //update status (isa pa lang)
            //String updstatus = "update purchase set status = 'Incomplete' where purchase_id = '" + product_id + "'";
            //MySqlCommand upd_status = new MySqlCommand(updstatus, conn);
            //upd_status.ExecuteNonQuery();
            succPanel.Visible = true;
            succPanel.Enabled = true;
            snameTxt.Text = "";
            pnameTxt.Text = "";
            pquantTxt.Text = "";
            conn.Close();
        }
    }
}
