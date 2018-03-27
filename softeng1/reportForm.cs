using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace softeng1
{
    public partial class reportForm : Form
    {
        private MySqlConnection conn;
        public reportForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static transactionsForm fromReportTransactions { get; set; }

        private void reportForm_Load(object sender, EventArgs e)
        {
            /*String getSalesTransaction = "SELECT FIRSTNAME, LASTNAME, ORDER_DISCOUNT, ORDER_DATE, ORDER_STATUS, PRODUCT_NAME, ORDER_UNIT_PRICE, ORDER_TQUANTITY, ORDER_TOTAL " +
                                         "FROM CUSTOMER INNER JOIN PERSON ON CUSTOMER_PERSON_ID = PERSON_ID " +
                                         "INNER JOIN SALES_ORDER ON CUSTOMER_ID = ORDER_CUSTOMER_ID " +
                                         "INNER JOIN SALES_ORDER_DETAILS ON ORDER_ID = SO_ID " +
                                         "INNER JOIN PRODUCT ON PRODUCT_ID = ORDER_PRODUCT_ID ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(getSalesTransaction, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            DataSet dt = new DataSet();
            adp.Fill(dt);        

            SalesReport cryRpt = new SalesReport();
            cryRpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cryRpt;*/
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\msilveo\Documents\GitHub\SAD - 2\SAD - 2 - master\SAD - 2\softeng1\SalesReport.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }        
    }
}
