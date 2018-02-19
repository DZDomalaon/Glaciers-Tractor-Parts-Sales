namespace softeng1
{
    partial class transactionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.empnameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customerData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.purchaseData = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseData)).BeginInit();
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
            this.panel3.TabIndex = 29;
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
            this.panel2.Controls.Add(this.empnameTxt);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 50);
            this.panel2.TabIndex = 30;
            // 
            // empnameTxt
            // 
            this.empnameTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empnameTxt.Location = new System.Drawing.Point(196, 12);
            this.empnameTxt.Name = "empnameTxt";
            this.empnameTxt.Size = new System.Drawing.Size(183, 27);
            this.empnameTxt.TabIndex = 49;
            this.empnameTxt.TextChanged += new System.EventHandler(this.empnameTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Employee Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(131, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Customer Transactions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customerData
            // 
            this.customerData.AllowUserToAddRows = false;
            this.customerData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.Color.Black;
            this.customerData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle55;
            this.customerData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerData.BackgroundColor = System.Drawing.Color.White;
            this.customerData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle56;
            this.customerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerData.DefaultCellStyle = dataGridViewCellStyle57;
            this.customerData.EnableHeadersVisualStyles = false;
            this.customerData.Location = new System.Drawing.Point(3, 146);
            this.customerData.Name = "customerData";
            this.customerData.ReadOnly = true;
            this.customerData.RowHeadersVisible = false;
            this.customerData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerData.Size = new System.Drawing.Size(470, 394);
            this.customerData.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(622, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 22);
            this.label4.TabIndex = 47;
            this.label4.Text = "Purchasing Transactions";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // purchaseData
            // 
            this.purchaseData.AllowUserToAddRows = false;
            this.purchaseData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.Black;
            this.purchaseData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle58;
            this.purchaseData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.purchaseData.BackgroundColor = System.Drawing.Color.White;
            this.purchaseData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.purchaseData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.purchaseData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.purchaseData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.purchaseData.DefaultCellStyle = dataGridViewCellStyle60;
            this.purchaseData.EnableHeadersVisualStyles = false;
            this.purchaseData.Location = new System.Drawing.Point(482, 146);
            this.purchaseData.Name = "purchaseData";
            this.purchaseData.ReadOnly = true;
            this.purchaseData.RowHeadersVisible = false;
            this.purchaseData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.purchaseData.Size = new System.Drawing.Size(470, 394);
            this.purchaseData.TabIndex = 48;
            // 
            // transactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 587);
            this.Controls.Add(this.purchaseData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customerData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "transactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Log Transactions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.transactionsForm_FormClosing);
            this.Load += new System.EventHandler(this.transactionsForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView customerData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView purchaseData;
        private System.Windows.Forms.TextBox empnameTxt;
    }
}