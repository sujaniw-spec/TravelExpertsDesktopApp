
namespace TravelExpertPKgManagmentGUI
{
    partial class FormTravelPackagesMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgViewPackages = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnManageProduct = new System.Windows.Forms.Button();
            this.btnManageSupplier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewPackages
            // 
            this.dgViewPackages.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgViewPackages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgViewPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewPackages.Location = new System.Drawing.Point(21, 55);
            this.dgViewPackages.Name = "dgViewPackages";
            this.dgViewPackages.RowHeadersWidth = 51;
            this.dgViewPackages.RowTemplate.Height = 29;
            this.dgViewPackages.Size = new System.Drawing.Size(1265, 309);
            this.dgViewPackages.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Travel Package Management";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnAdd.Location = new System.Drawing.Point(271, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(195, 43);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&ADD PACKAGE";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnEdit.Location = new System.Drawing.Point(493, 382);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(224, 43);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&UPDATE PACKAGE";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(21, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 43);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&EXIT";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnManageProduct.Location = new System.Drawing.Point(745, 385);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new System.Drawing.Size(249, 40);
            this.btnManageProduct.TabIndex = 5;
            this.btnManageProduct.Text = "&MANAGE PRODUCTS";
            this.btnManageProduct.UseVisualStyleBackColor = false;
            this.btnManageProduct.Click += new System.EventHandler(this.btnManageProduct_Click);
            // 
            // btnManageSupplier
            // 
            this.btnManageSupplier.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnManageSupplier.Location = new System.Drawing.Point(1015, 385);
            this.btnManageSupplier.Name = "btnManageSupplier";
            this.btnManageSupplier.Size = new System.Drawing.Size(271, 40);
            this.btnManageSupplier.TabIndex = 6;
            this.btnManageSupplier.Text = "MANAGE SUPPLIES";
            this.btnManageSupplier.UseVisualStyleBackColor = false;
            this.btnManageSupplier.Click += new System.EventHandler(this.btnManageSupplier_Click);
            // 
            // FormTravelPackagesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1355, 586);
            this.Controls.Add(this.btnManageSupplier);
            this.Controls.Add(this.btnManageProduct);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgViewPackages);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormTravelPackagesMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Packages Managment";
            this.Load += new System.EventHandler(this.FormTravelPackagesMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewPackages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewPackages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnManageProduct;
        private System.Windows.Forms.Button btnManageSupplier;
    }
}

