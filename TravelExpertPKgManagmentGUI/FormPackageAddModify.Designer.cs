
namespace TravelExpertPKgManagmentGUI
{
    partial class FormPackageAddModify
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.txtCommision = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbAddPackages = new System.Windows.Forms.GroupBox();
            this.chkDateSelect = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPackageId = new System.Windows.Forms.Label();
            this.lblPkg = new System.Windows.Forms.Label();
            this.gbAddPackages.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Base Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Commision";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "End Date";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 113);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(333, 27);
            this.txtName.TabIndex = 3;
            this.txtName.Tag = "Package Name";
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Location = new System.Drawing.Point(110, 186);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.Size = new System.Drawing.Size(125, 27);
            this.txtBasePrice.TabIndex = 5;
            this.txtBasePrice.Tag = "Base Price";
            // 
            // txtCommision
            // 
            this.txtCommision.Location = new System.Drawing.Point(111, 219);
            this.txtCommision.Name = "txtCommision";
            this.txtCommision.Size = new System.Drawing.Size(125, 27);
            this.txtCommision.TabIndex = 6;
            this.txtCommision.Tag = "Commission";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(19, 348);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 42);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Product";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Supplier";
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(111, 35);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(151, 28);
            this.cmbProduct.TabIndex = 1;
            this.cmbProduct.Tag = "EndDate";
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(110, 72);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(333, 28);
            this.cmbSupplier.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 146);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(334, 27);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Tag = "Description";
            // 
            // gbAddPackages
            // 
            this.gbAddPackages.Controls.Add(this.chkDateSelect);
            this.gbAddPackages.Controls.Add(this.dtpEnd);
            this.gbAddPackages.Controls.Add(this.dtpStart);
            this.gbAddPackages.Controls.Add(this.btnCancel);
            this.gbAddPackages.Controls.Add(this.cmbSupplier);
            this.gbAddPackages.Controls.Add(this.cmbProduct);
            this.gbAddPackages.Controls.Add(this.label8);
            this.gbAddPackages.Controls.Add(this.label7);
            this.gbAddPackages.Controls.Add(this.btnOK);
            this.gbAddPackages.Controls.Add(this.txtCommision);
            this.gbAddPackages.Controls.Add(this.txtBasePrice);
            this.gbAddPackages.Controls.Add(this.txtDescription);
            this.gbAddPackages.Controls.Add(this.txtName);
            this.gbAddPackages.Controls.Add(this.label6);
            this.gbAddPackages.Controls.Add(this.label5);
            this.gbAddPackages.Controls.Add(this.label4);
            this.gbAddPackages.Controls.Add(this.label3);
            this.gbAddPackages.Controls.Add(this.label2);
            this.gbAddPackages.Controls.Add(this.label1);
            this.gbAddPackages.Location = new System.Drawing.Point(18, 34);
            this.gbAddPackages.Name = "gbAddPackages";
            this.gbAddPackages.Size = new System.Drawing.Size(897, 420);
            this.gbAddPackages.TabIndex = 3;
            this.gbAddPackages.TabStop = false;
            // 
            // chkDateSelect
            // 
            this.chkDateSelect.AutoSize = true;
            this.chkDateSelect.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkDateSelect.ForeColor = System.Drawing.Color.IndianRed;
            this.chkDateSelect.Location = new System.Drawing.Point(399, 254);
            this.chkDateSelect.Name = "chkDateSelect";
            this.chkDateSelect.Size = new System.Drawing.Size(404, 29);
            this.chkDateSelect.TabIndex = 17;
            this.chkDateSelect.Text = "Please check if you want to select the dates";
            this.chkDateSelect.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(110, 286);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(250, 27);
            this.dtpEnd.TabIndex = 16;
            this.dtpEnd.Tag = "EndDate";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(111, 252);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(250, 27);
            this.dtpStart.TabIndex = 15;
            this.dtpStart.Tag = "StartDate";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 42);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPackageId
            // 
            this.lblPackageId.AutoSize = true;
            this.lblPackageId.Location = new System.Drawing.Point(105, 11);
            this.lblPackageId.Name = "lblPackageId";
            this.lblPackageId.Size = new System.Drawing.Size(0, 20);
            this.lblPackageId.TabIndex = 4;
            // 
            // lblPkg
            // 
            this.lblPkg.AutoSize = true;
            this.lblPkg.Location = new System.Drawing.Point(19, 11);
            this.lblPkg.Name = "lblPkg";
            this.lblPkg.Size = new System.Drawing.Size(83, 20);
            this.lblPkg.TabIndex = 5;
            this.lblPkg.Text = "Package Id:";
            // 
            // FormPackageAddModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(927, 483);
            this.Controls.Add(this.lblPkg);
            this.Controls.Add(this.lblPackageId);
            this.Controls.Add(this.gbAddPackages);
            this.Name = "FormPackageAddModify";
            this.Text = "FormPackageAddModify";
            this.Load += new System.EventHandler(this.FormPackageAddModify_Load);
            this.gbAddPackages.ResumeLayout(false);
            this.gbAddPackages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.TextBox txtCommision;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gbAddPackages;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblPackageId;
        private System.Windows.Forms.Label lblPkg;
        private System.Windows.Forms.CheckBox chkDateSelect;
    }
}