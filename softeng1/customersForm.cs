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
    public partial class customersForm : Form
    {
        MySqlConnection conn;
        public customersForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
        }
        public static homeForm fromCustomer { get; set; }

        private void customersForm_Load(object sender, EventArgs e)
        {
            editBtn.Enabled = false;
            emailLbl.Visible = false;
            loadCustomerData();
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromCustomer.Show();
        }
        private void customersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromCustomer.Show();
            this.Hide();
        }

        private void customersForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }

        public void loadCustomerData()
        {
            String query = "SELECT * FROM PERSON, CUSTOMER WHERE PERSON.PERSON_TYPE = 'CUSTOMER' AND CUSTOMER_PERSON_ID = PERSON_ID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            custData.DataSource = dt;
            custData.Columns["customer_id"].Visible = false;
            custData.Columns["person_id"].Visible = false;
            custData.Columns["person_type"].Visible = false;
            custData.Columns["customer_person_id"].Visible = false;
            custData.Columns["gender"].Visible = false;
            custData.Columns["balance"].Visible = false;
            custData.Columns["credit_limit"].HeaderText = "Credit Limit";
            custData.Columns["firstname"].HeaderText = "Firstname";
            custData.Columns["lastname"].HeaderText = "Lastname";
            custData.Columns["contact_num"].HeaderText = "Contact Number";
            custData.Columns["address"].HeaderText = "Address";
            custData.Columns["email"].HeaderText = "Email";
        }

        public void loadTransaction()
        {
            String query = "SELECT ORDER_TOTAL, ORDER_DATE, ORDER_STATUS FROM SALES_ORDER, SALES_ORDER_DETAILS WHERE ORDER_CUSTOMER_ID = '" + selected_cust_id + "' AND ORDER_ID = SO_ID GROUP BY ORDER_DATE";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgtransactions.DataSource = dt;

            dgtransactions.Columns["ORDER_TOTAL"].HeaderText = "Total Price";
            dgtransactions.Columns["ORDER_DATE"].HeaderText = "Date";
            dgtransactions.Columns["ORDER_STATUS"].HeaderText = "Status";
        }

        private int selected_cust_id;
        private int selected_person_id;

        private void addBtn_Click(object sender, EventArgs e)
        {
            cPanel.Visible = true;
            cPanel.Enabled = true;
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            emailTxt.Text = "";
            cnumTxt.Text = "";
            addressTxt.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            addBtn.Enabled = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update the data?", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                conn.Open();

                String updateCustomer = "Update PERSON, CUSTOMER SET PERSON.FIRSTNAME = '" + fnameTxt.Text + "', PERSON.LASTNAME = '" + lnameTxt.Text + "', PERSON.CONTACT_NUM = '" + cnumTxt.Text + "', PERSON.EMAIL = '" + emailTxt.Text + "', PERSON.ADDRESS ='" + addressTxt.Text + "' WHERE CUSTOMER_ID = '" + selected_cust_id + "' AND PERSON_ID = '" + selected_person_id + "'";                
                MySqlCommand comm = new MySqlCommand(updateCustomer, conn);
                comm.ExecuteNonQuery();

                String updateCreditLimit = "Update PERSON, CUSTOMER SET CREDIT_LIMIT = '" + double.Parse(creditTxt.Text.ToString()) + "'";
                MySqlCommand comm2 = new MySqlCommand(updateCreditLimit, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            MessageBox.Show("Customer data has been updated successfully", "Updated Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadCustomerData();
        }

        private void fnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void custData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_cust_id = int.Parse(custData.Rows[e.RowIndex].Cells["customer_id"].Value.ToString());
                selected_person_id = int.Parse(custData.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                fnameTxt.Text = custData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = custData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                emailTxt.Text = custData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = custData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                cnumTxt.Text = custData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
                creditTxt.Text = custData.Rows[e.RowIndex].Cells["credit_limit"].Value.ToString();
                int gen = int.Parse(custData.Rows[e.RowIndex].Cells["gender"].Value.ToString());
                if (gen == 1)
                {
                    rbMale.Checked = true;
                    rbMale.Enabled = false;
                }
                else
                {
                    rbFemale.Checked = true;
                    rbFemale.Enabled = false;
                }
            }
            loadTransaction();
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if(emailTxt.Text == "")
            {
                emailLbl.Visible = false;
            }
            else
            {
                if (Regex.IsMatch(emailTxt.Text, pattern))
                {
                    emailLbl.Visible = true;
                    emailLbl.Text = "This email is valid";
                    this.emailLbl.ForeColor = Color.Green;
                }
                else
                {
                    emailLbl.Visible = true;
                    emailLbl.Text = "Invalid email";
                    this.emailLbl.ForeColor = Color.Red;
                }
            }
        }

        private void creditTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            //if (Regex.IsMatch(creditTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            //{
            //    e.Handled = true;
            //}
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            oPanel.Hide();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int getCustomer = 0;
            int maxCust = 0;

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
                    "VALUES ('" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "','" + addressTxt.Text + "','" + gen + "','Customer')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();

                MySqlCommand getCustomerMID = new MySqlCommand("select max(customer_id) from customer", conn);
                getCustomer = Convert.ToInt32(getCustomerMID.ExecuteScalar());
                maxCust = getCustomer;

                string updateCust = "update customer set credit_limit = '" + int.Parse(creditTxt.Text.ToString()) + "' where customer_id = '" + maxCust + "'";
                MySqlCommand updateCustComm = new MySqlCommand(updateCust, conn);
                updateCustComm.ExecuteNonQuery();

                conn.Close();

                loadCustomerData();

                fnameTxt.Text = "";
                lnameTxt.Text = "";
                emailTxt.Text = "";
                cnumTxt.Text = "";
                addressTxt.Text = "";
                creditTxt.Text = "";
                rbMale.Checked = true;

                cPanel.Visible = false;
                cPanel.Enabled = false;

                oPanel.Visible = true;
                oPanel.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cPanel.Hide();
            cPanel.Enabled = false;
        }

        private void closePanel2_Click(object sender, EventArgs e)
        {
            cPanel.Hide();
            cPanel.Enabled = false;
        }
    }
}
