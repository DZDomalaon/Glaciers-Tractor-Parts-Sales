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

        private void backBtn_Click_2(object sender, EventArgs e)
        {
            fromSupplier.Show();
            this.Hide();
        }

        private void supplierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromSupplier.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            emailTxt.Text = "";
            cnumTxt.Text = "";
            addressTxt.Text = "";
            contactTxt.Text = "";
            organizationTxt.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            organizationTxt.Enabled = false;
        }

        private void supplierForm_Load(object sender, EventArgs e)
        {
            loadSupplierData();
            contactTxt.Enabled = false;
            organizationTxt.Enabled = false;
        }
        
        public void loadSupplierData()
        {
            String query = "SELECT * FROM PERSON, SUPPLIER WHERE PERSON.PERSON_TYPE = 'SUPPLIER' AND SUPPLIER_PERSON_ID = PERSON_ID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            supplierData.DataSource = dt;
            supplierData.Columns["supplier_id"].Visible = false;
            supplierData.Columns["person_id"].Visible = false;
            supplierData.Columns["person_type"].Visible = false;
            supplierData.Columns["supplier_person_id"].Visible = false;
            supplierData.Columns["gender"].Visible = false;
            supplierData.Columns["contact_person"].Visible = false;
            supplierData.Columns["firstname"].HeaderText = "Firstname";
            supplierData.Columns["lastname"].HeaderText = "Lastname";
            supplierData.Columns["contact_num"].HeaderText = "Contact Number";
            supplierData.Columns["address"].HeaderText = "Address";
            supplierData.Columns["email"].HeaderText = "Email";
            supplierData.Columns["organization"].HeaderText = "Organization";
        }

        private int selected_cust_id;
        private int selected_person_id;

        private void supplierData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            organizationTxt.Enabled = true;

            if (e.RowIndex > -1)
            {
                selected_cust_id = int.Parse(supplierData.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                selected_person_id = int.Parse(supplierData.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                fnameTxt.Text = supplierData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = supplierData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                emailTxt.Text = supplierData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = supplierData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                cnumTxt.Text = supplierData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
                contactTxt.Text = supplierData.Rows[e.RowIndex].Cells["contact_person"].Value.ToString();
                organizationTxt.Text = supplierData.Rows[e.RowIndex].Cells["organization"].Value.ToString();
                int gen = int.Parse(supplierData.Rows[e.RowIndex].Cells["gender"].Value.ToString());
                if (gen == 1)
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (fnameTxt.Text == "" || lnameTxt.Text == "" || emailTxt.Text == "" || cnumTxt.Text == "" || addressTxt.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Employee Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int gen = 0;

                if (rbMale.Checked == true)
                {
                    gen = 1;
                }
                else if (rbFemale.Checked == true)
                {
                    gen = 0;
                }
                string query = "INSERT INTO PERSON(FIRSTNAME, LASTNAME, CONTACT_NUM, EMAIL, ADDRESS, GENDER, PERSON_TYPE)" +
                    "VALUES ('" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "','" + addressTxt.Text + "','" + gen + "','Supplier')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadSupplierData();

                fnameTxt.Text = "";
                lnameTxt.Text = "";
                emailTxt.Text = "";
                cnumTxt.Text = "";
                addressTxt.Text = "";
                rbMale.Checked = false;
                rbFemale.Checked = false;            
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int gen = 0;

            if (rbMale.Checked == true)
            {
                gen = 1;
            }
            else if (rbFemale.Checked == true)
            {
                gen = 0;
            }
            String query = "Update PERSON, SUPPLIER SET PERSON.FIRSTNAME = '" + fnameTxt.Text + "', PERSON.LASTNAME = '" + lnameTxt.Text + "', PERSON.GENDER = '" + gen + "', PERSON.CONTACT_NUM = '" + cnumTxt.Text + "', PERSON.EMAIL = '" + emailTxt.Text + "', PERSON.ADDRESS ='" + addressTxt.Text + "', ORGANIZATION = '" + organizationTxt.Text + "', CONTACT_PERSON = CONCAT('" + fnameTxt.Text + "',' ','" + lnameTxt.Text + "') WHERE SUPPLIER_ID = '" + selected_cust_id + "' AND PERSON_ID = '" + selected_person_id + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            loadSupplierData();
        }
    }
}
