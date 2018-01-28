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

namespace softeng1
{
    public partial class orderForm : Form
    {
        MySqlConnection conn;
        public orderForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static int customer_id, rowIndex, product_id, availableStock, quan, countProduct, quant;
        public static String prod, price, ln, fn, getPrice;
        public static double tot, p, q;

        public static homeForm fromOrder { get; set; }
        private void backBtn_Click(object sender, EventArgs e)
        {
            fromOrder.Show();
            this.Hide();
        }

        private void orderForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");

            buyPanel.Visible = false;
            stockLbl.Visible = false;
            loadCustomer();
            loadProduct();            
        }
     

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }
        
        //AutoComplete for customer
        public void loadCustomer()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getCustomer = "SELECT firstname, lastname FROM person, customer where (lastname like '%" + custnameTxt.Text + "%' or firstname like '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ";
            MySqlCommand comm = new MySqlCommand(getCustomer, conn);
            comm.CommandText = getCustomer;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }

            drd.Close();
            conn.Close();

            custnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            custnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            custnameTxt.AutoCompleteCustomSource = namesCollection;
        }
        
        //AutoComplete for product
        public void loadProduct()
        {
            AutoCompleteStringCollection productsCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getProduct = "SELECT PRODUCT_NAME, PRICE FROM PRODUCT";
            MySqlCommand comm = new MySqlCommand(getProduct, conn);
            comm.CommandText = getProduct;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    productsCollection.Add(drd["PRODUCT_NAME"].ToString());
                }                                        
            }

            drd.Close();            
            conn.Close();            

            productnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            productnameTxt.AutoCompleteCustomSource = productsCollection;
        }
        
        //Load product price
        public void productPrice()
        {
            conn.Open();

            String getPrice = "SELECT PRICE FROM PRODUCT WHERE PRODUCT_NAME = '" + productnameTxt.Text +"'";
            MySqlCommand comm = new MySqlCommand(getPrice, conn);
            comm.CommandText = getPrice;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    ppriceTxt.Text = drd["PRICE"].ToString();
                }                                   
            }

            drd.Close();
            conn.Close();


        }

        //Check product quantity
        public void productQuantity()
        {
            conn.Open();
            MySqlCommand getQuantity = new MySqlCommand("select quantity from inventory, product where product_name = '" + productnameTxt.Text + "' and inventory_id = product_inv_id", conn);
            availableStock = Convert.ToInt32(getQuantity.ExecuteScalar());
            conn.Close();

            stockLbl.Visible = true;
            stockLbl.Text = "The available stock is only " + availableStock;
        }

        //calculate quantity * price
        private void pquant_TextChanged(object sender, EventArgs e)
        {
            if (pquant.Text != "")
            {
                quant = int.Parse(pquant.Text);
                p = double.Parse(ppriceTxt.Text);
                q = quant;
                tot = q * p;
                ptotal.Text = tot.ToString("#,0.00");
            }
            else if (pquant.Text == "")
            {
                ptotal.Text = "";
            }
        }

        private void cashTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(cashTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //Filter for productnameTxt
        private void productnameTxt_TextChanged(object sender, EventArgs e)
        {           
            conn.Open();
            MySqlCommand getProduct = new MySqlCommand("SELECT COUNT(*) FROM PRODUCT WHERE PRODUCT_NAME = '" + productnameTxt.Text + "'", conn);
            countProduct = Convert.ToInt16(getProduct.ExecuteScalar());
            conn.Close();
            
            if (productnameTxt.Text == "" || countProduct == 0)
            {
                ppriceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();
                stockLbl.Visible = false;
            }
            else
            {
                productPrice();
                productQuantity();
            }            
        }

        private void orderForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (orderDG.Rows.Count == 0)
            {
                MessageBox.Show("Cannot check out because cart is empty", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                buyPanel.Visible = true;
                buyPanel.Enabled = true;
                BuydateLbl.Text = DateTime.Now.Date.ToString("MM-dd-yyyy");
            }
                
        }

        //pass all data from Datagridview to textboxes
        private void orderDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex; 
            DataGridViewRow row = orderDG.Rows[rowIndex];

            productnameTxt.Text = row.Cells[0].Value.ToString();
            ppriceTxt.Text = row.Cells[1].Value.ToString();            
            ptotal.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
        }

        //Confirm order
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int maxOrderId = 0;
            int OrderIncrement = 0;
            int maxPaymentId = 0;
            int PaymentInc = 0;
            int prod_id = 0;

            conn.Open();
            //Get max id from sales_order
            MySqlCommand maxIDOrder = new MySqlCommand("SELECT MAX(order_id) FROM SALES_ORDER", conn);
            maxOrderId = Convert.ToInt16(maxIDOrder.ExecuteScalar());
            OrderIncrement = maxOrderId + 1;            

            //Get max id fron payment
            MySqlCommand maxIDPayment = new MySqlCommand("SELECT MAX(payment_id) FROM payment", conn);
            maxPaymentId = Convert.ToInt16(maxIDPayment.ExecuteScalar());
            PaymentInc = maxPaymentId;

            //Get customer id
            MySqlCommand getCustomerID = new MySqlCommand("SELECT customer_id FROM customer, person where (CONCAT(FIRSTNAME, ' ', LASTNAME) LIKE '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ", conn);
            customer_id = Convert.ToInt16(getCustomerID.ExecuteScalar());

            conn.Close();

            //Insert data to sales_order        
            double total = double.Parse(totalpriceTxt.Text.ToString());
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                conn.Open();
                //Get all product id
                MySqlCommand getProduct_id = new MySqlCommand("SELECT PRODUCT_ID FROM PRODUCT WHERE (PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')", conn);
                prod_id = Convert.ToInt32(getProduct_id.ExecuteScalar());                

                using (conn)
                {
                    if (paymentCmb.Text == "Cash")
                    {
                        if(int.Parse(cashTxt.Text.ToString()) >= total)
                        {                            
                            //insert payment amount
                            String insertToPayment = "INSERT INTO PAYMENT(AMOUNT) VALUES('" + cashTxt.Text + "')";
                            MySqlCommand comm = new MySqlCommand(insertToPayment, conn);
                            comm.ExecuteNonQuery();                            

                            using (MySqlCommand addToSales = new MySqlCommand("INSERT INTO sales_order(order_id,ORDER_price, order_subtotal, order_total, order_subquantity, order_tquantity, order_date, order_status, order_customer_id, order_emp_id, order_payment_id, order_product_id) VALUES('" + OrderIncrement + "', @Price, @Subtotal, '" + total + "', @Quantity, '" + totalQuanatity() + "', '" + BuydateLbl.Text + "', 'Paid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "', '" + prod_id + "')", conn))
                            {

                                addToSales.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                                addToSales.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                                addToSales.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                                addToSales.ExecuteNonQuery();
                            }

                            //deduct quantity
                            quan = int.Parse(row.Cells[3].Value.ToString());
                            string deductQuantity = "UPDATE INVENTORY SET QUANTITY = QUANTITY - '" + quan + "' WHERE INVENTORY_ID = (SELECT PRODUCT_INV_ID FROM PRODUCT WHERE PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')";
                            MySqlCommand comm2 = new MySqlCommand(deductQuantity, conn);
                            comm2.ExecuteNonQuery();
                            MessageBox.Show("Trasaction complete");

                            custnameTxt.Clear();
                            buyPanel.Hide();
                            cashTxt.Clear();
                            discountTxt.Clear();
                            interestTxt.Clear();
                            paymentCmb.Text = " ";
                            this.orderDG.Rows.Clear();
                        }
                        else if(int.Parse(cashTxt.Text.ToString()) < total)
                        {
                            MessageBox.Show("Cash amount is not enough", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else if(paymentCmb.Text == "Credit")
                    {
                        using (MySqlCommand addToSales = new MySqlCommand("INSERT INTO sales_order(order_id,ORDER_price, order_subtotal, order_total, order_subquantity, order_tquantity, order_date, order_status, order_customer_id, order_emp_id, order_payment_id, order_product_id) VALUES('" + OrderIncrement + "', @Price, @Subtotal, '" + total + "', @Quantity, '" + totalQuanatity() + "', '" + dateLbl.Text + "', 'Unpaid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "', '" + prod_id + "')", conn))
                        {

                            addToSales.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                            addToSales.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                            addToSales.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                            addToSales.ExecuteNonQuery();
                        }
                        MessageBox.Show("Records inserted.");

                        custnameTxt.Clear();
                        buyPanel.Hide();
                        cashTxt.Clear();
                        discountTxt.Clear();
                        interestTxt.Clear();
                        paymentCmb.Text = " ";

                        this.orderDG.Rows.Clear();
                    }
                    
                }
                conn.Close();
            }            
        }

        private void paymentCmb_TextChanged(object sender, EventArgs e)
        {
            if (paymentCmb.Text == "Cash")
            {
                cashTxt.Enabled = true;
                discountTxt.Enabled = true;
                interestTxt.Enabled = false;
            }
            else if (paymentCmb.Text == "Credit")
            {
                cashTxt.Enabled = false;
                discountTxt.Enabled = false;
                interestTxt.Enabled = true;
            }
        }

        private void buyBackBtn_Click(object sender, EventArgs e)
        {
            buyPanel.Hide();
        }

        //update the values of data from Datagrid
        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updRow = orderDG.Rows[rowIndex];

            updRow.Cells[0].Value = productnameTxt.Text;
            updRow.Cells[1].Value = ppriceTxt.Text;
            updRow.Cells[2].Value = pquant.Text;
            updRow.Cells[3].Value = ptotal.Text;
            calcSum();
        }

        //Add order to Datagrid
        private void addOrder_Click(object sender, EventArgs e)
        {
            if (custnameTxt.Text == "" || productnameTxt.Text == "" || ppriceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Customer Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                MySqlCommand getQuantity = new MySqlCommand("select quantity from inventory, product where product_name = '" + productnameTxt.Text + "' and inventory_id = product_inv_id", conn);
                availableStock = Convert.ToInt32(getQuantity.ExecuteScalar());
                conn.Close();


                if(availableStock >= int.Parse(pquant.Text.ToString()))
                {
                    string firstColumn = productnameTxt.Text;
                    string secondColumn = ppriceTxt.Text;
                    string thirdColumn = ptotal.Text;
                    string fourthColumn = pquant.Text;
                    string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn };

                    orderDG.Rows.Add(row);

                    productnameTxt.Clear();
                    ppriceTxt.Clear();
                    pquant.Clear();
                    ptotal.Clear();
                    paymentCmb.Text = "";
                    calcSum();

                    stockLbl.Visible = false;
                }
                else
                {
                    MessageBox.Show("The available stock is only " + availableStock, "Not enough stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //Remove the selected row
        private void removeOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.orderDG.SelectedRows)
            {
                orderDG.Rows.RemoveAt(item.Index);
                calcSum();
            }
        }

        //Calculate the total price
        private void calcSum()
        {
            double a = 0, b = 0;
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                a = Convert.ToDouble(row.Cells[2].Value);
                b = b + a;
            }
            totalpriceTxt.Text = b.ToString("#,0.00");
        }

        //Calculate the total quantity
        private int totalQuanatity()
        {
            int a = 0, b = 0;
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                a = int.Parse(row.Cells[3].Value.ToString());
                b = b + a;
            }
            return b;
        }

    }
}
