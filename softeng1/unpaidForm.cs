using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using Microsoft.VisualBasic;

namespace softeng1
{
    public partial class unpaidForm : Form
    {
        MySqlConnection conn;
        public unpaidForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
        }
        public static homeForm fromUnpaid { get; set; }

        private void unpaidForm_Load(object sender, EventArgs e)
        {
            loadUnpaidCustomer();
        }

        private void unpaidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromUnpaid.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromUnpaid.Show();
        }
        public void loadUnpaidCustomer()
        {
            String query = "SELECT CONCAT(FIRSTNAME , ' ', LASTNAME), ORDER_TOTAL, DATE(ORDER_DATE), BALANCE, ORDER_ID, ORDER_BALANCE, CREDIT_LIMIT, ORDER_PAYMENT_ID, CUSTOMER_ID from person " +
                           "INNER JOIN CUSTOMER ON PERSON_ID = CUSTOMER_PERSON_ID " +
                           "INNER JOIN SALES_ORDER ON ORDER_CUSTOMER_ID = CUSTOMER_ID " +
                           "INNER JOIN sales_order_details ON ORDER_ID = SO_ID " +
                           "where order_status = 'Unpaid' " +
                           "and(person_id = customer_person_id and person_type = 'customer'); ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            unpaidData.DataSource = dt;
            unpaidData.Columns["ORDER_ID"].Visible = false;
            unpaidData.Columns["CUSTOMER_ID"].Visible = false;
            unpaidData.Columns["ORDER_PAYMENT_ID"].Visible = false; 
            unpaidData.Columns["CONCAT(FIRSTNAME , ' ', LASTNAME)"].HeaderText = "Customer";
            unpaidData.Columns["ORDER_TOTAL"].HeaderText = "Total";
            unpaidData.Columns["ORDER_BALANCE"].HeaderText = "Order Balance";
            unpaidData.Columns["CREDIT_LIMIT"].HeaderText = "Credit Limit";
            unpaidData.Columns["DATE(ORDER_DATE)"].HeaderText = "Date";
            unpaidData.Columns["BALANCE"].HeaderText = "Balance";

        }       
        
        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(amountTxt.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }

        public static int getOrderId;
        public static int getCustomerId;
        public static int getPayment;
        private void paymentBtn_Click(object sender, EventArgs e)
        {
            double payment = double.Parse(amountTxt.Text.ToString());
            DateTime theDate = DateTime.Now;
            string date = theDate.ToString("yyyy-MM-dd");

            conn.Open();
            string updateCustBal = "UPDATE CUSTOMER SET BALANCE = BALANCE - '" + payment + "' WHERE CUSTOMER_ID = '" + getCustomerId +"'";
            MySqlCommand updateCustBalcomm = new MySqlCommand(updateCustBal, conn);
            updateCustBalcomm.ExecuteNonQuery();

            string updateOrderBal = "UPDATE SALES_ORDER SET ORDER_BALANCE = ORDER_BALANCE - '" + payment + "' WHERE ORDER_ID = '" + getOrderId + "'";
            MySqlCommand updateOrderBalcomm = new MySqlCommand(updateOrderBal, conn);
            updateOrderBalcomm.ExecuteNonQuery();

            string updatePayment = "UPDATE PAYMENT SET AMOUNT = AMOUNT + '" + payment + "', PAYMENT_DATE = '" + date + "' WHERE PAYMENT_ID = '" + getPayment+ "'";
            MySqlCommand updatePaymentcomm = new MySqlCommand(updatePayment, conn);
            updatePaymentcomm.ExecuteNonQuery();

            string balance = "";
            String getBalance = "select order_balance from sales_order where order_id = '" + getOrderId + "'";
            MySqlCommand comm = new MySqlCommand(getBalance, conn);
            comm.CommandText = getBalance;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    balance = drd["order_balance"].ToString();
            }
            drd.Close();

            if(balance == "0")
            {
                string updateOrder = "UPDATE SALES_ORDER SET ORDER_STATUS = 'Paid' WHERE ORDER_ID = '" + getOrderId + "'";
                MySqlCommand updateOrdercomm = new MySqlCommand(updateOrder, conn);
                updateOrdercomm.ExecuteNonQuery();
            }            
            conn.Close();
            loadUnpaidCustomer();

            MessageBox.Show("Transaction Complete");
        }

        private void unpaidData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getOrderId = int.Parse(unpaidData.Rows[e.RowIndex].Cells["ORDER_ID"].Value.ToString());
            getCustomerId = int.Parse(unpaidData.Rows[e.RowIndex].Cells["CUSTOMER_ID"].Value.ToString());
            getPayment = int.Parse(unpaidData.Rows[e.RowIndex].Cells["ORDER_PAYMENT_ID"].Value.ToString());
            custnameTxt.Text = unpaidData.Rows[e.RowIndex].Cells["CONCAT(FIRSTNAME , ' ', LASTNAME)"].Value.ToString();
            balanceTxt.Text = unpaidData.Rows[e.RowIndex].Cells["BALANCE"].Value.ToString();
            ordernumTxt.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_ID"].Value.ToString();
            totalTxt.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_TOTAL"].Value.ToString();
            remainingTxt.Text = unpaidData.Rows[e.RowIndex].Cells["ORDER_BALANCE"].Value.ToString();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }
        int printedLines = 0;
        public void function_print()
        {
            unpaidData.ClearSelection();
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

            string viewsales = "Unpaid Invoices";
            e.Graphics.DrawString(viewsales, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 250, 80);

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


            while (printedLines < unpaidData.Rows.Count)
            {

                graphic.DrawString("Customer Name : " + unpaidData.Rows[printedLines].Cells[0].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Total Price : " + unpaidData.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Order Date : " + unpaidData.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Order Balance : " + unpaidData.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
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
    }
}
