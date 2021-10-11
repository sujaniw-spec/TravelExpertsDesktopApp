
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
Purpose: Form to add modify products and send to the database
 */
namespace TravelExpertPKgManagmentGUI
{
    public partial class FormAddModifyProduct : Form
    {
        public bool isAdd; //true when Add, and false when modify
        public Product product; //product object
        public ProductsSupplier productSupplier;//ProductSupplier
        public Supplier supplier; // Supplier
        private string selectedSupCode; //user selected cell
        private List<Int32> listSuppIdId    = new List<Int32>(); // list of selected supplier IDs
        public List<Supplier> supplierList  = new List<Supplier>(); // list of suppliers
        private List<Int32> listSuppIdIdAll = new List<Int32>(); //list of newly added and existing supplier ids.
        public List<Supplier> supplierListUpdate = new List<Supplier>(); // updated list of suppliers

        public FormAddModifyProduct()
        {
            InitializeComponent();
        }

        //Formload set display suppliers
        private void FormAddModifyProduct_Load(object sender, EventArgs e)
        {
            //deselect all the rows
            DisplaySuppliers();

            if (isAdd) //Add value set true, from the main form
            {
                this.Text = "Add Product";
               
            }
            else //Modify values set to false in main form
            {
                txtProductName.Text = product.ProdName; //set product name
                List<ProductsSupplier> prodSupplierList = null;// list to get suppliers

                prodSupplierList = ProductSupplierManager.GetSuppliersOfProduct(product.ProductId);//get all the suppliers related to the product
                foreach (ProductsSupplier ps in prodSupplierList)
                {
                    SelectAlreadyAddedSupplierRow(ps.SupplierId); //hilight already added suppliers list of the grid
                }
            }
        }

        /*
        Load products to the gridview and display products
        */
        private void DisplaySuppliers()
        {
            
            dgViewSuppliers.EnableHeadersVisualStyles = false; // turn off default visual style
            dgViewSuppliers.DataSource = ProductSupplierManager.GetSuppliers(); //bind data to the datagrid data source
            
            dgViewSuppliers.ClearSelection();

            dgViewSuppliers.EnableHeadersVisualStyles = false;
            dgViewSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgViewSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgViewSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgViewSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgViewSuppliers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MistyRose;
            dgViewSuppliers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Wheat;

            dgViewSuppliers.Columns[0].HeaderText = "Supplier ID";    //format the header of first column
            dgViewSuppliers.Columns[1].HeaderText = "Supplier Name";  //format the header of second column

            dgViewSuppliers.Columns[0].Width = 160;
            dgViewSuppliers.Columns[1].Width = 500;
            //cell alignment
            dgViewSuppliers.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgViewSuppliers.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }


        //Add or modify product
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isAdd)
            { // Add the product to database
                
                if (Validator.IsPresent(txtProductName) && Validator.IsNonAlphaNumeric(txtProductName) 
                    )
                {
                    product = new Product();
                    product.ProdName = txtProductName.Text; //asign the name
                    
                    DataGridViewRow row = dgViewSuppliers.Rows[dgViewSuppliers.CurrentRow.Index];//get the user selected row
                   // string supplierID = row.Cells[0].Value.ToString().Trim(); // get the productCode of selected row.
                   foreach(int supId in listSuppIdId)//user selected suppliers list
                    {
                        supplier = ProductSupplierManager.GetSupplier(supId); // get the Supplier 
                        supplierList.Add(supplier); // add supplier object to the list
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            { //  Modify product object is already there
                if (Validator.IsPresent(txtProductName) && Validator.IsNonAlphaNumeric(txtProductName)
                     )
                {
                    //product = new Product();
                    product.ProdName = txtProductName.Text; //asign the name

                    DataGridViewRow row = dgViewSuppliers.Rows[dgViewSuppliers.CurrentRow.Index];//get the user selected row
                                                                                                 // string supplierID = row.Cells[0].Value.ToString().Trim(); // get the productCode of selected row.
                    List<int> listSup = SelectAlreadyAddedAndNewSupplierRow();

                    foreach (int supId in listSup)//user selected suppliers list
                    {
                        supplier = ProductSupplierManager.GetSupplier(supId); // get the Supplier 
                        supplierListUpdate.Add(supplier); // add supplier object to the list
                    }

                    this.DialogResult = DialogResult.OK;


                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //get the select rows, supplierids to the list
        private void dgViewSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSupCode = dgViewSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            listSuppIdId.Add(Convert.ToInt32(selectedSupCode)); // Add all the selected cells to the list
        }

        /// <summary>
        /// Display the suppliers already added to the particular product
        /// 
        /// <paramref name="supplierId"/>
        /// </summary>
        /// <param name=supplierId"></param>
        private void SelectAlreadyAddedSupplierRow(int? supplierId)
        {
            string cellVal;
            string productId = supplierId.ToString();

            for (int i = 0; i < dgViewSuppliers.Rows.Count; i++) // go through all the rows
            {
                cellVal = dgViewSuppliers.Rows[i].Cells[0].Value.ToString().Trim(); // get the supplierId in the first cell

                if (cellVal == productId) // check if cell value is equals to supplierId code
                {
                  dgViewSuppliers.Rows[i].Selected = true; // select the row euqal to supplier id of the selected supplier
                }
            }
        }



        /// <summary>
        /// Display the suppliers already added to the particular product and newley added
        /// 
        /// <paramref name="supplierId"/>
        /// </summary>
        /// <param name=supplierId"></param>
        private List<int> SelectAlreadyAddedAndNewSupplierRow()
        {
            string cellVal;          
            DataGridViewSelectedRowCollection rows = dgViewSuppliers.SelectedRows;
            
            for (int i = 0; i < rows.Count; i++) // go through all the rows
            {
                cellVal = rows[i].Cells[0].Value.ToString().Trim(); // get the supplierId in the first cell
                listSuppIdIdAll.Add(Convert.ToInt32(cellVal)); // Add all the selected cells to the list
                //if (cellVal == productId) // check if cell value is equals to supplierId code
                //{
                //    dgViewSuppliers.Rows[i].Selected = true; // select the row euqal to supplier id of the selected supplier
                //}
            }
            return listSuppIdIdAll;
        }
        
    }//class end
}
