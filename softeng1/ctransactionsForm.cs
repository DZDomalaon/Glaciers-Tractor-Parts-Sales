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
        private void transactionsForm_Load(object sender, EventArgs e)
        {
            loadEmp();               
        }
        private void transactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {      
            transactionsForm trans = new transactionsForm();
            trans.Show();
            this.Hide();
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
        public void loadEmployee()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getEmp = "SELECT firstname, lastname FROM person, employee where (concat(firstname,' ',lastname) like '%" + empnameTxt.Text + "%') and person_id = emp_person_id and person_type = 'employee'";
            MySqlCommand comm = new MySqlCommand(getEmp, conn);
            comm.CommandText = getEmp;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
                }
            }

            drd.Close();
            conn.Close();

            empnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            empnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            empnameTxt.AutoCompleteCustomSource = namesCollection;
        }
        public void loadCustData()
        {
            String date = dateTxt.Text;
            String query =
                "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person INNER JOIN customer ON customer_person_id = person_id INNER JOIN sales_order ON order_customer_id = customer_id WHERE order_date LIKE '%" + date + "%'";

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
        private void printBtn_Click(object sender, EventArgs e)
        {
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
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string company = "Glacier Tractor Parts & Sales";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 100, 10);

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

                graphic.DrawString("Customer Name : " + customerData.Rows[printedLines].Cells[0].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Order Date : " + customerData.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Status : " + customerData.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
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
        public void loadEmp()
        {
            string query = "SELECT concat(firstname,' ',lastname) as cname, order_date, order_status FROM person, customer, sales_order " +
                           "WHERE order_customer_id = customer_id " +
                           "AND customer_person_id = person_id " +
                           "AND order_emp_id = (SELECT emp_id FROM employee, person WHERE (concat(firstname, ' ', lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id and person_type = 'employee')";
        }
        private void empnameTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadEmployee();
            loadCustomers();
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            loadCustData();
        }
    }
}
