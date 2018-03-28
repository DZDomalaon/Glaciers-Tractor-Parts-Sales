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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.homePanel = new System.Windows.Forms.Panel();
            this.notifPanel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.logBtn = new System.Windows.Forms.Button();
            this.invoiceBtn = new System.Windows.Forms.Button();
            this.purchasingBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nameTxt = new System.Windows.Forms.Label();
            this.loginAs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delivBtn = new System.Windows.Forms.Button();
            this.custBtn = new System.Windows.Forms.Button();
            this.prodBtn = new System.Windows.Forms.Button();
            this.unpaidBtn = new System.Windows.Forms.Button();
            this.supplierBtn = new System.Windows.Forms.Button();
            this.usersBtn = new System.Windows.Forms.Button();
            this.glacierToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifBtn = new System.Windows.Forms.Button();
            this.notifBtn2 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.notifPanel.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.notifBtn2);
            this.panel3.Controls.Add(this.notifBtn);
            this.panel3.Controls.Add(this.settingsBtn);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(955, 47);
            this.panel3.TabIndex = 3;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.settingsBtn.Image = global::softeng1.Properties.Resources.user_avatar_main_picture;
            this.settingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.Location = new System.Drawing.Point(749, 3);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(101, 43);
            this.settingsBtn.TabIndex = 12;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
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
            this.homePanel.Controls.Add(this.notifPanel);
            this.homePanel.Controls.Add(this.logBtn);
            this.homePanel.Controls.Add(this.invoiceBtn);
            this.homePanel.Controls.Add(this.purchasingBtn);
            this.homePanel.Controls.Add(this.exitBtn);
            this.homePanel.Controls.Add(this.panel2);
            this.homePanel.Controls.Add(this.delivBtn);
            this.homePanel.Controls.Add(this.custBtn);
            this.homePanel.Controls.Add(this.prodBtn);
            this.homePanel.Controls.Add(this.unpaidBtn);
            this.homePanel.Controls.Add(this.supplierBtn);
            this.homePanel.Controls.Add(this.usersBtn);
            this.homePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.homePanel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePanel.ForeColor = System.Drawing.Color.White;
            this.homePanel.Location = new System.Drawing.Point(0, 47);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(955, 540);
            this.homePanel.TabIndex = 4;
            this.homePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.homePanel_Paint);
            // 
            // notifPanel
            // 
            this.notifPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.notifPanel.Controls.Add(this.panel9);
            this.notifPanel.Enabled = false;
            this.notifPanel.Location = new System.Drawing.Point(629, 0);
            this.notifPanel.Name = "notifPanel";
            this.notifPanel.Size = new System.Drawing.Size(326, 513);
            this.notifPanel.TabIndex = 103;
            this.notifPanel.Visible = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel9.Controls.Add(this.label17);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(326, 35);
            this.panel9.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(129, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 19);
            this.label17.TabIndex = 63;
            this.label17.Text = "Notifications";
            // 
            // logBtn
            // 
            this.logBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.logBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBtn.Image = global::softeng1.Properties.Resources.full_shopping_cart;
            this.logBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logBtn.Location = new System.Drawing.Point(407, 320);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(175, 112);
            this.logBtn.TabIndex = 9;
            this.logBtn.Text = "Log\r\nTransactions";
            this.logBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logBtn.UseVisualStyleBackColor = false;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
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
            this.invoiceBtn.Size = new System.Drawing.Size(199, 135);
            this.invoiceBtn.TabIndex = 1;
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
            this.purchasingBtn.Location = new System.Drawing.Point(407, 61);
            this.purchasingBtn.Name = "purchasingBtn";
            this.purchasingBtn.Size = new System.Drawing.Size(174, 135);
            this.purchasingBtn.TabIndex = 4;
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
            this.exitBtn.Location = new System.Drawing.Point(588, 377);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(174, 55);
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
            this.panel2.Location = new System.Drawing.Point(0, 512);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 28);
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
            this.delivBtn.Location = new System.Drawing.Point(587, 162);
            this.delivBtn.Name = "delivBtn";
            this.delivBtn.Size = new System.Drawing.Size(174, 122);
            this.delivBtn.TabIndex = 7;
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
            this.custBtn.TabIndex = 8;
            this.custBtn.Text = "Customer";
            this.custBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.custBtn.UseVisualStyleBackColor = false;
            this.custBtn.Click += new System.EventHandler(this.custBtn_Click_1);
            // 
            // prodBtn
            // 
            this.prodBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(176)))));
            this.prodBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prodBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodBtn.Image = global::softeng1.Properties.Resources.shopping_bag;
            this.prodBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prodBtn.Location = new System.Drawing.Point(407, 202);
            this.prodBtn.Name = "prodBtn";
            this.prodBtn.Size = new System.Drawing.Size(174, 112);
            this.prodBtn.TabIndex = 6;
            this.prodBtn.Text = "Products";
            this.prodBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prodBtn.UseVisualStyleBackColor = false;
            this.prodBtn.Click += new System.EventHandler(this.prodBtn_Click_1);
            // 
            // unpaidBtn
            // 
            this.unpaidBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.unpaidBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unpaidBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpaidBtn.Image = global::softeng1.Properties.Resources.give_money;
            this.unpaidBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unpaidBtn.Location = new System.Drawing.Point(587, 61);
            this.unpaidBtn.Name = "unpaidBtn";
            this.unpaidBtn.Size = new System.Drawing.Size(174, 95);
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
            this.supplierBtn.Location = new System.Drawing.Point(202, 202);
            this.supplierBtn.Name = "supplierBtn";
            this.supplierBtn.Size = new System.Drawing.Size(199, 112);
            this.supplierBtn.TabIndex = 5;
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
            this.usersBtn.Location = new System.Drawing.Point(587, 290);
            this.usersBtn.Name = "usersBtn";
            this.usersBtn.Size = new System.Drawing.Size(174, 81);
            this.usersBtn.TabIndex = 10;
            this.usersBtn.Text = "Users";
            this.usersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usersBtn.UseVisualStyleBackColor = false;
            this.usersBtn.Click += new System.EventHandler(this.staffBtn_Click);
            // 
            // notifBtn
            // 
            this.notifBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.notifBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifBtn.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.notifBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notifBtn.Location = new System.Drawing.Point(852, 3);
            this.notifBtn.Name = "notifBtn";
            this.notifBtn.Size = new System.Drawing.Size(101, 43);
            this.notifBtn.TabIndex = 13;
            this.notifBtn.Text = "Notifications";
            this.notifBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notifBtn.UseVisualStyleBackColor = false;
            this.notifBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifBtn2
            // 
            this.notifBtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.notifBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifBtn2.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifBtn2.ForeColor = System.Drawing.SystemColors.Control;
            this.notifBtn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notifBtn2.Location = new System.Drawing.Point(852, 3);
            this.notifBtn2.Name = "notifBtn2";
            this.notifBtn2.Size = new System.Drawing.Size(100, 43);
            this.notifBtn2.TabIndex = 14;
            this.notifBtn2.Text = "Notifications";
            this.notifBtn2.UseVisualStyleBackColor = false;
            this.notifBtn2.Visible = false;
            this.notifBtn2.Click += new System.EventHandler(this.notifBtn2_Click);
            // 
            // homeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 587);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.notifPanel.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
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
        private System.Windows.Forms.Button unpaidBtn;
        private System.Windows.Forms.Button supplierBtn;
        private System.Windows.Forms.Button usersBtn;
        private System.Windows.Forms.Button custBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label loginAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button delivBtn;
        private System.Windows.Forms.Label nameTxt;
        private System.Windows.Forms.Button purchasingBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.ToolTip glacierToolTip;
        private System.Windows.Forms.Panel notifPanel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button notifBtn;
        private System.Windows.Forms.Button notifBtn2;
    }
}