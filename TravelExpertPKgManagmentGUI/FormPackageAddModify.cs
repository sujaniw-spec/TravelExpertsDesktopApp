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
Date:16/09/2021
Purpose: Form to add and edit packages
 */
namespace TravelExpertPKgManagmentGUI
{
    public partial class FormPackageAddModify : Form
    {
        //public data that is set by main form
        public bool isAdd; //true when Add, and false when modify
        public Package package;
        public Package packageOld;
        public ProductsSupplier productSupplier;

        public FormPackageAddModify()
        {
            InitializeComponent();
        }

        private void FormPackageAddModify_Load(object sender, EventArgs e)
        {
            
            DisplayProducts();  // display products in the combobox
                                
            int prodId = 1; // display default productid when form loads
            DisplaySuppliersByProductId(prodId); // dispaly suppliers in the combobox belongs to prodcutId
            if (isAdd) //Add value set true, from the main form
            {
                this.Text = "Add Package";
                lblPkg.Visible = false;
                lblPackageId.Visible = false;
            }
            else //Modify values set to false in main form
            {
                packageOld = new Package();
                packageOld.PackageId = package.PackageId;
                packageOld.PkgName = package.PkgName;

                lblPkg.Visible = true;
                lblPackageId.Visible = true;

                this.Text = "Modify Package";
                if (package == null)
                {
                    MessageBox.Show("There is no current pacakge", "Modify Error");
                    this.DialogResult = DialogResult.Cancel;

                }
                //display current package in the text box
               
                int productSupplierId = PackageManager.GetProductSupplierId(package.PackageId).ProductSupplierId;//get prodcutsupplier id
                int productId   = PackageManager.GetProductIdFromproductSuppliers(productSupplierId);//get product id
                int supplierId  = PackageManager.GetSupplierIdFromproductSuppliers(productSupplierId);//get supplier id


                DisplayProductById(productId);  // display product the package contains
                DisplaySuppliersBySupplierId(productId, supplierId); // display supplier package contains
                lblPackageId.Text = package.PackageId.ToString(); //asign packageId to label
                txtName.Text      = package.PkgName; //asign PkgName
                txtDescription.Text = package.PkgDesc; //asign PkgDesc
                if (package.PkgStartDate != null)
                {
                    dtpStart.Value = Convert.ToDateTime(package.PkgStartDate); //asign PkgStartDate
                    dtpEnd.Value = Convert.ToDateTime(package.PkgEndDate); //asign PkgEndDate
                }
                txtBasePrice.Text = package.PkgBasePrice.ToString("f2"); //asign PkgBasePrice

                txtCommision.Text = Convert.ToString(package.PkgAgencyCommission); //asign commisson
                txtCommision.Text = Convert.ToDecimal(txtCommision.Text).ToString("f2");//     
                string commison = txtCommision.Text;
                if (commison != "0.00")
                {

                    txtCommision.Text = Convert.ToDecimal(txtCommision.Text).ToString("f2");//                                                                   //
                }
                else
                {
                    txtCommision.Text = "";
                }
                    
            }
        }
        /// <summary>
        /// retreive suppliers only includes to the productId
        /// </summary>
        /// <param name="prodId"></param>
        private void DisplaySuppliersByProductId(int prodId)
        {
            cmbSupplier.ValueMember = "SupplierId";
            cmbSupplier.DisplayMember = "SupName";

            cmbSupplier.DataSource = PackageManager.GetSuppliersByProductId(prodId);//select suppliers by productId
        }

//----------end of DisplaySuppliersByProductId()-------------------------------------------------------------

          /// <summary>
        /// Select that product that package contains in the products combo box - view data for modify
        /// </summary>
        private void DisplayProductById(int productId)
        {
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.DisplayMember = "ProdName";

            cmbProduct.DataSource = PackageManager.GetProducts();
            cmbProduct.SelectedValue = productId;

        }
//----end of DisplayProductById()-------------------------------------------------------------------------------

     
        //Display all the products
        private void DisplayProducts()
        {
            cmbProduct.ValueMember = "ProductId";
            cmbProduct.DisplayMember = "ProdName";

            cmbProduct.DataSource = PackageManager.GetProducts();
        }
//----end of DisplayProductById()-----------------------------------------------------------------------------

