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
using Microsoft.VisualBasic;
using System.Drawing.Printing;

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
            addSupplier.Visible = false;
            loadprod();
            loadSupplierData();
            loadDamadeg();
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

        //load supplier
        public void loadSupplierData()
        {
            String query = "SELECT ORGANIZATION FROM SUPPLIER";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            SupplierCmb.Items.Clear();
            while (drd.Read())
            {

                SupplierCmb.Items.Add(drd["ORGANIZATION"].ToString());
            }
            conn.Close();
        }

        public void loadprod()
        {
            String query = "SELECT product_name, organization, product_id, product_pc_id, pc_category , pc_variant, pc_type, description, quantity, inventory_id, price, discount, serial FROM product " +
                           "inner join product_catalogue on PRODUCT_PC_ID = pc_id " +
                           "inner join product_has_supplier on product_id = PHS_PRODUCT_ID " +
                           "inner join supplier on PHS_SUPPLIER_ID = SUPPLIER_ID " +
                           "inner join person on SUPPLIER_PERSON_ID = person_id " +
                           "inner join inventory on inv_product_id = product_id " +
                           "group by product_name";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            prodData.DataSource = dt;
            prodData.Columns["product_id"].Visible = false;
            prodData.Columns["organization"].Visible = false;
            prodData.Columns["inventory_id"].Visible = false;
            prodData.Columns["product_pc_id"].Visible = false;
            prodData.Columns["discount"].Visible = false;
            prodData.Columns["product_name"].HeaderText = "Product Name";
            prodData.Columns["description"].HeaderText = "Description";
            prodData.Columns["price"].HeaderText = "Price";
            prodData.Columns["serial"].HeaderText = "Serial";
            prodData.Columns["pc_category"].HeaderText = "Category";
            prodData.Columns["pc_variant"].HeaderText = "Variant";
            prodData.Columns["pc_type"].HeaderText = "Type";
            prodData.Columns["quantity"].HeaderText = "Quantity";
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update the data ?", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String query = "Update product, product_catalogue SET product_name = '" + pnameTxt.Text + "', description = '" + pdescTxt.Text + "', serial = '" + serialTxt.Text + "', pc_category = '" + categTxt.Text + "', pc_variant = '" + variantTxt.Text + "', pc_type = '" + typeTxt.Text + "', price = '" + priceTxt.Text + "' WHERE product_id = '" + selected_prod_id + "' and pc_id = '" + selected_pc_id + "'";

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
                int maxProdID, ProdCatID, supId;

                conn.Open();

                //SuppID
                string selectSupplier = "SELECT SUPPLIER_ID FROM SUPPLIER WHERE ORGANIZATION = '" + SupplierCmb.Text + "'";
                MySqlCommand selectSuppliercomm = new MySqlCommand(selectSupplier, conn);
                supId = Convert.ToInt32(selectSuppliercomm.ExecuteScalar());

                //insert pROD CATALOGUE
                string insertPC = "INSERT INTO product_catalogue(pc_category, pc_variant, pc_type) VALUES('" + categTxt.Text + "', '" + variantTxt.Text + "', '" + typeTxt.Text + "')";
                MySqlCommand insertPCComm = new MySqlCommand(insertPC, conn);
                insertPCComm.ExecuteNonQuery();

                //max PC_ID
                MySqlCommand maxPcId = new MySqlCommand("SELECT MAX(pc_id) FROM product_catalogue", conn);
                ProdCatID = Convert.ToInt16(maxPcId.ExecuteScalar());

                //insert product
                string query = "INSERT INTO product(product_name, description, price, serial, product_pc_id)" +
                 "VALUES ('" + pnameTxt.Text + "','" + pdescTxt.Text + "','" + double.Parse(priceTxt.Text) + "','" + serialTxt.Text + "', '" + ProdCatID + "')";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                

                //max product ID
                MySqlCommand maxID = new MySqlCommand("SELECT MAX(product_id) FROM product", conn);
                maxProdID = Convert.ToInt16(maxID.ExecuteScalar());

                //insert product to inventory
                string insertPurch = "INSERT INTO inventory(quantity, inv_product_id) VALUES(0, '" + maxProdID + "')";
                MySqlCommand insertPurchComm = new MySqlCommand(insertPurch, conn);
                insertPurchComm.ExecuteNonQuery();

                //insert tp PHS
                string insertPhs = "INSERT INTO PRODUCT_HAS_SUPPLIER VALUES('" + maxProdID + "', '" + supId + "')";
                MySqlCommand insertPhsComm = new MySqlCommand(insertPhs, conn);
                insertPhsComm.ExecuteNonQuery();

                conn.Close();

                pnameTxt.Text = "";
                pdescTxt.Text = "";
                priceTxt.Text = "";
                serialTxt.Text = "";
                categTxt.Text = "";
                variantTxt.Text = "";
                typeTxt.Text = "";
                SupplierCmb.Text = "";

                loadprod();
                loadSupplierData();
            }
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            pnameTxt.Clear();
            pdescTxt.Clear();
            priceTxt.Clear();
            categTxt.Text = "";
            serialTxt.Clear();
            variantTxt.Text = "";
            typeTxt.Text = "";
            SupplierCmb.Text = "";
            addSupplier.Visible = false;
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

        private void closePanel_Click(object sender, EventArgs e)
        {
            invalidpanel.Hide();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //updPanel.Hide();
        }

        private int selected_prod_id;
        private int selected_pc_id;
        public int selected_inv_id, prodQuant;
        private void prodData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = true;
            editBtn.Enabled = true;
            addSupplier.Visible = true;
            if (e.RowIndex > -1)
            {
                selected_prod_id = int.Parse(prodData.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                selected_inv_id = int.Parse(prodData.Rows[e.RowIndex].Cells["inventory_id"].Value.ToString());
                selected_pc_id = int.Parse(prodData.Rows[e.RowIndex].Cells["product_pc_id"].Value.ToString());
                pnameTxt.Text = prodData.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                pdescTxt.Text = prodData.Rows[e.RowIndex].Cells["description"].Value.ToString();
                priceTxt.Text = prodData.Rows[e.RowIndex].Cells["price"].Value.ToString();
                serialTxt.Text = prodData.Rows[e.RowIndex].Cells["serial"].Value.ToString();
                categTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_category"].Value.ToString();
                variantTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_variant"].Value.ToString();
                typeTxt.Text = prodData.Rows[e.RowIndex].Cells["pc_type"].Value.ToString();
                discountTxt.Text = prodData.Rows[e.RowIndex].Cells["discount"].Value.ToString();
                SupplierCmb.Text = prodData.Rows[e.RowIndex].Cells["organization"].Value.ToString();
                quantityTxt.Text = prodData.Rows[e.RowIndex].Cells["quantity"].Value.ToString();

                string viewQuantity = "SELECT QUANTITY FROM INVENTORY WHERE INV_PRODUCT_ID = '" + selected_prod_id + "'";
                conn.Open();
                MySqlCommand viewQuantitycomm = new MySqlCommand(viewQuantity, conn);
                prodQuant = Convert.ToInt32(viewQuantitycomm.ExecuteScalar());
                conn.Close();
                quantityTxt.Text = prodQuant.ToString();
            }
        }

        private void addDmg_Click(object sender, EventArgs e)
        {
            DateTime theDate = DateTime.Now;
            string formatForMySql = theDate.ToString("yyyy-MM-dd");

            string query = "INSERT INTO DAMAGED_ITEMS(DI_QUANTITY, DI_DATE, PRODUCT_PRODUCT_ID, INVENTORY_INVENTORY_ID)" +
                    "VALUES ('" + int.Parse(numberDmg.Value.ToString()) + "','" + formatForMySql + "','" + selected_prod_id + "','" + selected_inv_id + "')";

            string updateDmg = "Update inventory set quantity = quantity - '" + int.Parse(numberDmg.Value.ToString()) + "' where inventory_id = '" + selected_inv_id + "'";                   

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();

            MySqlCommand updateDmgcomm = new MySqlCommand(updateDmg, conn);
            updateDmgcomm.ExecuteNonQuery();
            conn.Close();

            loadDamadeg();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }
        int printedLines = 0;
        public void function_print()
        {
            prodData.ClearSelection();
            printedLines = 0;


            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 850, 1100);

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.Show();

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            else
            {
                printPreviewDialog1.Show();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string company = "Glacier Tractor Parts & Sales";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 100, 10);

            string viewsales = "Product List";
            e.Graphics.DrawString(viewsales, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 270, 80);

            e.HasMorePages = false;

            Graphics graphic = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 13);

            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);

            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            float fontHeight = font.GetHeight();

            int startY = 160;
            int offsetY = 0;

            int startX = 1;


            while (printedLines < prodData.Rows.Count)
            {

                graphic.DrawString("Product Name : " + prodData.Rows[printedLines].Cells[0].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Category : " + prodData.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Variant : " + prodData.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Type : " + prodData.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Quantity : " + prodData.Rows[printedLines].Cells[7].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);

                ++printedLines;

                if (offsetY >= 700)
                {
                    e.HasMorePages = true;
                    offsetY = 0;
                    return;
                }
            }
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            int supplierId = 0;
            int getSupplierId = 0;

            int PHSresult = 0;
            int getPHSCount = 0;

            conn.Open();
            MySqlCommand selectSupplier = new MySqlCommand("SELECT SUPPLIER_ID FROM SUPPLIER WHERE ORGANIZATION = '" + SupplierCmb.Text + "'", conn);
            supplierId = Convert.ToInt32(selectSupplier.ExecuteScalar());
            getSupplierId = supplierId;

            MySqlCommand countPHS = new MySqlCommand("SELECT COUNT(*) FROM PRODUCT_HAS_SUPPLIER WHERE PHS_PRODUCT_ID = '" + selected_prod_id + "' AND PHS_SUPPLIER_ID = '" + getSupplierId + "'", conn);
            PHSresult = Convert.ToInt32(countPHS.ExecuteScalar());
            getPHSCount = PHSresult;

            if(getPHSCount > 0)
            {
                MessageBox.Show("This supplier is already assigned to the selected product");
            }
            else
            {
                String insertToPHS = "INSERT INTO PRODUCT_HAS_SUPPLIER(PHS_PRODUCT_ID, PHS_SUPPLIER_ID) VALUES('" + selected_prod_id + "', '" + getSupplierId + "')";
                MySqlCommand insertToPHSComm = new MySqlCommand(insertToPHS, conn);
                insertToPHSComm.ExecuteNonQuery();

                MessageBox.Show(SupplierCmb.Text + " is the new supplier of " + pnameTxt.Text);
            }

            conn.Close();
        }

        public void loadDamadeg()
        {
        
        String query = "SELECT product_name, di_quantity, di_date FROM product " +
                        "inner join damaged_items on PRODUCT_PRODUCT_ID = PRODUCT_ID " +
                        "inner join product_has_supplier on phs_product_id = product_id";

        conn.Open();
        MySqlCommand comm = new MySqlCommand(query, conn);
        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
        conn.Close();
        DataTable dt = new DataTable();
        adp.Fill(dt);

        dprodData.DataSource = dt;
        dprodData.Columns["product_name"].HeaderText = "Product Name";
        dprodData.Columns["di_quantity"].HeaderText = "Quantity";
        dprodData.Columns["di_date"].HeaderText = "Date Stocked out";     
        }
    }
}
