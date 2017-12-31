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
    public partial class orderForm : Form
    {
        MySqlConnection conn;
        public orderForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromOrder { get; set; }
        private void backBtn_Click(object sender, EventArgs e)
        {
            fromOrder.Show();
            this.Hide();            
        }

        private void orderForm_Load(object sender, EventArgs e)
        {
            userTxt.Text = loginForm.name;
            dtp.Value = DateTime.Now;

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
            
            String query = "SELECT customer_id, firstname, lastname FROM person, customer where person_type = 'customer' and (lastname like '%" + custfnameTxt.Text + "%' or firstname like '%" + custfnameTxt.Text + "%')";
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

        private void namepanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgsearchname_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void custfnameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pnameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void sprodTxt_Click(object sender, EventArgs e)
        {
            prodpanel.Enabled = true;
            prodpanel.Visible = true;
            prodpanel.Location = new Point(140, 56);
            prodpanel.Size = new Size(681, 297);

            String query = "SELECT * FROM inventory where product_name like '%" + pnameTxt.Text + "%'";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsearchprod.DataSource = dt;
            dgsearchprod.Columns["product_id"].Visible = false;
            dgsearchprod.Columns["inventory_pc_id"].Visible = false;
            dgsearchprod.Columns["product_name"].HeaderText = "Product Name";
            dgsearchprod.Columns["description"].HeaderText = "Product Description";
            dgsearchprod.Columns["price"].HeaderText = "Product Price";
        }

        private void dgsearchprod_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        public static String prod, price, ln, fn;
        public static double tot, p, q;

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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
                ptotal.Text = tot.ToString();
            }
            else if(pquant.Text == "")
            {
                ptotal.Text = "";
            }
           
        }

        private void dgsearchprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgsearchprod.Rows[e.RowIndex].Cells["product_id"].Value.ToString();
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
                dgsearchname.Rows[e.RowIndex].Cells["customer_id"].Value.ToString();
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
        private void closeprod_Click(object sender, EventArgs e)
        {
            prodpanel.Hide();
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            string firstColumn = custfnameTxt.Text;
            string secondColumn = pnameTxt.Text;
            string thirdColumn = ppriceTxt.Text;
            string fourthColumn = pquant.Text;
            string fifthColumn = ptotal.Text;
            string sixthColumn = paymentCmb.Text;
            string seventhColumn = userTxt.Text;
            string eigthColumn = dtp.Text;
            string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn, fifthColumn, sixthColumn, seventhColumn, eigthColumn};

            orderDG.Rows.Add(row);
        }
        private void removeOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
