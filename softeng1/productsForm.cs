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
    public partial class productsForm : Form
    {
        MySqlConnection conn;
        public productsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromProduct { get; set; }

        private void productsForm_Load(object sender, EventArgs e)
        {
            loadprod();
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromProduct.Show();
        }
        private void productsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromProduct.Show();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void loadprod()
        {
            String query = "SELECT product_id, product_name, description, price, pc_category , pc_variant, pc_type, serial FROM product, inventory, product_catalogue where product_inv_id = inventory_id and PRODUCT_PC_ID = pc_id";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            prodData.DataSource = dt;
            prodData.Columns["product_id"].Visible = false;
            prodData.Columns["product_name"].HeaderText = "Product Name";
            prodData.Columns["description"].HeaderText = "Description";
            prodData.Columns["price"].HeaderText = "Price";
            prodData.Columns["serial"].HeaderText = "Serial";
            prodData.Columns["pc_category"].HeaderText = "Category";
            prodData.Columns["pc_variant"].HeaderText = "Variant";
            prodData.Columns["pc_type"].HeaderText = "Type";
        }
        
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update the data ?", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String query = "Update product, product_catalogue SET product_name = '" + pnameTxt.Text + "', description = '" + pdescTxt.Text + "', serial = '" + serialTxt.Text + "', product_catalogue.pc_category = '" + categTxt.Text + "', product_catalogue.pc_variant = '" + variantTxt.Text + "', price = '" + priceTxt.Text +"' WHERE product_id = '" + selected_prod_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Your data has been updated successfully", "Updated Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadprod();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (pnameTxt.Text == "" || pdescTxt.Text == "" || serialTxt.Text == "" || categTxt.Text == "" || variantTxt.Text == "" || typeTxt.Text == "" || priceTxt.Text == "" || SupplierCmb.Text == "")
            {
                invalidpanel.Visible = true;
                invalidpanel.Enabled = true;
            }
            else
            {
                string query = "INSERT INTO product(product_name, description, price, serial)" +
                 "VALUES ('" + pnameTxt.Text + "','" + pdescTxt.Text + "','" + priceTxt.Text + "','" + serialTxt.Text + "'); INSERT INTO product_catalogue" +
                 "(pc_category, pc_variant, pc_type) VALUES ('" + categTxt + "','" + variantTxt.Text + "','" + typeTxt.Text + "')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadprod();

                pnameTxt.Text = "";
                pdescTxt.Text = "";
                priceTxt.Text = "";
                serialTxt.Text = "";
                categTxt.Text = "";
                variantTxt.Text = "";
                typeTxt.Text = "";
            }         
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            pnameTxt.Text = "";
            pdescTxt.Text = "";
            priceTxt.Text = "";
            categTxt.Text = "";
            serialTxt.Text = "";
            variantTxt.Text = "";
            typeTxt.Text = "";
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

        private void pnameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters", "Invalid input");
            }
        }

        private int selected_prod_id;
        private void closePanel_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //updPanel.Hide();
        }

        private void prodData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_prod_id = int.Parse(prodData.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                pnameTxt.Text = prodData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                pdescTxt.Text = prodData.Rows[e.RowIndex].Cells["description"].Value.ToString();
                priceTxt.Text = prodData.Rows[e.RowIndex].Cells["price"].Value.ToString();
                serialTxt.Text = prodData.Rows[e.RowIndex].Cells["serial"].Value.ToString();
                categTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_category"].Value.ToString();
                variantTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_variant"].Value.ToString();
                typeTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_type"].Value.ToString();
            }
        }
    }
}
