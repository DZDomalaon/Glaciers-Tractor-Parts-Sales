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
    public partial class ptransactionsForm : Form
    {
        private MySqlConnection conn;
        public ptransactionsForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }

        private void ptransactionsForm_Load(object sender, EventArgs e)
        {
            loadEmp();
        }
        public void loadSuppliers()
        {
            String query = "SELECT purchase_date, organization, status " +
                           "FROM person inner join supplier on supplier_person_id = person_id " +
                           "inner join purchase on purchase_supplier_id = supplier_id " +
                           "AND purchase_emp_id = (SELECT emp_id FROM employee, person " +
                           "WHERE(concat(firstname, ' ', lastname) LIKE '%" + empnameTxt.Text + "%') AND emp_person_id = person_id)";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["purchase_date"].HeaderText = "Purchase Date";
            purchaseData.Columns["organization"].HeaderText = "Organization";
            purchaseData.Columns["status"].HeaderText = "Status";
        }
        public void loadEmployee()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String getEmp = "SELECT firstname, lastname FROM person, employee where (lastname like '%" + empnameTxt.Text + "%' or firstname like '%" + empnameTxt.Text + "%') and person_id = emp_person_id ";
            MySqlCommand comm = new MySqlCommand(getEmp, conn);
            comm.CommandText = getEmp;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }

            drd.Close();
            conn.Close();

            empnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            empnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            empnameTxt.AutoCompleteCustomSource = namesCollection;
        }

        private void empnameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadEmployee();
            }
            catch { }
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            loadSuppData();
        }
        private void ptransactionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            transactionsForm trans = new transactionsForm();
            trans.Show();
            this.Hide();
        }
        public void loadSuppData()
        {
            String date = dateTxt.Text;
            String query =
                "SELECT purchase_date, organization, status FROM person INNER JOIN supplier ON supplier_person_id = person_id INNER JOIN purchase ON purchase_supplier_id = supplier_id WHERE purchase_date LIKE '%" + date + "%'";

            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            purchaseData.DataSource = dt;

            purchaseData.Columns["purchase_date"].HeaderText = "Order Date";
            purchaseData.Columns["organization"].HeaderText = "Organization";
            purchaseData.Columns["status"].HeaderText = "Status";
        }
        public void loadEmp()
        {
            string query = "SELECT organization, purchase_date, status FROM person, supplier, purchase " +
                           "WHERE supplier_person_id = person_id " +
                           "AND customer_person_id = person_id " +
                           "AND purchase_emp_id = (SELECT supplier_id FROM supplier, person WHERE emp_person_id = person_id and person_type = 'employee')";
        }

        private void empnameTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadEmployee();
            loadSuppliers();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }
        int printedLines = 0;
        public void function_print()
        {
            purchaseData.ClearSelection();
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string company = "Glacier Tractor Parts & Sales";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 100, 10);

            string viewsales = "Purchase Report";
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

            while (printedLines < purchaseData.Rows.Count)
            {

                graphic.DrawString("Organization : " + purchaseData.Rows[printedLines].Cells[0].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Purchase Date : " + purchaseData.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
                offsetY += (int)fontHeight + 5;

                graphic.DrawString("Status : " + purchaseData.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX, startY + offsetY);
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
