namespace JBilling.Sales
{
    partial class SalesOrderForm
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
            this.dgSalesOrder = new JBilling.Controls.JBillingDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSalesOrder = new JBilling.Controls.MultiColumnComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTax = new JBilling.Controls.JBillingTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCompanyName = new JBilling.Controls.MultiColumnComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalesOrderNumber = new JBilling.Controls.JBillingTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dllblSum = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dlblTax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dlblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(638, 462);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(735, 462);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(826, 462);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(542, 462);
            // 
            // dgSalesOrder
            // 
            this.dgSalesOrder.DataMember = "";
            this.dgSalesOrder.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSalesOrder.Location = new System.Drawing.Point(41, 216);
            this.dgSalesOrder.MainDataSet = null;
            this.dgSalesOrder.Name = "dgSalesOrder";
            this.dgSalesOrder.Size = new System.Drawing.Size(843, 175);
            this.dgSalesOrder.TabIndex = 4;
            this.dgSalesOrder.TableName = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sales Order Number";
            // 
            // cmbSalesOrder
            // 
            this.cmbSalesOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSalesOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbSalesOrder.FormattingEnabled = true;
            this.cmbSalesOrder.Location = new System.Drawing.Point(170, 19);
            this.cmbSalesOrder.Name = "cmbSalesOrder";
            this.cmbSalesOrder.Size = new System.Drawing.Size(201, 21);
            this.cmbSalesOrder.TabIndex = 6;
            this.cmbSalesOrder.Table = null;
            this.cmbSalesOrder.ValueMember = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTax);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCompanyName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSalesOrderNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(41, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 158);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Order Details";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(143, 105);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(216, 20);
            this.txtTax.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tax Applied";
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(143, 63);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(216, 21);
            this.cmbCompanyName.TabIndex = 9;
            this.cmbCompanyName.Table = null;
            this.cmbCompanyName.ValueMember = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Company Name";
            // 
            // txtSalesOrderNumber
            // 
            this.txtSalesOrderNumber.Location = new System.Drawing.Point(143, 26);
            this.txtSalesOrderNumber.Name = "txtSalesOrderNumber";
            this.txtSalesOrderNumber.Size = new System.Drawing.Size(216, 20);
            this.txtSalesOrderNumber.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sales Order Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(750, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sum";
            // 
            // dllblSum
            // 
            this.dllblSum.Location = new System.Drawing.Point(787, 399);
            this.dllblSum.Name = "dllblSum";
            this.dllblSum.Size = new System.Drawing.Size(97, 13);
            this.dllblSum.TabIndex = 10;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(438, 462);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 417);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tax";
            // 
            // dlblTax
            // 
            this.dlblTax.Location = new System.Drawing.Point(787, 417);
            this.dlblTax.Name = "dlblTax";
            this.dlblTax.Size = new System.Drawing.Size(97, 13);
            this.dlblTax.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(753, 434);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 1);
            this.label7.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(750, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Total";
            // 
            // dlblTotal
            // 
            this.dlblTotal.Location = new System.Drawing.Point(787, 446);
            this.dlblTotal.Name = "dlblTotal";
            this.dlblTotal.Size = new System.Drawing.Size(97, 13);
            this.dlblTotal.TabIndex = 16;
            // 
            // SalesOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 495);
            this.Controls.Add(this.dlblTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dlblTax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dllblSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbSalesOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgSalesOrder);
            this.Name = "SalesOrderForm";
            this.Text = "Add/Edit Sales Order";
            this.Controls.SetChildIndex(this.dgSalesOrder, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbSalesOrder, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveClose, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dllblSum, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dlblTax, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dlblTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.JBillingDataGridView dgSalesOrder;
        private System.Windows.Forms.Label label1;
        private Controls.MultiColumnComboBox cmbSalesOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private Controls.JBillingTextBox txtSalesOrderNumber;
        private Controls.MultiColumnComboBox cmbCompanyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dllblSum;
        private System.Windows.Forms.Button btnPrint;
        private Controls.JBillingTextBox txtTax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dlblTax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dlblTotal;
    }
}