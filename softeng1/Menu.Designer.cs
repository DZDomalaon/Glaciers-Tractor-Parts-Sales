namespace softeng1
{
    partial class homeForm
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
            this.homePanel = new System.Windows.Forms.Panel();
            this.invoiceBtn = new System.Windows.Forms.Button();
            this.purchasingBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nameTxt = new System.Windows.Forms.Label();
            this.loginAs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delivBtn = new System.Windows.Forms.Button();
            this.custBtn = new System.Windows.Forms.Button();
            this.warrBtn = new System.Windows.Forms.Button();
            this.prodBtn = new System.Windows.Forms.Button();
            this.salesBtn = new System.Windows.Forms.Button();
            this.unpaidBtn = new System.Windows.Forms.Button();
            this.supplierBtn = new System.Windows.Forms.Button();
            this.usersBtn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(955, 47);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
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
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.Color.White;
            this.homePanel.Controls.Add(this.invoiceBtn);
            this.homePanel.Controls.Add(this.purchasingBtn);
            this.homePanel.Controls.Add(this.exitBtn);
            this.homePanel.Controls.Add(this.panel2);
            this.homePanel.Controls.Add(this.delivBtn);
            this.homePanel.Controls.Add(this.custBtn);
            this.homePanel.Controls.Add(this.warrBtn);
            this.homePanel.Controls.Add(this.prodBtn);
            this.homePanel.Controls.Add(this.salesBtn);
            this.homePanel.Controls.Add(this.unpaidBtn);
            this.homePanel.Controls.Add(this.supplierBtn);
            this.homePanel.Controls.Add(this.usersBtn);
            this.homePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.homePanel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePanel.ForeColor = System.Drawing.Color.White;
            this.homePanel.Location = new System.Drawing.Point(0, 47);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(955, 540);
            this.homePanel.TabIndex = 4;
            // 
            // invoiceBtn
            // 
            this.invoiceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(80)))), ((int)(((byte)(34)))));
            this.invoiceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invoiceBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceBtn.Image = global::softeng1.Properties.Resources.financial_document;
            this.invoiceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invoiceBtn.Location = new System.Drawing.Point(202, 61);
            this.invoiceBtn.Name = "invoiceBtn";
            this.invoiceBtn.Size = new System.Drawing.Size(199, 162);
            this.invoiceBtn.TabIndex = 0;
            this.invoiceBtn.Text = "Create New\r\nInvoice";
            this.invoiceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.invoiceBtn.UseVisualStyleBackColor = false;
            this.invoiceBtn.Click += new System.EventHandler(this.invoiceBtn_Click);
            // 
            // purchasingBtn
            // 
            this.purchasingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.purchasingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchasingBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasingBtn.Image = global::softeng1.Properties.Resources.add_to_cart1;
            this.purchasingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchasingBtn.Location = new System.Drawing.Point(588, 149);
            this.purchasingBtn.Name = "purchasingBtn";
            this.purchasingBtn.Size = new System.Drawing.Size(174, 74);
            this.purchasingBtn.TabIndex = 12;
            this.purchasingBtn.Text = "Purchasing";
            this.purchasingBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.purchasingBtn.UseVisualStyleBackColor = false;
            this.purchasingBtn.Click += new System.EventHandler(this.purchasingBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::softeng1.Properties.Resources.exit1;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.Location = new System.Drawing.Point(588, 380);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(174, 52);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.Text = "Exit";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.nameTxt);
            this.panel2.Controls.Add(this.loginAs);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 515);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 25);
            this.panel2.TabIndex = 9;
            // 
            // nameTxt
            // 
            this.nameTxt.AutoSize = true;
            this.nameTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(104, 5);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(0, 17);
            this.nameTxt.TabIndex = 2;
            // 
            // loginAs
            // 
            this.loginAs.AutoSize = true;
            this.loginAs.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginAs.Location = new System.Drawing.Point(99, 5);
            this.loginAs.Name = "loginAs";
            this.loginAs.Size = new System.Drawing.Size(0, 17);
            this.loginAs.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Logged In As |";
            // 
            // delivBtn
            // 
            this.delivBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.delivBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delivBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delivBtn.Image = global::softeng1.Properties.Resources.verification_of_delivery_list_clipboard_symbol;
            this.delivBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delivBtn.Location = new System.Drawing.Point(587, 229);
            this.delivBtn.Name = "delivBtn";
            this.delivBtn.Size = new System.Drawing.Size(174, 85);
            this.delivBtn.TabIndex = 8;
            this.delivBtn.Text = "Delivery\r\nReports";
            this.delivBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delivBtn.UseVisualStyleBackColor = false;
            this.delivBtn.Click += new System.EventHandler(this.delivBtn_Click_1);
            // 
            // custBtn
            // 
            this.custBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(72)))), ((int)(((byte)(86)))));
            this.custBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custBtn.Image = global::softeng1.Properties.Resources.specialist_user;
            this.custBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.custBtn.Location = new System.Drawing.Point(202, 320);
            this.custBtn.Name = "custBtn";
            this.custBtn.Size = new System.Drawing.Size(199, 112);
            this.custBtn.TabIndex = 7;
            this.custBtn.Text = "Customer";
            this.custBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.custBtn.UseVisualStyleBackColor = false;
            this.custBtn.Click += new System.EventHandler(this.custBtn_Click_1);
            // 
            // warrBtn
            // 
            this.warrBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.warrBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warrBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warrBtn.Image = global::softeng1.Properties.Resources.warranty;
            this.warrBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.warrBtn.Location = new System.Drawing.Point(407, 320);
            this.warrBtn.Name = "warrBtn";
            this.warrBtn.Size = new System.Drawing.Size(174, 112);
            this.warrBtn.TabIndex = 6;
            this.warrBtn.Text = "Warranty";
            this.warrBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.warrBtn.UseVisualStyleBackColor = false;
            this.warrBtn.Click += new System.EventHandler(this.warrBtn_Click);
            // 
            // prodBtn
            // 
            this.prodBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(176)))));
            this.prodBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prodBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodBtn.Image = global::softeng1.Properties.Resources.shopping_bag;
            this.prodBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prodBtn.Location = new System.Drawing.Point(407, 229);
            this.prodBtn.Name = "prodBtn";
            this.prodBtn.Size = new System.Drawing.Size(174, 85);
            this.prodBtn.TabIndex = 5;
            this.prodBtn.Text = "Products";
            this.prodBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prodBtn.UseVisualStyleBackColor = false;
            this.prodBtn.Click += new System.EventHandler(this.prodBtn_Click_1);
            // 
            // salesBtn
            // 
            this.salesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(114)))), ((int)(((byte)(182)))));
            this.salesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesBtn.Image = global::softeng1.Properties.Resources.bar_chart;
            this.salesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salesBtn.Location = new System.Drawing.Point(407, 61);
            this.salesBtn.Name = "salesBtn";
            this.salesBtn.Size = new System.Drawing.Size(174, 162);
            this.salesBtn.TabIndex = 4;
            this.salesBtn.Text = "Sales";
            this.salesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.salesBtn.UseVisualStyleBackColor = false;
            this.salesBtn.Click += new System.EventHandler(this.salesBtn_Click);
            // 
            // unpaidBtn
            // 
            this.unpaidBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.unpaidBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unpaidBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpaidBtn.Image = global::softeng1.Properties.Resources.give_money;
            this.unpaidBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unpaidBtn.Location = new System.Drawing.Point(588, 61);
            this.unpaidBtn.Name = "unpaidBtn";
            this.unpaidBtn.Size = new System.Drawing.Size(174, 82);
            this.unpaidBtn.TabIndex = 3;
            this.unpaidBtn.Text = "Unpaid\r\nInvoices";
            this.unpaidBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.unpaidBtn.UseVisualStyleBackColor = false;
            this.unpaidBtn.Click += new System.EventHandler(this.unpaidBtn_Click);
            // 
            // supplierBtn
            // 
            this.supplierBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(186)))), ((int)(((byte)(0)))));
            this.supplierBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplierBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierBtn.Image = global::softeng1.Properties.Resources.hotel_supplier;
            this.supplierBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplierBtn.Location = new System.Drawing.Point(202, 229);
            this.supplierBtn.Name = "supplierBtn";
            this.supplierBtn.Size = new System.Drawing.Size(199, 85);
            this.supplierBtn.TabIndex = 2;
            this.supplierBtn.Text = "Supplier";
            this.supplierBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.supplierBtn.UseVisualStyleBackColor = false;
            this.supplierBtn.Click += new System.EventHandler(this.supplierBtn_Click);
            // 
            // usersBtn
            // 
            this.usersBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.usersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersBtn.Image = global::softeng1.Properties.Resources.businessman1;
            this.usersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersBtn.Location = new System.Drawing.Point(588, 320);
            this.usersBtn.Name = "usersBtn";
            this.usersBtn.Size = new System.Drawing.Size(174, 54);
            this.usersBtn.TabIndex = 1;
            this.usersBtn.Text = "Users";
            this.usersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usersBtn.UseVisualStyleBackColor = false;
            this.usersBtn.Click += new System.EventHandler(this.staffBtn_Click);
            // 
            // homeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 587);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "homeForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.homeForm_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.homePanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.Button invoiceBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button prodBtn;
        private System.Windows.Forms.Button salesBtn;
        private System.Windows.Forms.Button unpaidBtn;
        private System.Windows.Forms.Button supplierBtn;
        private System.Windows.Forms.Button usersBtn;
        private System.Windows.Forms.Button custBtn;
        private System.Windows.Forms.Button warrBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label loginAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button delivBtn;
        private System.Windows.Forms.Label nameTxt;
        private System.Windows.Forms.Button purchasingBtn;
    }
}