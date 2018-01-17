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
    public partial class unpaidForm : Form
    {
        MySqlConnection conn;
        public unpaidForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
        }
        public static homeForm fromUnpaid { get; set; }

        private void unpaidForm_Load(object sender, EventArgs e)
        {
            loadUnpaidCustomer();
        }

        private void unpaidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromUnpaid.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromUnpaid.Show();
        }
        public void loadUnpaidCustomer()
        {
            String query = "SELECT * from sales_order where order_status = 'Unpaid'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            unpaidData.DataSource = dt;
            unpaidData.Columns["order_id"].Visible = false;
            unpaidData.Columns["order_customer_id"].Visible = false;
            unpaidData.Columns["order_emp_id"].Visible = false;
            unpaidData.Columns["order_product_id"].Visible = false;
            unpaidData.Columns["order_payment_id"].Visible = false;
            unpaidData.Columns["order_warranty"].Visible = false;
            unpaidData.Columns["order_date"].Visible = false;
            unpaidData.Columns["order_status"].Visible = false;
            unpaidData.Columns["order_price"].HeaderText = "Price";
            unpaidData.Columns["order_subtotal"].HeaderText = "Sub Total";
            unpaidData.Columns["order_tquantity"].HeaderText = "Total Quantity";
            unpaidData.Columns["order_discount"].HeaderText = "Discount";
            unpaidData.Columns["order_date"].HeaderText = "Date";            
        }
    }
}
