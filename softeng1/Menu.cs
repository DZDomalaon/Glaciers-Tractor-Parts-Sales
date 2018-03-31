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
    public partial class homeForm : Form
    {
        MySqlConnection conn;
        public homeForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            loginAs.Text = loginForm.name;
        }
        public static loginForm previousForm { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadToolTip();
            loadNotif();
        }

        private void loadNotif()
        {
            String query = "select PRODUCT_NAME, QUANTITY FROM PRODUCT, INVENTORY WHERE INV_PRODUCT_ID = PRODUCT_ID AND QUANTITY <= 10";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            notifData.DataSource = dt;

            notifData.Columns["product_name"].Visible = true;
            notifData.Columns["QUANTITY"].Visible = true;
            notifData.Columns["product_name"].HeaderText = "Product Name";
            notifData.Columns["QUANTITY"].HeaderText = "Quantity";

            if(notifData.Rows.Count > 0)
            {
                exclamation.Visible = true;
            }
            else
            {
                exclamation.Visible = false;
            }

        }

        private void loadToolTip()
        {
            ToolTip salesOrder = new ToolTip();
            salesOrder.UseFading = true;
            salesOrder.UseAnimation = true;
            salesOrder.IsBalloon = true;
            salesOrder.ShowAlways = true;
            salesOrder.SetToolTip(invoiceBtn, "Create New Sales Order");

            ToolTip unpaidInvoice = new ToolTip();
            unpaidInvoice.UseFading = true;
            unpaidInvoice.UseAnimation = true;
            unpaidInvoice.IsBalloon = true;
            unpaidInvoice.ShowAlways = true;
            unpaidInvoice.SetToolTip(unpaidBtn, "Check Customers Unpaid Invoices");

            ToolTip purchasing = new ToolTip();
            purchasing.UseFading = true;
            purchasing.UseAnimation = true;
            purchasing.IsBalloon = true;
            purchasing.ShowAlways = true;
            purchasing.SetToolTip(purchasingBtn, "Create New Purchase Order");

            ToolTip deliveryRep = new ToolTip();
            deliveryRep.UseFading = true;
            deliveryRep.UseAnimation = true;
            deliveryRep.IsBalloon = true;
            deliveryRep.ShowAlways = true;
            deliveryRep.SetToolTip(delivBtn, "Add or Check Delivered Products");

            ToolTip products = new ToolTip();
            products.UseFading = true;
            products.UseAnimation = true;
            products.IsBalloon = true;
            products.ShowAlways = true;
            products.SetToolTip(prodBtn, "Create, View, and Update Product Details");

            ToolTip supplier = new ToolTip();
            supplier.UseFading = true;
            supplier.UseAnimation = true;
            supplier.IsBalloon = true;
            supplier.ShowAlways = true;
            supplier.SetToolTip(supplierBtn, "Create, View, and Update Supplier Details");

            ToolTip customer = new ToolTip();
            customer.UseFading = true;
            customer.UseAnimation = true;
            customer.IsBalloon = true;
            customer.ShowAlways = true;
            customer.SetToolTip(custBtn, "Create, View, and Update Customer Details");

            ToolTip transactions = new ToolTip();
            transactions.UseFading = true;
            transactions.UseAnimation = true;
            transactions.IsBalloon = true;
            transactions.ShowAlways = true;
            transactions.SetToolTip(logBtn, "View Customer and Supplier Transactions");

            ToolTip staff = new ToolTip();
            staff.UseFading = true;
            staff.UseAnimation = true;
            staff.IsBalloon = true;
            staff.ShowAlways = true;
            staff.SetToolTip(usersBtn, "Create, View, and Update Staff Details");

            ToolTip exit = new ToolTip();
            exit.UseFading = true;
            exit.UseAnimation = true;
            exit.IsBalloon = true;
            exit.ShowAlways = true;
            exit.SetToolTip(exitBtn, "Logout");
        }
           
        private void exitBtn_Click(object sender, EventArgs e)
        {          
            this.Hide();
            previousForm.Show();
        }
        private void homeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousForm.Show();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            usersForm user = new usersForm();
            user.Show();
            usersForm.fromUsers = this;
            this.Hide();
        }

        private void invoiceBtn_Click(object sender, EventArgs e)
        {
            orderForm order = new orderForm();
            order.Show();
            orderForm.fromOrder = this;
            this.Hide();
        }
        private void supplierBtn_Click(object sender, EventArgs e)
        {
            supplierForm supplier = new supplierForm();
            supplier.Show();
            supplierForm.fromSupplier = this;
            this.Hide();
        }
        private void warrBtn_Click(object sender, EventArgs e)
        {
            warrantyForm warrant = new warrantyForm();
            warrant.Show();
            warrantyForm.fromWarranty = this;
            this.Hide();
        }

        private void prodBtn_Click_1(object sender, EventArgs e)
        {
            productsForm product = new productsForm();
            product.Show();
            productsForm.fromProduct = this;
            this.Hide();
        }

        private void delivBtn_Click_1(object sender, EventArgs e)
        {
            deliveryForm delivery = new deliveryForm();
            delivery.Show();
            deliveryForm.fromDelivery = this;
            this.Hide();
        }

        private void unpaidBtn_Click(object sender, EventArgs e)
        {
            unpaidForm unpaid = new unpaidForm();
            unpaid.Show();
            unpaidForm.fromUnpaid = this;
            this.Hide();
        }

        private void custBtn_Click_1(object sender, EventArgs e)
        {
            customersForm customer = new customersForm();
            customer.Show();
            customersForm.fromCustomer = this;
            this.Hide();
        }



        private void supplierBtn_MouseHover(object sender, EventArgs e)
        {
            supplierBtn.ForeColor = Color.Black;
        }
        private void supplierBtn_MouseLeave(object sender, EventArgs e)
        {
            supplierBtn.ForeColor = Color.White;
        }
        private void clientBtn_MouseHover(object sender, EventArgs e)
        {
            custBtn.ForeColor = Color.Black;
        }    
        private void clientBtn_MouseLeave(object sender, EventArgs e)
        {
            custBtn.ForeColor = Color.White;
        }    
        private void prodBtn_MouseHover(object sender, EventArgs e)
        {
            prodBtn.ForeColor = Color.Black;
        }
        private void prodBtn_MouseLeave(object sender, EventArgs e)
        {
            prodBtn.ForeColor = Color.White;
        }
        private void logoutBtn_MouseHover(object sender, EventArgs e)
        {
            delivBtn.ForeColor = Color.Black;
        }
        private void logoutBtn_MouseLeave(object sender, EventArgs e)
        {
            delivBtn.ForeColor = Color.White;
        }
        private void staffBtn_MouseHover(object sender, EventArgs e)
        {
            usersBtn.ForeColor = Color.Black;
        }
        private void staffBtn_MouseLeave(object sender, EventArgs e)
        {
            usersBtn.ForeColor = Color.White;
        }

        private void purchasingBtn_Click(object sender, EventArgs e)
        {
            purchasingForm purchase = new purchasingForm();
            purchase.Show();
            purchasingForm.fromPurchasing = this;
            this.Hide();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            settingsForm purchase = new settingsForm();
            purchase.Show();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            transactionsForm trans = new transactionsForm();
            trans.Show();
            transactionsForm.fromTransactions = this;
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            notifPanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifPanel.Visible = true;
            notifBtn2.Visible = true;
            loadNotif();

        }

        private void notifBtn2_Click(object sender, EventArgs e)
        {
            notifPanel.Visible = false;
            notifBtn2.Visible = false;
        }

        private void homePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
