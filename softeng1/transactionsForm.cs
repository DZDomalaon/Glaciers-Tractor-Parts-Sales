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
            String query = "SELECT * FROM PERSON, EMPLOYEE WHERE PERSON.PERSON_TYPE = 'EMPLOYEE' AND EMP_PERSON_ID = PERSON_ID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;
            customerData.Columns["emp_id"].Visible = false;
            customerData.Columns["person_id"].Visible = false;
            customerData.Columns["username"].Visible = false;
            customerData.Columns["password"].Visible = false;
            customerData.Columns["time_in"].Visible = false;
            customerData.Columns["time_out"].Visible = false;
        }
    }
}
