using PackageManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 Author:Sujani Wijesundera
Date:19/09/2021
Purpose: Form to add and modify suppliers
 */

namespace TravelExpertPKgManagmentGUI
{
    public partial class FormAddModifySuppliers : Form
    {
        public bool isAdd; //flag set to make add supplier in the form
        public Supplier supplier; // make supplier object to send to the main form
        public FormAddModifySuppliers()
        {
            InitializeComponent();
        }

        private void FormAddModifySuppliers_Load(object sender, EventArgs e)
        {
            if (isAdd) //Add value set true, from the main form
            {
                this.Text = "Add Supplier";

            }
            else //Modify values set to false in main form
            {
                txtSupplierName.Text = supplier.SupName; //set product name
            }
        }
//---------------------End of FormAddModify-------------------------------------------------

        //Add supplier
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isAdd)
            { // Add the product to database

                if (Validator.IsPresent(txtSupplierName) && Validator.IsNonAlphaNumeric(txtSupplierName)
                    )
                {
                    supplier = new Supplier();
                    supplier.SupName = txtSupplierName.Text; //asign the name

                   // DataGridViewRow row = dgViewSuppliers.Rows[dgViewSuppliers.CurrentRow.Index];//get the user selected row
                                                                                                 // string supplierID = row.Cells[0].Value.ToString().Trim(); // get the productCode of selected row.
                    
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            { //  Modify product object is already there
                if (Validator.IsPresent(txtSupplierName) && Validator.IsNonAlphaNumeric(txtSupplierName)
                     )
                {
                    supplier.SupName = txtSupplierName.Text; //asign the name
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        //------------------end of btnOK_Click----------------------------------------------------------------------
    }//class end
}
