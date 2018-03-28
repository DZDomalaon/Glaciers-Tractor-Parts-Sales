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
    public partial class settingsForm : Form
    {
        MySqlConnection conn;
        public settingsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromSettings { get; set; }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            usenLbl.Visible = false;
            psswrdLbl.Visible = false;
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            //fromSettings.Show();
        }
        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // fromSettings.Show();
        }
        private void userBtn_Click(object sender, EventArgs e)
        {
            if (unameTxt.Text == "")
            {
                usenLbl.Visible = true;
                usenLbl.Text = "Please fill up all the data!";
            }
            else
            {
                string query1 = "SELECT * FROM employee WHERE username = '" + unameTxt.Text + "'";

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm1);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    usenLbl.Visible = true;
                    usenLbl.Text = "Username already exists!";
                }
                else
                {
                    string query2 = "UPDATE employee SET username = '" + unameTxt.Text + "' WHERE emp_id = '" + loginForm.user_id + "'";
                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand(query2, conn);
                    comm2.ExecuteNonQuery();
                    conn.Close();

                    usenLbl.Visible = true;
                    usenLbl.ForeColor = Color.FromArgb(128, 255, 128);
                    usenLbl.Text = "You may now login as " + unameTxt.Text + "! Please log out to see changes.";
                }
            }
        }
        private void passBtn_Click(object sender, EventArgs e)
        {
            if (opsswrdTxt.Text == "" || cpsswrdTxt.Text == "" || npsswrdTxt.Text == "")
            {
                psswrdLbl.Visible = true;
                psswrdLbl.Text = "Please fill up all the data!";
            }
            else
            {
                if (opsswrdTxt.Text != loginForm.userp)
                {
                    psswrdLbl.Visible = true;
                    psswrdLbl.Text = "Old password Incorrect!";
                }
                else
                {
                    if (npsswrdTxt.Text == cpsswrdTxt.Text)
                    {
                        string upquery = "Update employee set password = '" + cpsswrdTxt.Text + "' where emp_id = '" + loginForm.user_id + "'";
                        conn.Open();
                        MySqlCommand comm2 = new MySqlCommand(upquery, conn);
                        comm2.ExecuteNonQuery();
                        conn.Close();

                        psswrdLbl.Visible = true;
                        psswrdLbl.ForeColor = Color.FromArgb(128, 255, 128);
                        psswrdLbl.Text = "Password changed! Log out to see changes.";
                    }
                    else
                    {
                        psswrdLbl.Visible = true;
                        psswrdLbl.Text = "Passwords do not match!";
                    }
                }
            }
        }
    }
}

