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
    public partial class transactionsForm : Form
    {
        private MySqlConnection conn;
        public transactionsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromTransactions { get; set; }
        private void transactionsForm_Load(object sender, EventArgs e)
        {
            loadCustomers();
            //loadSuppliers();
        }

        private void transactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromTransactions.Show();
        }
        public void loadCustomers()
        {
            String query = "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order WHERE order_customer_id = customer_id AND customer_person_id = person_id AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname,' ',lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id)";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;
            //customerData.Columns[loginForm.name].HeaderText = "Employee";
            customerData.Columns["order_date"].HeaderText = "Log Date";
            customerData.Columns["cname"].HeaderText = "Customer";
            customerData.Columns["order_status"].HeaderText = "Status"; 
        }
    }
}
