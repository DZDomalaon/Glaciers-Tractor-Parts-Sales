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

        }      
        private void exitBtn_Click(object sender, EventArgs e)
        {
            String timeOut_query = "UPDATE employee SET time_OUT = TIME(NOW()) where emp_id ='" + loginForm.user_id + "'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(timeOut_query, conn);
            comm.ExecuteNonQuery();
            conn.Close();

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

        private void salesBtn_Click(object sender, EventArgs e)
        {
            salesForm sale = new salesForm();
            sale.Show();
            salesForm.fromSales = this;
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
            settingsForm settings = new settingsForm();
            settings.Show();
            settingsForm.fromSettings = this;
            this.Hide();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            transactionsForm transactions = new transactionsForm();
            transactions.Show();
            transactionsForm.fromTransactions = this;
            this.Hide();
        }
    }
}
