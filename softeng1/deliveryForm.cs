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
        private void deliveryForm_Load_1(object sender, EventArgs e)
        {
            loadPurchase();
            supLbl.Visible = false;

            purchaseData.Columns.Add("PurchaseDate", "Purchase Date");
            purchaseData.Columns.Add("Status", "Status");
            purchaseData.Columns.Add("Supplier", "Supplier");
            purchaseData.Visible = true;

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
        }
        public static int product_id, maxinv, quantity, updquant;
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
            statustxt.Text = "";
            snameTxt.Text = "";
            pnameTxt.Text = "";
            pquantTxt.Text = "";
            conn.Close();
        }
    }
}
