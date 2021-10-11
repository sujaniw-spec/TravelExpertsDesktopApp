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
Date:18/09/2021
Purpose: Form to main page for manage products
 */

namespace TravelExpertPKgManagmentGUI
{
    public partial class FormManageProduct : Form
    {
        private Product product; // product object to assign from sub form
        //private Supplier supplier; // supplier object to assign from sub form
       // private ProductsSupplier productSupplier; // productSupplier object to assign from sub form
        private List <Supplier> suppliersList= new List<Supplier>();//make the variable to get suupplier list from sub form
        private List<Supplier> suppliersLstUpdate = new List<Supplier>();//make the variable to get suupplier listupdated from sub form

        public FormManageProduct()
        {
            InitializeComponent();
            
        }
        
        /*
         Display products when form loads
         */
        private void FormManageProduct_Load(object sender, EventArgs e)
        {
            DisplayProducts(); //display all products
        }

//--------------------------end of FormManager load-------------------------------------------------------------

        /*
         Load products to the gridview and display products
         */
        private void DisplayProducts()
        {

            dgViewProducts.EnableHeadersVisualStyles = false; // turn off default visual style
            dgViewProducts.Columns.Clear();
            dgViewProducts.DataSource = ProductSupplierManager.GetProducts(); //bind data to the datagrid data source

            //add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };

            dgViewProducts.Columns.Add(modifyColumn);

            dgViewProducts.EnableHeadersVisualStyles = false;
            dgViewProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgViewProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgViewProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MistyRose;
            dgViewProducts.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Wheat;

            dgViewProducts.Columns[0].HeaderText = "Product ID";    //format the header of first column
            dgViewProducts.Columns[1].HeaderText = "Product Name";  //format the header of second column

            dgViewProducts.Columns[0].Width = 140;
            dgViewProducts.Columns[1].Width = 500;
            //cell alignment
            dgViewProducts.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgViewProducts.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
//--------------------------end of DisplayProducts----------------------------------------------------------------
      
        /// <summary>
        /// Modify the products - Add suppliers to the product
        /// </summary>
        private void ModifyProduct()
        {
            FormAddModifyProduct addModifyProductForm = new FormAddModifyProduct();

            addModifyProductForm.isAdd = false; // to set the form heading dynamically
            addModifyProductForm.product = product;
            string messge = null; // message get after apdating
            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.product       = addModifyProductForm.product;
                    this.suppliersLstUpdate = addModifyProductForm.supplierListUpdate;

                    messge = ProductSupplierManager.updateProductProductSupplier(product, suppliersLstUpdate); //update product and pass sulist to the database and check adding sucess. Exception 
                    
                    DisplayProducts();
                    SelectChangeRow(product.ProductId.ToString());
                }
                catch (Exception ex)
                {
                    messge = ex.Message;
                    MessageBox.Show($"Error when updating product: {messge}", // show the error message
                                      ex.GetType().ToString());
                   
                }
                if (messge == "success")
                {
                    MessageBox.Show($"Success updating the product {product.ProductId}: {messge}","Success!" ); // show the error message

                }
            }
        }
        //--------------------------------------end of ModifyProduct()----------------------------------------------

        //Button click to Add new Product
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddModifyProduct addForm = new FormAddModifyProduct(); //create an object of second form
            addForm.isAdd = true; // to set the form heading dynamically

            string messge = ""; // to get the message return from the Add method.

            DialogResult result = addForm.ShowDialog(); //show dialog to dispaly second form

            if (result == DialogResult.OK)
            {
                this.product  = addForm.product; // assign new product created in the second form to Main form
                this.suppliersList = addForm.supplierList; // assign new suppliers list created in the second form to Main form

                try
                {
                   messge = ProductSupplierManager.addProductProductSupplier(product, suppliersList);     //Add product and pass sulist to the database and check adding sucess. Exception 

                    //throws, if the prodcuctCode already in the database
                    if (messge != "success") // Any other exceptions occur in the Add method
                    {
                        MessageBox.Show($"{messge}");
                    }
                 //   DisplayPackages(); // display all packages
                }
                catch (Exception ex) // Exception handling
                {
                    MessageBox.Show($"Error when adding product: {ex.Message}", // show the error message
                                       ex.GetType().ToString());
                }

                if (messge == "success") // if product added to the database
                {
                    MessageBox.Show($"ProductCode: {product.ProductId} Added Success!",
                                           "Success!");
                    DisplayProducts();
                    suppliersList.Clear();
                    SelectChangeRow(product.ProductId.ToString()); //select the newly added row.
                }
            }
        }


        /// <summary>
        /// When a new product adds to the table, select the particular row
        /// 
        /// <paramref name="productId"/>
        /// </summary>
        /// <param name="productId"></param>
        private void SelectChangeRow(string productId)
        {
            string cellVal;

            for (int i = 0; i < dgViewProducts.Rows.Count; i++) // go through all the rows
            {
                cellVal = dgViewProducts.Rows[i].Cells[0].Value.ToString().Trim(); // get the packageId in the first cell

                if (cellVal == productId) // check if cell value is equals to PackageId code
                {
                    dgViewProducts.ClearSelection(); // clear default selection
                    dgViewProducts.Rows[i].Selected = true; // select the row
                    dgViewProducts.CurrentCell = dgViewProducts.Rows[i].Cells[0]; // set the seelcted row to current row

                    break; // break the loop when equal packageid  found
                }
            }
        }

        //Close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click the modifybutton
        private void dgViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //store index values for Modify button column
            const int ModifyIndex = 2;
            string productCode = null;
        
            if (e.ColumnIndex == ModifyIndex)
            {
                productCode     = dgViewProducts.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                product = ProductSupplierManager.GetProduct(Convert.ToInt32(productCode));
                ModifyProduct();
            }

        }
        //------------------------- end of SelectChangeRow------------------------------------------------------------------------------

    }//class end
}
