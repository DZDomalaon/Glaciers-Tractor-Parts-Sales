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
using Microsoft.VisualBasic;

namespace softeng1
{
    public partial class orderForm : Form
    {
        MySqlConnection conn;
        public orderForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static int customer_id;
        public static int product_id;
        public static int rowIndex;

        public static homeForm fromOrder { get; set; }
        private void backBtn_Click(object sender, EventArgs e)
        {
            fromOrder.Show();
            this.Hide();
        }

        private void orderForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");

            orderDG.Columns.Add("Customer", "Customer");
            orderDG.Columns.Add("Product Name", "Product Name");
            orderDG.Columns.Add("Price", "Price");
            orderDG.Columns.Add("Quantity", "Quantity");
            orderDG.Columns.Add("Sub Total", "Sub Total");
            orderDG.Columns.Add("Payment", "Payment");
            orderDG.Columns.Add("Employee", "Employee");
            orderDG.Columns.Add("Date", "Date");

        }
        public static string searchn;
        private void snameTxt_Click(object sender, EventArgs e)
        {
            namepanel.Enabled = true;
            namepanel.Visible = true;
            namepanel.Location = new Point(140, 56);
            namepanel.Size = new Size(681, 297);

            String query = "SELECT customer_id, firstname, lastname FROM person, customer where (lastname like '%" + custfnameTxt.Text + "%' or firstname like '%" + custfnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsearchname.DataSource = dt;

            dgsearchname.Columns["customer_id"].Visible = false;
            dgsearchname.Columns["firstname"].HeaderText = "Given Name";
            dgsearchname.Columns["lastname"].HeaderText = "Last Name";
        }

        private void sprodTxt_Click(object sender, EventArgs e)
        {
            prodpanel.Enabled = true;
            prodpanel.Visible = true;
            prodpanel.Location = new Point(140, 56);
            prodpanel.Size = new Size(681, 297);

            String query = "SELECT product_id, product_pc_id, product_name, description, price FROM product where product_name like '%" + pnameTxt.Text + "%'";
            conn.Open();


            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsearchprod.DataSource = dt;
            dgsearchprod.Columns["product_id"].Visible = false;
            dgsearchprod.Columns["product_pc_id"].Visible = false;
            dgsearchprod.Columns["product_name"].HeaderText = "Product Name";
            dgsearchprod.Columns["description"].HeaderText = "Product Description";
            dgsearchprod.Columns["price"].HeaderText = "Product Price";
        }

        public static String prod, price, ln, fn;
        public static double tot, p, q;

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }

        public static int quant;
        private void pquant_TextChanged(object sender, EventArgs e)
        {
            if (pquant.Text != "")
            {
                quant = int.Parse(pquant.Text);
                p = double.Parse(ppriceTxt.Text);
                q = quant;
                tot = q * p;
                ptotal.Text = tot.ToString("#,0.00");
            }
            else if (pquant.Text == "")
            {
                ptotal.Text = "";
            }
        }

        private void dgsearchprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                product_id = int.Parse(dgsearchprod.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                prod = dgsearchprod.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                dgsearchprod.Rows[e.RowIndex].Cells["description"].Value.ToString();
                price = dgsearchprod.Rows[e.RowIndex].Cells["price"].Value.ToString();
                pnameTxt.Text = prod;
                ppriceTxt.Text = price;
                prodpanel.Enabled = false;
                prodpanel.Visible = false;
                prodpanel.Location = new Point(434, 152);
                prodpanel.Size = new Size(521, 44);
            }
        }
        private void dgsearchname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                customer_id = int.Parse(dgsearchname.Rows[e.RowIndex].Cells["customer_id"].Value.ToString());
                fn = dgsearchname.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                ln = dgsearchname.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                custfnameTxt.Text = fn + ' ' + ln;
                namepanel.Enabled = false;
                namepanel.Visible = false;
                namepanel.Location = new Point(434, 85);
                namepanel.Size = new Size(521, 44);
            }
        }

        private void orderForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }
        private void close_Click(object sender, EventArgs e)
        {
            namepanel.Hide();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        { 

            int maxOrderId = 0;
            int increment = 0;
            int maxPaymentId = 0;
            int PaymentInc = 0;

            conn.Open();
            //Select max id from sale_order
            MySqlCommand query = new MySqlCommand("SELECT MAX(order_id) FROM SALES_ORDER", conn);
            maxOrderId = Convert.ToInt16(query.ExecuteScalar());
            increment = maxOrderId + 1;

            //insert payment amount
            String insertToPayment = "INSERT INTO PAYMENT(AMOUNT) VALUES('" + cashTxt.Text + "'";
            MySqlCommand comm = new MySqlCommand(insertToPayment, conn);
            comm.ExecuteNonQuery();

            //
            MySqlCommand query2 = new MySqlCommand("SELECT MAX(payment_id) FROM payment", conn);
            maxPaymentId = Convert.ToInt16(query2.ExecuteScalar());
            PaymentInc = maxOrderId + 1;


            conn.Close();                

            
        }

        private void dgsearchname_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void closeprod_Click(object sender, EventArgs e)
        {
            prodpanel.Hide();
        }

        private void paymentCmb_TextChanged(object sender, EventArgs e)
        {
            if(paymentCmb.Text == "Cash")
            {
                cashTxt.Enabled = true;
            }
            else if(paymentCmb.Text == "Credit")
            {
                cashTxt.Enabled = false;
            }
        }

        private void orderDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex; 
            DataGridViewRow row = orderDG.Rows[rowIndex];

            pnameTxt.Text = row.Cells[1].Value.ToString();
            ppriceTxt.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
            ptotal.Text = row.Cells[4].Value.ToString();
            paymentCmb.Text = row.Cells[5].Value.ToString();
        }

        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updRow = orderDG.Rows[rowIndex];

            updRow.Cells[0].Value = custfnameTxt.Text;
            updRow.Cells[1].Value = pnameTxt.Text;
            updRow.Cells[2].Value = ppriceTxt.Text;
            updRow.Cells[3].Value = pquant.Text;
            updRow.Cells[4].Value = ptotal.Text;
            updRow.Cells[5].Value = paymentCmb.Text;
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
             if (custfnameTxt.Text == "" || pnameTxt.Text == "" || ppriceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "" || paymentCmb.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Customer Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string firstColumn = custfnameTxt.Text;
                string secondColumn = pnameTxt.Text;
                string thirdColumn = ppriceTxt.Text;
                string fourthColumn = pquant.Text;
                string fifthColumn = ptotal.Text;
                string sixthColumn = paymentCmb.Text;
                string seventhColumn = usernameLbl.Text;
                string eigthColumn = dateLbl.Text;
                string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn, fifthColumn, sixthColumn, seventhColumn, eigthColumn };

                orderDG.Rows.Add(row);

                pnameTxt.Clear();
                ppriceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();
                paymentCmb.Text = "";
                calcSum();
            }
        }
        private void removeOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.orderDG.SelectedRows)
            {
                orderDG.Rows.RemoveAt(item.Index);
            }
        }
        private void calcSum()
        {
            double a = 0, b = 0;
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                a = Convert.ToDouble(row.Cells[4].Value);
                b = b + a;
            }
            totalpriceTxt.Text = b.ToString("#,0.00");
        }
    }
}
