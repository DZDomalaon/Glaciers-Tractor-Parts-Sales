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
    public partial class loginForm : Form
    {
        MySqlConnection conn;

        public loginForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }

            public static string name;
            public static string usern;
            public static string userp;
            public static int user_id;
            public static string type;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToShortTimeString();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String user = unameTxt.Text;
            String pass = passwdTxt.Text;
            String query = "SELECT * FROM EMPLOYEE, PERSON WHERE USERNAME = '" + user + "' AND PASSWORD = '" + pass + "' and employee.EMP_PERSON_ID = person.PERSON_ID";            

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);                        

            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            if(dt.Rows.Count  == 1)
            {
                int id = int.Parse(dt.Rows[0][0].ToString());
                string fname = dt.Rows[0][8].ToString();
                string lname = dt.Rows[0][9].ToString();
                string username = dt.Rows[0][4].ToString();
                string password = dt.Rows[0][5].ToString();

                user_id = id;
                name = fname + " " + lname;
                usern = username;
                userp = password;

                homeForm form = new homeForm();
                form.Show();
                homeForm.previousForm = this;
                this.Hide();

                MessageBox.Show("Welcome, " + fname + "!", "WELCOME!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unameTxt.Clear();
                passwdTxt.Clear();                
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            loginForm form = new loginForm();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked == true)
            {
                passwdTxt.PasswordChar = '\0';
            }
            else
            {
                passwdTxt.PasswordChar = '*';
            }
        }
    }
}

