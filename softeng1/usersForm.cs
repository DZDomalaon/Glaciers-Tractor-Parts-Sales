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
            String query = "SELECT * FROM PERSON, EMPLOYEE WHERE PERSON_TYPE = 'EMPLOYEE'";


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

        private int selected_user_id;
        private void usersData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (fnameTxt.Text == "" || lnameTxt.Text == "" || emailTxt.Text == "" || numberTxt.Text == "" || addressTxt.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Employee Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query = "INSERT INTO PERSON(FIRSTNAME, LASTNAME, CONTACT_NUM, EMAIL, ADDRESS, PERSON_TYPE)" +
                    "VALUES ('" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + numberTxt.Text + "','" + emailTxt.Text + "','" + addressTxt.Text + "','Staff')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadEmployeeData();
                fnameTxt.Text = "";
                lnameTxt.Text = "";
                positionCmb.Text = "";
                statusCmb.Text = "";
                shiff.Text = "";
                salary.Text = "";
                emailTxt.Text = "";
                numberTxt.Text = "";
                addressTxt.Text = "";
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

        private void usersData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = false;
            if (e.RowIndex > -1)
            {
                selected_user_id = int.Parse(usersData.Rows[e.RowIndex].Cells["emp_id"].Value.ToString());
                fnameTxt.Text = usersData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = usersData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                positionCmb.Text = usersData.Rows[e.RowIndex].Cells["position"].Value.ToString();
                statusCmb.Text = usersData.Rows[e.RowIndex].Cells["status"].Value.ToString();
                shiftTxt.Text = usersData.Rows[e.RowIndex].Cells["shift"].Value.ToString();
                salaryTxt.Text = usersData.Rows[e.RowIndex].Cells["salary"].Value.ToString();
                emailTxt.Text = usersData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = usersData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                numberTxt.Text = usersData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            positionCmb.Text = "";
            statusCmb.Text = "";
            shiff.Text = "";
            salary.Text = "";
            emailTxt.Text = "";
            numberTxt.Text = "";
            addressTxt.Text = "";
        }
    }
}
