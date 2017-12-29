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

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromProduct.Show();
            this.Show();
        }

        private void productsForm_Load_1(object sender, EventArgs e)
        {
            loadprod();
        }

        public void loadprod()
        {
            String query = "SELECT product_id, product_name, description, price, warranty, discount, serial, (select pc_category from product_catalogue WHERE INVENTORY_CATALOGUE = pc_id)as category, (select pc_variant from product_catalogue WHERE INVENTORY_CATALOGUE = pc_id)as variant FROM inventory";


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
            prodData.Columns["warranty"].HeaderText = "Warranty";
            prodData.Columns["discount"].HeaderText = "Discount";
            prodData.Columns["serial"].HeaderText = "Serial";
            prodData.Columns["category"].HeaderText = "Category";
            prodData.Columns["variant"].HeaderText = "Variant";

        }

        private void productsForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromProduct.Show();
        }


        private int selected_prod_id;

        private void prodData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_prod_id = int.Parse(prodData.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                pnameTxt.Text = prodData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                pdescTxt.Text = prodData.Rows[e.RowIndex].Cells["description"].Value.ToString();
                discountTxt.Text = prodData.Rows[e.RowIndex].Cells["discount"].Value.ToString();
                categTxt.Text = prodData.Rows[e.RowIndex].Cells["category"].Value.ToString();
                priceTxt.Text = prodData.Rows[e.RowIndex].Cells["price"].Value.ToString();
                warrantyDate.Text = prodData.Rows[e.RowIndex].Cells["warranty"].Value.ToString();
                categTxt.Text = prodData.Rows[e.RowIndex].Cells["category"].Value.ToString();
                variantTxt.Text = prodData.Rows[e.RowIndex].Cells["variant"].Value.ToString();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

            String query = "Update inventory, product_catalogue SET inventory.product_name = '" + pnameTxt.Text + "', inventory.description = '" + pdescTxt.Text + "', inventory.serial = '" + serialTxt.Text + "', product_catalogue.pc_category = '" + categTxt.Text + "', product_catalogue.pc_variant = '" + variantTxt.Text + "', inventory.price = '" + priceTxt.Text + "', inventory.warranty = '" + warrantyDate.Text + "', inventory.discount = '" + discountTxt.Text + "' WHERE product_id = '" + selected_prod_id + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            loadprod();
        }
        
    }
}
