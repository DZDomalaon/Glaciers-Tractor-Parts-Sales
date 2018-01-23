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
    public partial class usersForm : Form
    {
        MySqlConnection conn;
        public usersForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromUsers { get; set; }
        private void usersForm_Load(object sender, EventArgs e)
        {
            editBtn.Enabled = false;
            loadEmployeeData();
        }
        public void loadEmployeeData()
        {
            String query = "SELECT * FROM PERSON, EMPLOYEE WHERE PERSON.PERSON_TYPE = 'EMPLOYEE' AND EMP_PERSON_ID = PERSON_ID";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            usersData.DataSource = dt;            
            usersData.Columns["emp_id"].Visible = false;
            usersData.Columns["person_id"].Visible = false;
            usersData.Columns["username"].Visible = false;
            usersData.Columns["password"].Visible = false;
            usersData.Columns["time_in"].Visible = false;
            usersData.Columns["time_out"].Visible = false;
            usersData.Columns["log_date"].Visible = false;
            usersData.Columns["person_type"].Visible = false;
            usersData.Columns["emp_person_id"].Visible = false;
            usersData.Columns["gender"].Visible = false;
            usersData.Columns["date_hired"].Visible = false;
            usersData.Columns["firstname"].HeaderText = "Firstname";
            usersData.Columns["lastname"].HeaderText = "Lastname";
            usersData.Columns["contact_num"].HeaderText = "Contact Number";
            usersData.Columns["address"].HeaderText = "Address";
            usersData.Columns["email"].HeaderText = "Email";
            usersData.Columns["shift"].HeaderText = "Shift";            
            usersData.Columns["position"].HeaderText = "Position";
            usersData.Columns["status"].HeaderText = "Status";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            fromUsers.Show();
            this.Hide();            
        }
        private void usersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromUsers.Show();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (fnameTxt.Text == "" || lnameTxt.Text == "" || emailTxt.Text == "" || numberTxt.Text == "" || addressTxt.Text == "")
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
                    "VALUES ('" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + numberTxt.Text + "','" + emailTxt.Text + "','" + addressTxt.Text + "','"+ gen + "','Employee')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadEmployeeData();

                fnameTxt.Text = "";
                lnameTxt.Text = "";
                positionCmb.Text = "";
                statusCmb.Text = "";
                shiftTxt.Text = "";
                salaryTxt.Text = "";
                emailTxt.Text = "";
                numberTxt.Text = "";
                addressTxt.Text = "";
                rbMale.Checked = true;
            }
        }
        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromUsers.Show();
            this.Hide();
        }
        
        private void usersForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromUsers.Show();
        }


        private int selected_emp_id;
        private int selected_person_id;
        private void usersData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_emp_id = int.Parse(usersData.Rows[e.RowIndex].Cells["emp_id"].Value.ToString());
                selected_person_id = int.Parse(usersData.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                fnameTxt.Text = usersData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = usersData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                positionCmb.Text = usersData.Rows[e.RowIndex].Cells["position"].Value.ToString();
                statusCmb.Text = usersData.Rows[e.RowIndex].Cells["status"].Value.ToString();
                shiftTxt.Text = usersData.Rows[e.RowIndex].Cells["shift"].Value.ToString();
                salaryTxt.Text = usersData.Rows[e.RowIndex].Cells["salary"].Value.ToString();
                emailTxt.Text = usersData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = usersData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                numberTxt.Text = usersData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
                int gen = int.Parse(usersData.Rows[e.RowIndex].Cells["gender"].Value.ToString());
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

        private void resetBtn_Click(object sender, EventArgs e)
        {
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            positionCmb.Text = "";
            statusCmb.Text = "";
            shiftTxt.Text = "";
            salaryTxt.Text = "";
            emailTxt.Text = "";
            numberTxt.Text = "";
            addressTxt.Text = "";
            addBtn.Enabled = true;
            editBtn.Enabled = false;
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
                String query = "Update PERSON, EMPLOYEE SET PERSON.FIRSTNAME = '" + fnameTxt.Text + "', PERSON.LASTNAME = '" + lnameTxt.Text + "', POSITION = '" + positionCmb.Text + "', PERSON.GENDER = '" + gen + "', STATUS = '" + statusCmb.Text + "', SHIFT = '" + shiftTxt.Text + "', SALARY = '" + double.Parse(salaryTxt.Text.ToString()) + "', PERSON.CONTACT_NUM = '" + numberTxt.Text + "', PERSON.EMAIL = '" + emailTxt.Text + "', PERSON.ADDRESS ='" + addressTxt.Text + "' WHERE EMP_ID = '" + selected_emp_id + "' AND PERSON_ID = '" + selected_person_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();                
            }
            loadEmployeeData();
            MessageBox.Show("Your data has been updated successfully", "Updated Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void fnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(fnameTxt.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
                fnameTxt.Text.Remove(fnameTxt.Text.Length - 1);
            }
        }

        private void lnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(lnameTxt.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
                fnameTxt.Text.Remove(lnameTxt.Text.Length - 1);
            }
        }

        private void salaryTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void numberTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
