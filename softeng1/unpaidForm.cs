using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
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
            String query = "SELECT CONCAT(FIRSTNAME , ' ', LASTNAME), ORDER_TOTAL, ORDER_DATE, BALANCE, ORDER_ID from sales_order, sales_order_details, person, customer where order_status = 'Unpaid' and (person_id = customer_person_id and person_type = 'customer') and order_customer_id = customer_id and order_id = so_id group by order_date";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            unpaidData.DataSource = dt;
            unpaidData.Columns["ORDER_ID"].Visible = false;
            unpaidData.Columns["CONCAT(FIRSTNAME , ' ', LASTNAME)"].HeaderText = "Customer";
            unpaidData.Columns["ORDER_TOTAL"].HeaderText = "Total";
            unpaidData.Columns["ORDER_DATE"].HeaderText = "Date";
            unpaidData.Columns["BALANCE"].HeaderText = "Balance";
        }

        private void unpaidData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            custnameTxt.Text = unpaidData.Rows[e.RowIndex].Cells["CONCAT(FIRSTNAME , ' ', LASTNAME)"].Value.ToString();
            balanceTxt.Text = unpaidData.Rows[e.RowIndex].Cells["BALANCE"].Value.ToString();
            ordernumTxt.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_ID"].Value.ToString();
            totalTxt.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_TOTAL"].Value.ToString();
            unpaidDateLbl.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_DATE"].Value.ToString();
        }

        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(amountTxt.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
    }
}
