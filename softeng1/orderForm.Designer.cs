namespace softeng1
{
    partial class orderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.custfnameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnameTxt = new System.Windows.Forms.TextBox();
            this.sprodTxt = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ppriceTxt = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.dateTxt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.addOrder = new System.Windows.Forms.Button();
            this.removeOrder = new System.Windows.Forms.Button();
            this.backToMenu = new System.Windows.Forms.Button();
            this.snameTxt = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.totalpriceTxt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.namepanel = new System.Windows.Forms.Panel();
            this.dgsearchname = new System.Windows.Forms.DataGridView();
            this.prodpanel = new System.Windows.Forms.Panel();
            this.dgsearchprod = new System.Windows.Forms.DataGridView();
            this.pquant = new System.Windows.Forms.TextBox();
            this.ptotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.namepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsearchname)).BeginInit();
            this.prodpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsearchprod)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(244)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(955, 47);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 47);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "GLACIER TRACTOR\r\nPARTS AND SALES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer Details";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 38);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(434, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(521, 38);
            this.panel4.TabIndex = 6;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Products Ordered";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(434, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(521, 502);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // custfnameTxt
            // 
            this.custfnameTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custfnameTxt.Location = new System.Drawing.Point(89, 106);
            this.custfnameTxt.Name = "custfnameTxt";
            this.custfnameTxt.Size = new System.Drawing.Size(223, 27);
            this.custfnameTxt.TabIndex = 8;
            this.custfnameTxt.TextChanged += new System.EventHandler(this.custfnameTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(0, 152);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(435, 38);
            this.panel5.TabIndex = 11;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Product Details";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "Product\r\nName";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pnameTxt
            // 
            this.pnameTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnameTxt.Location = new System.Drawing.Point(89, 208);
            this.pnameTxt.Name = "pnameTxt";
            this.pnameTxt.Size = new System.Drawing.Size(223, 27);
            this.pnameTxt.TabIndex = 13;
            this.pnameTxt.TextChanged += new System.EventHandler(this.pnameTxt_TextChanged);
            // 
            // sprodTxt
            // 
            this.sprodTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.sprodTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sprodTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sprodTxt.ForeColor = System.Drawing.Color.White;
            this.sprodTxt.Location = new System.Drawing.Point(337, 204);
            this.sprodTxt.Name = "sprodTxt";
            this.sprodTxt.Size = new System.Drawing.Size(78, 31);
            this.sprodTxt.TabIndex = 14;
            this.sprodTxt.Text = "Search";
            this.sprodTxt.UseVisualStyleBackColor = false;
            this.sprodTxt.Click += new System.EventHandler(this.sprodTxt_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 46);
            this.label7.TabIndex = 15;
            this.label7.Text = "Product\r\nPrice";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // ppriceTxt
            // 
            this.ppriceTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppriceTxt.Location = new System.Drawing.Point(89, 268);
            this.ppriceTxt.Name = "ppriceTxt";
            this.ppriceTxt.Size = new System.Drawing.Size(223, 27);
            this.ppriceTxt.TabIndex = 16;
            this.ppriceTxt.TextChanged += new System.EventHandler(this.ppriceTxt_TextChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(0, 367);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(435, 38);
            this.panel6.TabIndex = 12;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Encoder Details";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 46);
            this.label9.TabIndex = 17;
            this.label9.Text = "User\r\nName";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // userTxt
            // 
            this.userTxt.Enabled = false;
            this.userTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTxt.Location = new System.Drawing.Point(89, 418);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(223, 27);
            this.userTxt.TabIndex = 18;
            this.userTxt.TextChanged += new System.EventHandler(this.userTxt_TextChanged);
            // 
            // dateTxt
            // 
            this.dateTxt.AutoSize = true;
            this.dateTxt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTxt.ForeColor = System.Drawing.Color.Black;
            this.dateTxt.Location = new System.Drawing.Point(12, 476);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.Size = new System.Drawing.Size(46, 23);
            this.dateTxt.TabIndex = 19;
            this.dateTxt.Text = "Date";
            this.dateTxt.Click += new System.EventHandler(this.dateTxt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 23);
            this.label10.TabIndex = 21;
            this.label10.Text = "Quantity";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // addOrder
            // 
            this.addOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.addOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addOrder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addOrder.ForeColor = System.Drawing.Color.White;
            this.addOrder.Location = new System.Drawing.Point(54, 527);
            this.addOrder.Name = "addOrder";
            this.addOrder.Size = new System.Drawing.Size(92, 37);
            this.addOrder.TabIndex = 23;
            this.addOrder.Text = "Add";
            this.addOrder.UseVisualStyleBackColor = false;
            this.addOrder.Click += new System.EventHandler(this.addOrder_Click);
            // 
            // removeOrder
            // 
            this.removeOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(80)))), ((int)(((byte)(34)))));
            this.removeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeOrder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeOrder.ForeColor = System.Drawing.Color.White;
            this.removeOrder.Location = new System.Drawing.Point(152, 527);
            this.removeOrder.Name = "removeOrder";
            this.removeOrder.Size = new System.Drawing.Size(92, 37);
            this.removeOrder.TabIndex = 24;
            this.removeOrder.Text = "Remove";
            this.removeOrder.UseVisualStyleBackColor = false;
            this.removeOrder.Click += new System.EventHandler(this.removeOrder_Click);
            // 
            // backToMenu
            // 
            this.backToMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.backToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToMenu.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToMenu.ForeColor = System.Drawing.Color.White;
            this.backToMenu.Location = new System.Drawing.Point(250, 527);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(92, 37);
            this.backToMenu.TabIndex = 25;
            this.backToMenu.Text = "Back";
            this.backToMenu.UseVisualStyleBackColor = false;
            this.backToMenu.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // snameTxt
            // 
            this.snameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.snameTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snameTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snameTxt.ForeColor = System.Drawing.Color.White;
            this.snameTxt.Location = new System.Drawing.Point(337, 103);
            this.snameTxt.Name = "snameTxt";
            this.snameTxt.Size = new System.Drawing.Size(78, 30);
            this.snameTxt.TabIndex = 10;
            this.snameTxt.Text = "Search";
            this.snameTxt.UseVisualStyleBackColor = false;
            this.snameTxt.Click += new System.EventHandler(this.snameTxt_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.panel7.Controls.Add(this.totalpriceTxt);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.ForeColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(434, 551);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(521, 38);
            this.panel7.TabIndex = 7;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // totalpriceTxt
            // 
            this.totalpriceTxt.AutoSize = true;
            this.totalpriceTxt.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalpriceTxt.Location = new System.Drawing.Point(258, 8);
            this.totalpriceTxt.Name = "totalpriceTxt";
            this.totalpriceTxt.Size = new System.Drawing.Size(48, 22);
            this.totalpriceTxt.TabIndex = 1;
            this.totalpriceTxt.Text = "0.00";
            this.totalpriceTxt.Click += new System.EventHandler(this.totalpriceTxt_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(189, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total: ";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // namepanel
            // 
            this.namepanel.Controls.Add(this.dgsearchname);
            this.namepanel.Enabled = false;
            this.namepanel.Location = new System.Drawing.Point(434, 85);
            this.namepanel.Name = "namepanel";
            this.namepanel.Size = new System.Drawing.Size(521, 44);
            this.namepanel.TabIndex = 26;
            this.namepanel.Visible = false;
            this.namepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.namepanel_Paint);
            // 
            // dgsearchname
            // 
            this.dgsearchname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsearchname.Location = new System.Drawing.Point(12, 11);
            this.dgsearchname.Name = "dgsearchname";
            this.dgsearchname.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgsearchname.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsearchname.Size = new System.Drawing.Size(657, 488);
            this.dgsearchname.TabIndex = 0;
            this.dgsearchname.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsearchname_CellClick);
            this.dgsearchname.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsearchname_CellContentClick);
            // 
            // prodpanel
            // 
            this.prodpanel.Controls.Add(this.dgsearchprod);
            this.prodpanel.Enabled = false;
            this.prodpanel.Location = new System.Drawing.Point(434, 152);
            this.prodpanel.Name = "prodpanel";
            this.prodpanel.Size = new System.Drawing.Size(521, 44);
            this.prodpanel.TabIndex = 27;
            this.prodpanel.Visible = false;
            // 
            // dgsearchprod
            // 
            this.dgsearchprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsearchprod.Location = new System.Drawing.Point(9, 9);
            this.dgsearchprod.Name = "dgsearchprod";
            this.dgsearchprod.Size = new System.Drawing.Size(665, 491);
            this.dgsearchprod.TabIndex = 0;
            this.dgsearchprod.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsearchprod_CellClick);
            // 
            // pquant
            // 
            this.pquant.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pquant.Location = new System.Drawing.Point(89, 322);
            this.pquant.Name = "pquant";
            this.pquant.Size = new System.Drawing.Size(60, 27);
            this.pquant.TabIndex = 16;
            this.pquant.TextChanged += new System.EventHandler(this.pquant_TextChanged);
            // 
            // ptotal
            // 
            this.ptotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptotal.Location = new System.Drawing.Point(198, 322);
            this.ptotal.Name = "ptotal";
            this.ptotal.Size = new System.Drawing.Size(114, 27);
            this.ptotal.TabIndex = 16;
            this.ptotal.TextChanged += new System.EventHandler(this.ppriceTxt_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(153, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 23);
            this.label12.TabIndex = 21;
            this.label12.Text = "Total";
            this.label12.Click += new System.EventHandler(this.label10_Click);
            // 
            // dtp
            // 
            this.dtp.Enabled = false;
            this.dtp.Location = new System.Drawing.Point(89, 478);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(223, 20);
            this.dtp.TabIndex = 28;
            this.dtp.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(955, 587);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.prodpanel);
            this.Controls.Add(this.ptotal);
            this.Controls.Add(this.namepanel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.backToMenu);
            this.Controls.Add(this.removeOrder);
            this.Controls.Add(this.addOrder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTxt);
            this.Controls.Add(this.userTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pquant);
            this.Controls.Add(this.ppriceTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sprodTxt);
            this.Controls.Add(this.pnameTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.snameTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.custfnameTxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "orderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.orderForm_FormClosing_1);
            this.Load += new System.EventHandler(this.orderForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.namepanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsearchname)).EndInit();
            this.prodpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsearchprod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox custfnameTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pnameTxt;
        private System.Windows.Forms.Button sprodTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ppriceTxt;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox userTxt;
        private System.Windows.Forms.Label dateTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button addOrder;
        private System.Windows.Forms.Button removeOrder;
        private System.Windows.Forms.Button backToMenu;
        private System.Windows.Forms.Button snameTxt;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label totalpriceTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel namepanel;
        private System.Windows.Forms.DataGridView dgsearchname;
        private System.Windows.Forms.Panel prodpanel;
        private System.Windows.Forms.DataGridView dgsearchprod;
        private System.Windows.Forms.TextBox pquant;
        private System.Windows.Forms.TextBox ptotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtp;
    }
}