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
    public partial class ptransactionsForm : Form
    {
        private MySqlConnection conn;
        public ptransactionsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }

        private void ptransactionsForm_Load(object sender, EventArgs e)
        {
            loadSuppliers();
            loadEmployee();
        }
        public void loadSuppliers()
        {
            String query = "SELECT purchase_date, organization, status " +
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
            purchaseData.Columns["organization"].HeaderText = "Organization";
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

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            loadSuppData();
        }
        public void loadSuppData()
        {
            String date = dateTxt.Text;
            String query =
                "SELECT purchase_date, organization, status FROM person, supplier, purchase, employee WHERE purchase_date LIKE '%" + date + "%' AND purchase_supplier_id = supplier_id AND supplier_person_id = person_id AND purchase_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname,' ',lastname) like '%" + empnameTxt.Text + "%') AND person_id = emp_person_id)";

            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["order_date"].HeaderText = "Order Date";
            purchaseData.Columns["cname"].HeaderText = "Customer";
            purchaseData.Columns["order_status"].HeaderText = "Status";
        }
    }
}
