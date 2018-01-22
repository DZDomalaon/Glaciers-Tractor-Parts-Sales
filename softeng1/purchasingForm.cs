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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
<<<<<<< HEAD
using Microsoft.VisualBasic;
=======
>>>>>>> parent of f23151b... asd

namespace softeng1
{
    public partial class purchasingForm : Form
    {
        MySqlConnection conn;
        public purchasingForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromPurchasing { get; set; }
        private void purchasingForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
<<<<<<< HEAD
            //dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");
            //datetime.Value = DateTime.Now;
            //loadPurchase();
            //loadproducts();
            //pnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //pnameTxt.AutoCompleteSource = AutoCompleteSource.ListItems;
=======
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");
            datetime.Value = DateTime.Now;
            loadPurchase();
            loadproducts();
            pnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pnameTxt.AutoCompleteSource = AutoCompleteSource.ListItems;
>>>>>>> parent of f23151b... asd

        }
        public void loadproducts()
        {
            prodpanel.Enabled = true;
            prodpanel.Visible = true;
            prodpanel.Location = new Point(140, 56);
            prodpanel.Size = new Size(681, 297);

            String query = "SELECT * FROM inventory";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsearchprod.DataSource = dt;

<<<<<<< HEAD
        //    dgsearchprod.Columns["product_id"].Visible = false;
        //    dgsearchprod.Columns["product_name"].HeaderText = "Product Name";
        //    dgsearchprod.Columns["price"].HeaderText = "Price";
        //}
            purchaseDG.Columns.Add("Product Name", "Product Name");
            purchaseDG.Columns.Add("Price", "Price");
            purchaseDG.Columns.Add("Quantity", "Quantity");
            purchaseDG.Columns.Add("Sub Total", "Sub Total");
=======
            dgsearchprod.Columns["product_id"].Visible = false;
            dgsearchprod.Columns["product_name"].HeaderText = "Product Name";
            dgsearchprod.Columns["price"].HeaderText = "Price";
>>>>>>> parent of f23151b... asd
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromPurchasing.Show();
        }

        private void purchasingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromPurchasing.Show();
        }

        /*public void loadPurchase()
        {
            String query = "select * from purchase";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseDG.DataSource = dt;

            //purchaseDG.Columns["purchase_id"].Visible = false;
            purchaseDG.Columns["product_name"].HeaderText = "Product Name";

            purchaseDG.Columns["price"].HeaderText = "Price";
            purchaseDG.Columns["quantity"].HeaderText = "Quantity";
            purchaseDG.Columns["purchase_supplier_id"].HeaderText = "Supplier";
            purchaseDG.Columns["purchase_emp_id"].HeaderText = "Employee";
            purchaseDG.Columns["purchase_date"].HeaderText = "Purchase Date";
        }*/

        private void addBtn_Click(object sender, EventArgs e)
        {
                if (pname.Text != "" || priceTxt.Text != "" || pquant.Text != "" || ptotal.Text != "")
                {
                    string firstColumn = pname.Text;
                    string secondColumn = priceTxt.Text;
                    string thirdColumn = pquant.Text;
                    string fourthColumn = ptotal.Text;

                    string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn };

                    purchaseDG.Rows.Add(row);

                    pname.Clear();
                    priceTxt.Clear();
                    pquant.Clear();
                    ptotal.Clear();               
                }
                else
                {
                    MessageBox.Show("Please fill up all the data", "Add Purchase Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        public static int quant;
        public static double tot, p, q;

        private void searchBtn_Click(object sender, EventArgs e)
        {
            spanel.Enabled = true;
            spanel.Visible = true;
            spanel.Location = new Point(140, 56);
            spanel.Size = new Size(681, 297);

            String query = "SELECT supplier_id, contact_person, organization FROM supplier, person where (contact_person like '%" + snameTxt.Text + "%' or contact_person like '%" + snameTxt.Text + "%') and person_type = 'Supplier' and supplier_person_id = person_id";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgsname.DataSource = dt;

            dgsname.Columns["supplier_id"].Visible = false;
            dgsname.Columns["contact_person"].HeaderText = "Name";
            dgsname.Columns["organization"].HeaderText = "Organization";
        }

        public static int supplier_id;
        public static String name;
        private int selected_supplier_id;
        public static int rowIndex;
        private void purchaseData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex > -1)
            {
<<<<<<< HEAD
<<<<<<< HEAD
                selected_supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
=======
                //selected_supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
>>>>>>> parent of f23151b... asd
                pnameTxt.Text = dgsname.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
=======
                //selected_supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                pname.Text = dgsname.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
>>>>>>> a47742ac3f869df61a6a9d8f0b3d0f15ea3e6bf8
                ptotal.Text = dgsname.Rows[e.RowIndex].Cells["price"].Value.ToString();
                pquant.Text = dgsname.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                dateLbl.Text = dgsname.Rows[e.RowIndex].Cells["purchase_date"].Value.ToString();
            }
            */
        }
        private void dgsearchname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                supplier_id = int.Parse(dgsname.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString());
                name = dgsname.Rows[e.RowIndex].Cells["contact_person"].Value.ToString();
                snameTxt.Text = name;

                spanel.Enabled = false;
                spanel.Visible = false;
                spanel.Location = new Point(434, 85);
                spanel.Size = new Size(521, 44);
            }
        }

        private void closename_Click(object sender, EventArgs e)
        {
            spanel.Enabled = false;
            spanel.Visible = false;
            spanel.Location = new Point(434, 85);
            spanel.Size = new Size(521, 44);
        }
        private void dgsearchprod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
<<<<<<< HEAD
        public static int product_id;
        private void dgsearchprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product_id = int.Parse(dgsearchprod.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
            pnameTxt.Text = dgsearchprod.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
            dgsearchprod.Rows[e.RowIndex].Cells["description"].Value.ToString();
            priceTxt.Text = dgsearchprod.Rows[e.RowIndex].Cells["price"].Value.ToString();
           // pnameTxt.Text = prod;
           // ppriceTxt.Text = price;
            prodpanel.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Location = new Point(434, 152);
            prodpanel.Size = new Size(521, 44);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prodpanel.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Location = new Point(434, 152);
            prodpanel.Size = new Size(521, 44);

        }

        private void purchaseData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

=======
        private void priceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(priceTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void pnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private void purchaseDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            DataGridViewRow row = purchaseDG.Rows[rowIndex];

            pname.Text = row.Cells[1].Value.ToString();
            pquant.Text = row.Cells[2].Value.ToString();
            ptotal.Text = row.Cells[3].Value.ToString();
            dateLbl.Text = row.Cells[4].Value.ToString();
            usernameLbl.Text = row.Cells[5].Value.ToString();
            snameTxt.Text = row.Cells[6].Value.ToString();
        }

        private void snameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private void pname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
>>>>>>> a47742ac3f869df61a6a9d8f0b3d0f15ea3e6bf8
        }

        private void priceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(priceTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void pnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(pnameTxt.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
                pnameTxt.Text.Remove(pnameTxt.Text.Length - 1);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.purchaseDG.SelectedRows)
            {
                purchaseDG.Rows.RemoveAt(item.Index);
            }
        }
        private void pquant_TextChanged(object sender, EventArgs e)
        {
            if (pquant.Text != "")
            {
                quant = int.Parse(pquant.Text);
                p = double.Parse(priceTxt.Text);
                q = quant;
                tot = q * p;
                ptotal.Text = tot.ToString();
            }
            else if (pquant.Text == "")
            {
                ptotal.Text = "";
            }
        }
    }
}
