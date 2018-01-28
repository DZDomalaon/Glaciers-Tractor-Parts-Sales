﻿using System;
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
            String query = "SELECT CONCAT(FIRSTNAME , ' ', LASTNAME), ORDER_TOTAL, ORDER_DATE, (SELECT SUM(BALANCE) FROM CUSTOMER) AS BALANCE from sales_order, person, customer where order_status = 'Unpaid' and person_id = customer_person_id and person_type = 'customer' and order_customer_id = customer_id";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            unpaidData.DataSource = dt;
            unpaidData.Columns["CONCAT(FIRSTNAME , ' ', LASTNAME)"].HeaderText = "Customer";
            unpaidData.Columns["ORDER_TOTAL"].HeaderText = "Total";
            unpaidData.Columns["ORDER_DATE"].HeaderText = "Date";
            unpaidData.Columns["BALANCE"].HeaderText = "Balance";
        }
    }
}
