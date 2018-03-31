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
using System.Text.RegularExpressions;


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
            organizationTxt.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            organizationTxt.Enabled = false;
        }

        private void supplierForm_Load(object sender, EventArgs e)
        {
            supplierLbl.Visible = false;
            loadSupplierData();
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
            supplierData.Columns["firstname"].HeaderText = "Firstname";
            supplierData.Columns["lastname"].HeaderText = "Lastname";
            supplierData.Columns["contact_num"].HeaderText = "Contact Number";
            supplierData.Columns["address"].HeaderText = "Address";
            supplierData.Columns["email"].HeaderText = "Email";
            supplierData.Columns["organization"].HeaderText = "Organization";
        }
        public void availableProducts()
        {
            string query = "select product_name, price from product " +
                           "inner join product_has_supplier on phs_product_id = product_id " +
                           "inner join supplier on supplier_id = phs_supplier_id " +
                           "where supplier_id = '" + selected_sup_id + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgproduct.DataSource = dt;
            dgproduct.Columns["product_name"].HeaderText = "Product Name";
            dgproduct.Columns["price"].HeaderText = "Price";
        }

        private int selected_sup_id;
        private int selected_person_id;

        private void addBtn_Click(object sender, EventArgs e)
        {
            int getSupplier = 0;
            int MaxSup = 0;

            if (fnameTxt.Text == "" || lnameTxt.Text == "" || emailTxt.Text == "" || cnumTxt.Text == "" || addressTxt.Text == "")
            {
                invalidpanel.Visible = true;
                invalidpanel.Enabled = true;
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

                MySqlCommand getSupplierMID = new MySqlCommand("select max(supplier_id) from supplier", conn);
                getSupplier = Convert.ToInt32(getSupplierMID.ExecuteScalar());
                MaxSup = getSupplier;

                string updateSup = "update supplier set organization = '" + organizationTxt.Text + "' where supplier_id = '" + MaxSup + "'";
                MySqlCommand updateSupComm = new MySqlCommand(updateSup, conn);
                updateSupComm.ExecuteNonQuery();
                conn.Close();

                loadSupplierData();

                fnameTxt.Clear();
                lnameTxt.Clear();
                emailTxt.Clear();
                cnumTxt.Clear();
                addressTxt.Clear();
                organizationTxt.Text = " ";
                rbMale.Checked = false;
                rbFemale.Checked = false;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update the data ?", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                String query = "Update PERSON, SUPPLIER SET PERSON.FIRSTNAME = '" + fnameTxt.Text + "', PERSON.LASTNAME = '" + lnameTxt.Text + "', PERSON.GENDER = '" + gen + "', PERSON.CONTACT_NUM = '" + cnumTxt.Text + "', PERSON.EMAIL = '" + emailTxt.Text + "', PERSON.ADDRESS ='" + addressTxt.Text + "', ORGANIZATION = '" + organizationTxt.Text + "' WHERE SUPPLIER_ID = '" + selected_sup_id + "' AND PERSON_ID = '" + selected_person_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Your data has been updated successfully", "Updated Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadSupplierData();
        }

        private void lnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }                
        }
        private void cnumTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (emailTxt.Text == "")
            {
                supplierLbl.Visible = false;
            }
            else
            {
                if (Regex.IsMatch(emailTxt.Text, pattern))
                {
                    supplierLbl.Visible = true;
                    supplierLbl.Text = "This email is valid";
                    this.supplierLbl.ForeColor = Color.Green;
                }
                else
                {
                    supplierLbl.Visible = true;
                    supplierLbl.Text = "Invalid email";
                    this.supplierLbl.ForeColor = Color.Red;
                }
            }
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void supplierData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            organizationTxt.Enabled = true;

            if (e.RowIndex > -1)
            {
                selected_sup_id = int.Parse(supplierData.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                selected_person_id = int.Parse(supplierData.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                fnameTxt.Text = supplierData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = supplierData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                emailTxt.Text = supplierData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = supplierData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                cnumTxt.Text = supplierData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
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

                availableProducts();
            }
        }
    }
}
