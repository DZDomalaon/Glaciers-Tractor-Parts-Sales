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
using System.Drawing.Printing;


namespace softeng1
{
    public partial class ctransactionsForm : Form
    {
        private MySqlConnection conn;
        public ctransactionsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static homeForm fromTransactions { get; set; }

        private void transactionsForm_Load(object sender, EventArgs e)
        {
            loadEmployee();
            //loadSuppliers();
            loadCustData();                 
        }

        private void transactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromTransactions.Show();
        }

        public void loadCustomers()
        {
            String query = "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order WHERE order_customer_id = customer_id AND customer_person_id = person_id AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname,' ',lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id and person_type = 'employee')";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;

            customerData.Columns["order_date"].HeaderText = "Order Date";
            customerData.Columns["cname"].HeaderText = "Customer";
            customerData.Columns["order_status"].HeaderText = "Status"; 
        }
        //public void loadSuppliers()
        //{
        //    String query = "SELECT concat(firstname,' ',lastname) as sname, purchase_date, status " + 
        //                   "FROM person inner join supplier on supplier_person_id = person_id " +
        //                   "inner join purchase on purchase_supplier_id = supplier_id " +
        //                   "AND purchase_emp_id = (SELECT emp_id FROM employee, person " +
        //                   "WHERE(concat(firstname, ' ', lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id)";

        //    conn.Open();
        //    MySqlCommand comm = new MySqlCommand(query, conn);
        //    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
        //    conn.Close();
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);

        //    purchaseData.DataSource = dt;

        //    purchaseData.Columns["purchase_date"].HeaderText = "Purchase Date";
        //    purchaseData.Columns["sname"].HeaderText = "Supplier";
        //    purchaseData.Columns["status"].HeaderText = "Status";
        //}
        public void loadEmployee()
        {
            conn.Open();

            String getEmp = "SELECT firstname, lastname FROM person, employee where (lastname like '%" + transactionEmp.Text + "%' or firstname like '%" + empnameTxt.Text + "%') and person_id = emp_person_id ";
            MySqlCommand comm = new MySqlCommand(getEmp, conn);
            comm.CommandText = getEmp;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    transactionEmp.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
                }                    
            }

            drd.Close();
            conn.Close();
        }

        private void empnameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadEmployee();
            }
            catch { }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromTransactions.Show();
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            loadCustData();
        }
        public void loadCustData()
        {
            String date = dateTxt.Text;
            String query =
                "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order, employee WHERE order_date LIKE '%" + date + "%' AND order_customer_id = customer_id AND customer_person_id = person_id AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname,' ',lastname) like '%" + empnameTxt.Text + "%') AND person_id = emp_person_id)";

            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            customerData.DataSource = dt;

            customerData.Columns["order_date"].HeaderText = "Order Date";
            customerData.Columns["cname"].HeaderText = "Customer";
            customerData.Columns["order_status"].HeaderText = "Status";
        }

        //private void backBtn_Click_1(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    fromTransactions.Show();
        //}

        private void printBtn_Click(object sender, EventArgs e)
        {
            //reportForm report = new reportForm();
            //report.Show();
            //reportForm.fromReportTransactions = this;
            function_print();
        }
        int printedLines = 0;
        public void function_print()
        {
            customerData.ClearSelection();
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
        private void empnameTxt_Enter(object sender, EventArgs e)
        {
            loadCustomers();
            //loadSuppliers();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string company = "Glacier Tractor Parts & Sales";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 180, 10);

            string viewsales = "Sales Report";
            e.Graphics.DrawString(viewsales, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 320, 80);

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


            while (printedLines < customerData.Rows.Count)
            {

                graphic.DrawString("Order Date : " + customerData.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Customer Name : " + customerData.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Status : " + customerData.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                //graphic.DrawString("Date: " + customerData.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                //offsetY += (int)fontHeight + 10;

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
        public void loadEmp()
        {
            string query = "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order " +
                           "WHERE order_customer_id = customer_id " +
                           "AND customer_person_id = person_id " +
                           "AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname, ' ', lastname) LIKE '%" + transactionEmp.Text + "%') AND emp_person_id = person_id and person_type = 'employee')";


        }
    }
}
