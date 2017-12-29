namespace softeng1
{
    partial class productsForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prodData = new System.Windows.Forms.DataGridView();
            this.backBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.pdescTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnameTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.priceTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.warrantyDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.discountTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.serialTxt = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.categTxt = new System.Windows.Forms.ComboBox();
            this.asd = new System.Windows.Forms.Label();
            this.variantTxt = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodData)).BeginInit();
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
            this.panel3.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 47);
            this.panel1.TabIndex = 0;
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
            this.panel2.TabIndex = 31;
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(249, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prodData
            // 
            this.prodData.AllowUserToAddRows = false;
            this.prodData.AllowUserToDeleteRows = false;
            this.prodData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.prodData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prodData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodData.Dock = System.Windows.Forms.DockStyle.Right;
            this.prodData.Location = new System.Drawing.Point(434, 85);
            this.prodData.Name = "prodData";
            this.prodData.ReadOnly = true;
            this.prodData.RowHeadersVisible = false;
            this.prodData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prodData.Size = new System.Drawing.Size(521, 502);
            this.prodData.TabIndex = 64;
            this.prodData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prodData_CellClick_1);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(311, 510);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(92, 37);
            this.backBtn.TabIndex = 82;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.Color.White;
            this.editBtn.Location = new System.Drawing.Point(213, 510);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(92, 37);
            this.editBtn.TabIndex = 81;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(80)))), ((int)(((byte)(34)))));
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.ForeColor = System.Drawing.Color.White;
            this.resetBtn.Location = new System.Drawing.Point(115, 510);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(92, 37);
            this.resetBtn.TabIndex = 80;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(17, 510);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(92, 37);
            this.addBtn.TabIndex = 79;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // pdescTxt
            // 
            this.pdescTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdescTxt.Location = new System.Drawing.Point(125, 151);
            this.pdescTxt.Name = "pdescTxt";
            this.pdescTxt.Size = new System.Drawing.Size(223, 27);
            this.pdescTxt.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 23);
            this.label5.TabIndex = 76;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 46);
            this.label4.TabIndex = 74;
            this.label4.Text = "Product\r\nName";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pnameTxt
            // 
            this.pnameTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnameTxt.Location = new System.Drawing.Point(125, 101);
            this.pnameTxt.Name = "pnameTxt";
            this.pnameTxt.Size = new System.Drawing.Size(223, 27);
            this.pnameTxt.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 46);
            this.label6.TabIndex = 83;
            this.label6.Text = "Product\r\nPrice";
            // 
            // priceTxt
            // 
            this.priceTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceTxt.Location = new System.Drawing.Point(125, 325);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(223, 27);
            this.priceTxt.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 23);
            this.label7.TabIndex = 85;
            this.label7.Text = "Warranty";
            // 
            // warrantyDate
            // 
            this.warrantyDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warrantyDate.Location = new System.Drawing.Point(125, 371);
            this.warrantyDate.Name = "warrantyDate";
            this.warrantyDate.Size = new System.Drawing.Size(223, 27);
            this.warrantyDate.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 23);
            this.label8.TabIndex = 87;
            this.label8.Text = "Discount";
            // 
            // discountTxt
            // 
            this.discountTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountTxt.Location = new System.Drawing.Point(125, 427);
            this.discountTxt.Name = "discountTxt";
            this.discountTxt.Size = new System.Drawing.Size(223, 27);
            this.discountTxt.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(14, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 23);
            this.label9.TabIndex = 89;
            this.label9.Text = "Serial No.";
            // 
            // serialTxt
            // 
            this.serialTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTxt.Location = new System.Drawing.Point(125, 194);
            this.serialTxt.Mask = "0000-000-0000";
            this.serialTxt.Name = "serialTxt";
            this.serialTxt.PromptChar = '0';
            this.serialTxt.Size = new System.Drawing.Size(136, 27);
            this.serialTxt.TabIndex = 90;
            this.serialTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(14, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 23);
            this.label10.TabIndex = 91;
            this.label10.Text = "Category";
            // 
            // categTxt
            // 
            this.categTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categTxt.FormattingEnabled = true;
            this.categTxt.Location = new System.Drawing.Point(125, 242);
            this.categTxt.Name = "categTxt";
            this.categTxt.Size = new System.Drawing.Size(180, 27);
            this.categTxt.TabIndex = 92;
            // 
            // asd
            // 
            this.asd.AutoSize = true;
            this.asd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asd.ForeColor = System.Drawing.Color.Black;
            this.asd.Location = new System.Drawing.Point(14, 275);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(65, 23);
            this.asd.TabIndex = 76;
            this.asd.Text = "Variant";
            // 
            // variantTxt
            // 
            this.variantTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variantTxt.Location = new System.Drawing.Point(125, 275);
            this.variantTxt.Name = "variantTxt";
            this.variantTxt.Size = new System.Drawing.Size(223, 27);
            this.variantTxt.TabIndex = 77;
            // 
            // productsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 587);
            this.Controls.Add(this.categTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.serialTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.discountTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.warrantyDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.priceTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.variantTxt);
            this.Controls.Add(this.asd);
            this.Controls.Add(this.pdescTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnameTxt);
            this.Controls.Add(this.prodData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "productsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Products";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.productsForm_FormClosing_1);
            this.Load += new System.EventHandler(this.productsForm_Load_1);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView prodData;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox pdescTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pnameTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox priceTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker warrantyDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox discountTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox serialTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox categTxt;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.TextBox variantTxt;
    }
}