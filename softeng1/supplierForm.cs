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
    public partial class supplierForm : Form
    {
        MySqlConnection conn;
        public supplierForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromSupplier { get; set; }
        private void supplierForm_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click_2(object sender, EventArgs e)
        {
            fromSupplier.Show();
            this.Hide();
        }

        private void supplierForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromSupplier.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

        }

        private void supplierForm_Load_1(object sender, EventArgs e)
        {
            supplierLoad();
        }
        
        public void supplierLoad()
        {
            //String query = "SELECT * FROM SUPPLIER, PERSON";


            //conn.Open();
            //MySqlCommand comm = new MySqlCommand(query, conn);
            //MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            //conn.Close();
            //DataTable dt = new DataTable();
            //adp.Fill(dt);

            //supplierData.DataSource = dt;
            //supplierData.Columns["emp_id"].Visible = false;
            //supplierData.Columns["person_id"].Visible = false;
            //supplierData.Columns["username"].Visible = false;
            //supplierData.Columns["password"].Visible = false;

        }
    }
}