        /// <summary>
        /// Display Suppliers in the supplier dropdown
        /// </summary>
        private void DisplaySuppliersBySupplierId(int prodId,int spplierId)
        {
            cmbSupplier.ValueMember = "SupplierId";
            cmbSupplier.DisplayMember = "SupName";

            cmbSupplier.DataSource = PackageManager.GetSuppliersByProductId(prodId);
            cmbSupplier.SelectedValue = spplierId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isAdd)
            { // Add the product to database
                //validating the text boxes and date picker - date shoild be greater than the current date
                //product code should be apha numric. Name should be text or alpha numeric
                if (Validator.IsPresent(txtName) && Validator.IsNonAlphaNumeric(txtName) &&
                    Validator.IsPresent(txtBasePrice) && Validator.IsNonNegativeDecimal(txtBasePrice) &&
                    Validator.IsBasePriceGrater(txtBasePrice, txtCommision) && Validator.IsPresentIfEntered(txtDescription)
                     && Validator.IsValidEndDateIfPresent(dtpStart, dtpEnd)
                    )
                {
                    SetTravelPackage(); //create a Package object to send the DB
                    SetProductsSuppliers(); //create a ProductSupplier object to send the DB
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            { //  Modify product object is already there
                if (Validator.IsPresent(txtName) && Validator.IsNonAlphaNumeric(txtName) &&
                   Validator.IsPresent(txtBasePrice) && Validator.IsNonNegativeDecimal(txtBasePrice) &&
                   Validator.IsBasePriceGrater(txtBasePrice, txtCommision) && Validator.IsPresentIfEntered(txtDescription)
                   && Validator.IsValidEndDateIfPresent(dtpStart, dtpEnd) && Validator.IsBasePriceGrater(txtBasePrice, txtCommision)
                   )
                {
                    //set the new values to the package object
                    package.PkgName = txtName.Text;
                    if (chkDateSelect.Checked || (!dtpStart.Value.ToString().Equals(dtpEnd.Value.ToString())))//check the checked box select or not
                    {
                        package.PkgStartDate = Convert.ToDateTime(dtpStart.Value);
                        package.PkgEndDate = Convert.ToDateTime(dtpEnd.Value);
                    }
                    else
                    {
                        package.PkgStartDate = null;
                        package.PkgEndDate = null;
                    }
                    package.PkgDesc = txtDescription.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);

                    if (txtCommision.Text.Trim().Length != 0)
                    {
                        package.PkgAgencyCommission = Convert.ToDecimal(txtCommision.Text);
                    }
                    else
                    {
                        package.PkgAgencyCommission = 0;
                    }
                    package.PkgName = txtName.Text;

                    //Validate Package changed or not
                    if (package.Equals(packageOld))
                    {
                        MessageBox.Show("Package is not modified!");
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    SetProductsSuppliers();//create a PS object to send the DB with updated values
                }
            }
        }
  //---------------end of btnOK_Click()--------------------------------------------------------------------------------------


        /// <summary>
        /// Set Package object instance form the form inputs
        /// </summary>
        private void SetTravelPackage()
        {
            package = new Package();
            package.PkgName = txtName.Text;
            package.PkgDesc = txtDescription.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
            if (txtCommision.Text.Trim().Length != 0)
            {
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommision.Text);
            }
            else
            {
                package.PkgAgencyCommission = 0;
            }
            // if the start date and end date is is equalsend null values.                     
            if (chkDateSelect.Checked )//check the checked box select or not
            {
                package.PkgStartDate = Convert.ToDateTime(dtpStart.Value);
                package.PkgEndDate   = Convert.ToDateTime(dtpEnd.Value);
            }
            else
            {
                package.PkgStartDate = null;
                package.PkgEndDate   = null;
            }

            //if (dtpStart.Value.ToString().Equals(dtpEnd.Value.ToString())) 
            //{
            //    package.PkgStartDate = null;
            //    package.PkgEndDate   = null;
            //}
            //else
            //{
            //    package.PkgStartDate = dtpStart.Value;
            //    package.PkgEndDate   = dtpEnd.Value;
            //}
        }

//----------------------end of SetTravelPackage-----------------------------------------------------------
       
        /// <summary>
        /// Set ProductsSupplier object instance from the inputs
        /// </summary>
        private void SetProductsSuppliers()
        {
            productSupplier = new ProductsSupplier();
            productSupplier.ProductId  = Int32.Parse(cmbProduct.SelectedValue.ToString());
            productSupplier.SupplierId = Int32.Parse(cmbSupplier.SelectedValue.ToString());
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySuppliersByProductId(Convert.ToInt32(cmbProduct.SelectedValue));
        }
    } // class end
}
