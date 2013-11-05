namespace JBilling.Commercial
{
    partial class CompanyForm
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cmbCompanyName = new JBilling.Controls.MultiColumnComboBox(this.components);
            this.grpContactDetails = new System.Windows.Forms.GroupBox();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpCompanyDetails = new System.Windows.Forms.GroupBox();
            this.txtTaxRegNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.chkIsSupplier = new System.Windows.Forms.CheckBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.chkIsCustomer = new System.Windows.Forms.CheckBox();
            this.txtComanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpContactInformation = new System.Windows.Forms.GroupBox();
            this.txtCompanyWebsite = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpContactDetails.SuspendLayout();
            this.grpCompanyDetails.SuspendLayout();
            this.grpContactInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(39, 22);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(82, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Company Name";
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(144, 19);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(214, 21);
            this.cmbCompanyName.TabIndex = 4;
            this.cmbCompanyName.Table = null;
            // 
            // grpContactDetails
            // 
            this.grpContactDetails.Controls.Add(this.txtDeliveryAddress);
            this.grpContactDetails.Controls.Add(this.label4);
            this.grpContactDetails.Controls.Add(this.txtCompanyAddress);
            this.grpContactDetails.Controls.Add(this.label3);
            this.grpContactDetails.Location = new System.Drawing.Point(16, 273);
            this.grpContactDetails.Name = "grpContactDetails";
            this.grpContactDetails.Size = new System.Drawing.Size(909, 169);
            this.grpContactDetails.TabIndex = 6;
            this.grpContactDetails.TabStop = false;
            this.grpContactDetails.Text = "Company Addresses";
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Location = new System.Drawing.Point(564, 34);
            this.txtDeliveryAddress.Multiline = true;
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(319, 112);
            this.txtDeliveryAddress.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Delivery Address";
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(128, 34);
            this.txtCompanyAddress.Multiline = true;
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(319, 112);
            this.txtCompanyAddress.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Company Address";
            // 
            // grpCompanyDetails
            // 
            this.grpCompanyDetails.Controls.Add(this.txtTaxRegNo);
            this.grpCompanyDetails.Controls.Add(this.label2);
            this.grpCompanyDetails.Controls.Add(this.txtSupplierCode);
            this.grpCompanyDetails.Controls.Add(this.chkIsSupplier);
            this.grpCompanyDetails.Controls.Add(this.txtCustomerCode);
            this.grpCompanyDetails.Controls.Add(this.chkIsCustomer);
            this.grpCompanyDetails.Controls.Add(this.txtComanyName);
            this.grpCompanyDetails.Controls.Add(this.label1);
            this.grpCompanyDetails.Location = new System.Drawing.Point(16, 73);
            this.grpCompanyDetails.Name = "grpCompanyDetails";
            this.grpCompanyDetails.Size = new System.Drawing.Size(424, 183);
            this.grpCompanyDetails.TabIndex = 7;
            this.grpCompanyDetails.TabStop = false;
            this.grpCompanyDetails.Text = "Company Details";
            // 
            // txtTaxRegNo
            // 
            this.txtTaxRegNo.Location = new System.Drawing.Point(135, 140);
            this.txtTaxRegNo.MaxLength = 10;
            this.txtTaxRegNo.Name = "txtTaxRegNo";
            this.txtTaxRegNo.Size = new System.Drawing.Size(138, 20);
            this.txtTaxRegNo.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tax Registration No.";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(135, 94);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(73, 20);
            this.txtSupplierCode.TabIndex = 18;
            // 
            // chkIsSupplier
            // 
            this.chkIsSupplier.AutoSize = true;
            this.chkIsSupplier.Location = new System.Drawing.Point(33, 95);
            this.chkIsSupplier.Name = "chkIsSupplier";
            this.chkIsSupplier.Size = new System.Drawing.Size(75, 17);
            this.chkIsSupplier.TabIndex = 17;
            this.chkIsSupplier.Text = "Is Supplier";
            this.chkIsSupplier.UseVisualStyleBackColor = true;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(135, 68);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(73, 20);
            this.txtCustomerCode.TabIndex = 16;
            // 
            // chkIsCustomer
            // 
            this.chkIsCustomer.AutoSize = true;
            this.chkIsCustomer.Location = new System.Drawing.Point(33, 68);
            this.chkIsCustomer.Name = "chkIsCustomer";
            this.chkIsCustomer.Size = new System.Drawing.Size(81, 17);
            this.chkIsCustomer.TabIndex = 15;
            this.chkIsCustomer.Text = "Is Customer";
            this.chkIsCustomer.UseVisualStyleBackColor = true;
            // 
            // txtComanyName
            // 
            this.txtComanyName.Location = new System.Drawing.Point(135, 23);
            this.txtComanyName.Name = "txtComanyName";
            this.txtComanyName.Size = new System.Drawing.Size(214, 20);
            this.txtComanyName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Company Name";
            // 
            // grpContactInformation
            // 
            this.grpContactInformation.Controls.Add(this.txtCompanyWebsite);
            this.grpContactInformation.Controls.Add(this.label7);
            this.grpContactInformation.Controls.Add(this.txtContactEmail);
            this.grpContactInformation.Controls.Add(this.label6);
            this.grpContactInformation.Controls.Add(this.txtContactName);
            this.grpContactInformation.Controls.Add(this.label5);
            this.grpContactInformation.Location = new System.Drawing.Point(489, 73);
            this.grpContactInformation.Name = "grpContactInformation";
            this.grpContactInformation.Size = new System.Drawing.Size(427, 183);
            this.grpContactInformation.TabIndex = 8;
            this.grpContactInformation.TabStop = false;
            this.grpContactInformation.Text = "Contact Information";
            // 
            // txtCompanyWebsite
            // 
            this.txtCompanyWebsite.Location = new System.Drawing.Point(131, 94);
            this.txtCompanyWebsite.Name = "txtCompanyWebsite";
            this.txtCompanyWebsite.Size = new System.Drawing.Size(214, 20);
            this.txtCompanyWebsite.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "CompanyWebsite";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Location = new System.Drawing.Point(131, 60);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(214, 20);
            this.txtContactEmail.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Contact Email";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(131, 27);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(214, 20);
            this.txtContactName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Contact Name";
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 483);
            this.Controls.Add(this.grpContactInformation);
            this.Controls.Add(this.grpCompanyDetails);
            this.Controls.Add(this.grpContactDetails);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.lblCompanyName);
            this.Name = "CompanyForm";
            this.Text = "CompanyForm";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveClose, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.lblCompanyName, 0);
            this.Controls.SetChildIndex(this.cmbCompanyName, 0);
            this.Controls.SetChildIndex(this.grpContactDetails, 0);
            this.Controls.SetChildIndex(this.grpCompanyDetails, 0);
            this.Controls.SetChildIndex(this.grpContactInformation, 0);
            this.grpContactDetails.ResumeLayout(false);
            this.grpContactDetails.PerformLayout();
            this.grpCompanyDetails.ResumeLayout(false);
            this.grpCompanyDetails.PerformLayout();
            this.grpContactInformation.ResumeLayout(false);
            this.grpContactInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompanyName;
        private Controls.MultiColumnComboBox cmbCompanyName;
        private System.Windows.Forms.GroupBox grpContactDetails;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpCompanyDetails;
        private System.Windows.Forms.TextBox txtTaxRegNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.CheckBox chkIsSupplier;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.CheckBox chkIsCustomer;
        private System.Windows.Forms.TextBox txtComanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContactInformation;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyWebsite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.Label label6;
    }
}