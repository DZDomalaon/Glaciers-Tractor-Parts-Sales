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
            loadEmployee();
            loadSuppliers();
            loadCustData();                 
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

            customerData.Columns["order_date"].HeaderText = "Order Date";
            customerData.Columns["cname"].HeaderText = "Customer";
            customerData.Columns["order_status"].HeaderText = "Status"; 
        }
        public void loadSuppliers()
        {
            String query = "SELECT concat(firstname,' ',lastname) as sname, purchase_date, status " + 
                           "FROM person inner join supplier on supplier_person_id = person_id " +
                           "inner join purchase on purchase_supplier_id = supplier_id " +
                           "AND purchase_emp_id = (SELECT emp_id FROM employee, person " +
                           "WHERE(concat(firstname, ' ', lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id)";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["purchase_date"].HeaderText = "Purchase Date";
            purchaseData.Columns["sname"].HeaderText = "Supplier";
            purchaseData.Columns["status"].HeaderText = "Status";
        }
        public void loadEmployee()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getEmp = "SELECT firstname, lastname FROM person, employee where (lastname like '%" + empnameTxt.Text + "%' or firstname like '%" + empnameTxt.Text + "%') and person_id = emp_person_id ";
            MySqlCommand comm = new MySqlCommand(getEmp, conn);
            comm.CommandText = getEmp;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }

            drd.Close();
            conn.Close();

            empnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            empnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            empnameTxt.AutoCompleteCustomSource = namesCollection;
        }

        private void empnameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadEmployee();
            }
            catch { }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromTransactions.Show();
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            loadCustData();
        }
        public void loadCustData()
        {
            String date = dateTxt.Text;
            String query =
                "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order, employee WHERE order_date LIKE '%" + date + "%' AND order_customer_id = customer_id AND customer_person_id = person_id AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname,' ',lastname) like '%" + empnameTxt.Text + "%') AND person_id = emp_person_id)";

            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;

            customerData.Columns["order_date"].HeaderText = "Order Date";
            customerData.Columns["cname"].HeaderText = "Customer";
            customerData.Columns["order_status"].HeaderText = "Status";
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            fromTransactions.Show();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            reportForm report = new reportForm();
            report.Show();
            reportForm.fromReportTransactions = this;
        }

        private void empnameTxt_Enter(object sender, EventArgs e)
        {
            loadCustomers();
            loadSuppliers();
        }
    }
}
