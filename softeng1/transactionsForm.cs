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
        }

        private void transactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromTransactions.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            cpanel.Visible = true;
            cpanel.Enabled = true;
        }
        public void loadCustomers()
        {
            String query = "SELECT concat(firstname,' ',lastname) as name, time_in, time_out, log_date, concat(firstname,' ',lastname) as cname FROM employee, person, customer, sales_order WHERE person.person_type = 'EMPLOYEE' AND emp_person_id = person_id";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;
            customerData.Columns["name"].HeaderText = "Employee";
            customerData.Columns["time_in"].HeaderText = "Time In";
            customerData.Columns["time_out"].HeaderText = "Time Out";
            customerData.Columns["log_date"].HeaderText = "Log Date";
            customerData.Columns["cname"].HeaderText = "Customer"; //
        }
    }
}
