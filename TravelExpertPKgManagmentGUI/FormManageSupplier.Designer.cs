
namespace TravelExpertPKgManagmentGUI
{
    partial class FormManageSupplier
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
            this.dgViewSupplier = new System.Windows.Forms.DataGridView();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewSupplier
            // 
            this.dgViewSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewSupplier.Location = new System.Drawing.Point(28, 48);
            this.dgViewSupplier.Name = "dgViewSupplier";
            this.dgViewSupplier.RowHeadersWidth = 51;
            this.dgViewSupplier.RowTemplate.Height = 29;
            this.dgViewSupplier.Size = new System.Drawing.Size(842, 265);
            this.dgViewSupplier.TabIndex = 0;
            this.dgViewSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewSupplier_CellClick);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(28, 347);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(137, 29);
            this.btnAddSupplier.TabIndex = 1;
            this.btnAddSupplier.Text = "ADD SUPPLIER";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(776, 347);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormManageSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.dgViewSupplier);
            this.Name = "FormManageSupplier";
            this.Text = "FormManageSupplier";
            this.Load += new System.EventHandler(this.FormManageSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnExit;
    }
}