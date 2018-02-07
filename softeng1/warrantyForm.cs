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

namespace softeng1
{
    public partial class warrantyForm : Form
    {
        MySqlConnection conn;

        public warrantyForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }

        public static homeForm fromWarranty { get; set; }

        private void warrantyForm_Load(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(
                    "SELECT firstname, lastname, order_warranty, product_name FROM person, sales_order, sales_order_details, product, customer WHERE (firstname LIKE '%" +
                    custnameTxt.Text + "%' or lastname LIKE '%" + custnameTxt.Text + "%') AND person_type = 'CUSTOMER' and customer_person_id = person_id and product_id = order_product_id and customer_id = order_customer_id", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            loadWarranty();
            loadCustomer();            
        }

        private void warrantyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromWarranty.Show();            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromWarranty.Show();
        }

        public void loadWarranty()
        {
            String query = "SELECT firstname, lastname, product_name, date(order_date), date(order_warranty), order_status, warranty_status FROM PERSON, CUSTOMER, SALES_ORDER, SALES_ORDER_DETAILS, PRODUCT WHERE ORDER_CUSTOMER_ID = CUSTOMER_ID AND CUSTOMER_PERSON_ID = PERSON_ID AND ORDER_PRODUCT_ID = PRODUCT_ID AND ORDER_STATUS = 'Paid' and person_type = 'customer'";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            warrantyData.DataSource = dt;
            warrantyData.Columns["FIRSTNAME"].HeaderText = "Firstname";
            warrantyData.Columns["LASTNAME"].HeaderText = "Lastname";
            warrantyData.Columns["PRODUCT_NAME"].HeaderText = "Product Name";
            warrantyData.Columns["date(order_date)"].HeaderText = "Order Date";
            warrantyData.Columns["date(order_warranty)"].HeaderText = "Warranty";
            warrantyData.Columns["ORDER_STATUS"].HeaderText = "Order Status";
            warrantyData.Columns["WARRANTY_STATUS"].HeaderText = "Warranty Status";
        }
        //AutoComplete for customer
        public void loadCustomer()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getCustomer = "SELECT firstname, lastname FROM person, customer where (lastname like '%" + custnameTxt.Text + "%' or firstname like '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ";
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

            custnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            custnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            custnameTxt.AutoCompleteCustomSource = namesCollection;
        }

        public void selectedCustomer()
        {
            String query = "SELECT FIRSTNAME, LASTNAME, PRODUCT_NAME, DATE(ORDER_DATE), DATE(ORDER_WARRANTY), WARRANTY_STATUS FROM customer, person, product, sales_order, sales_order_details WHERE (CONCAT(FIRSTNAME,' ', LASTNAME) LIKE '%" + custnameTxt.Text + "%') AND ORDER_PRODUCT_ID = PRODUCT_ID AND ORDER_STATUS = 'Paid' AND PERSON_ID = CUSTOMER_PERSON_ID AND PERSON_TYPE = 'CUSTOMER'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            warrantyData.DataSource = dt;

            warrantyData.Columns["FIRSTNAME"].HeaderText = "Firstname";
            warrantyData.Columns["LASTNAME"].HeaderText = "Lastname";
            warrantyData.Columns["PRODUCT_NAME"].HeaderText = "Product Name";
            warrantyData.Columns["DATE(ORDER_DATE)"].HeaderText = "Order Date";
            warrantyData.Columns["DATE(ORDER_WARRANTY)"].HeaderText = "Warranty";
            warrantyData.Columns["WARRANTY_STATUS"].HeaderText = "Status";
        }

        private void sDate_Click(object sender, EventArgs e)
        {
            String date = fromDate.Text;
            String query =
                "SELECT firstname, lastname, ORDER_warranty, product_name, ORDER_DATE FROM person, product, sales_order, CUSTOMER WHERE ORDER_CUSTOMER_ID = CUSTOMER_ID AND CUSTOMER_PERSON_ID = PERSON_ID AND ORDER_PRODUCT_ID = PRODUCT_ID AND ORDER_STATUS = 'Paid' and person_type = 'customer' AND ORDER_warranty LIKE '%" +
                date + "%'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            warrantyData.DataSource = dt;

            warrantyData.Columns["FIRSTNAME"].HeaderText = "Firstname";
            warrantyData.Columns["LASTNAME"].HeaderText = "Lastname";
            warrantyData.Columns["PRODUCT_NAME"].HeaderText = "Product Name";
            warrantyData.Columns["ORDER_DATE"].HeaderText = "Order Date";
            warrantyData.Columns["ORDER_WARRANTY"].HeaderText = "Warranty";
        }
        public void IsExpired()
        {
            //DataTable dt = new DataTable();
            //foreach (DataRow row in dt.Rows)
            //{
            /*
                var now = DateTime.Now;
                DateTime warrDate = DateTime.Parse(wDate.Text);
                if (now > warrDate)
                {
                    String query = "UPDATE inventory SET status = 'Expired'";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();

                    DataTable dtTable = new DataTable();
                    adp.Fill(dtTable);
                }
                else
                {
                    String query = "UPDATE inventory SET status = 'Can avail'";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();

                    DataTable dtTable = new DataTable();
                    adp.Fill(dtTable);
                }
                */
            //}
        }
        private void custnameTxt_TextChanged(object sender, EventArgs e)
        {            
            selectedCustomer();

            if (custnameTxt.Text == "")
            {
                loadWarranty();
            }
        }
    }
}

