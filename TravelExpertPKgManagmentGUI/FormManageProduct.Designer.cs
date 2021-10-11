
namespace TravelExpertPKgManagmentGUI
{
    partial class FormManageProduct
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
            this.dgViewProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewProducts
            // 
            this.dgViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewProducts.Location = new System.Drawing.Point(12, 54);
            this.dgViewProducts.Name = "dgViewProducts";
            this.dgViewProducts.RowHeadersWidth = 51;
            this.dgViewProducts.RowTemplate.Height = 29;
            this.dgViewProducts.Size = new System.Drawing.Size(855, 426);
            this.dgViewProducts.TabIndex = 0;
            this.dgViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewProducts_CellClick);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(13, 497);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(196, 29);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "&ADD NEW PRODUCT";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "All the Products Available:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(773, 497);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormManageProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 538);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgViewProducts);
            this.Name = "FormManageProduct";
            this.Text = "FormManageProduct";
            this.Load += new System.EventHandler(this.FormManageProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}