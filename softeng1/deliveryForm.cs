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
    }
}
