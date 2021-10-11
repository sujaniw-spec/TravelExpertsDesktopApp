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
Purpose: Form to main page for manage suppliers
 */
namespace TravelExpertPKgManagmentGUI
{
    public partial class FormManageSupplier : Form
    {
        private Supplier supplier; //suppler object to assign from Add/modify
        public FormManageSupplier()
        {
            InitializeComponent();
        }

        /*
        Load suppliers to the gridview and display suppliers
        */
        private void DisplaySuppliers()
        {

            dgViewSupplier.EnableHeadersVisualStyles = false; // turn off default visual style
            dgViewSupplier.Columns.Clear();
            dgViewSupplier.DataSource = ProductSupplierManager.GetSuppliers(); //bind data to the datagrid data source

            //add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };

            dgViewSupplier.Columns.Add(modifyColumn);

            dgViewSupplier.EnableHeadersVisualStyles = false;
            dgViewSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgViewSupplier.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgViewSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgViewSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgViewSupplier.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MistyRose;
            dgViewSupplier.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Wheat;

            dgViewSupplier.Columns[0].HeaderText = "Supplier ID";    //format the header of first column
            dgViewSupplier.Columns[1].HeaderText = "Supplier Name";  //format the header of second column

            dgViewSupplier.Columns[0].Width = 140;
            dgViewSupplier.Columns[1].Width = 500;
            //cell alignment
            dgViewSupplier.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgViewSupplier.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        //--------------------------end of DisplaySuppliers----------------------------------------------------------------


        private void FormManageSupplier_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }


        //close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Add a new supplier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddModifySuppliers addForm = new FormAddModifySuppliers(); //create an object of second form
            addForm.isAdd = true; // to set the form heading dynamically

            string messge = ""; // to get the message return from the Add method.

            DialogResult result = addForm.ShowDialog(); //show dialog to dispaly second form

            if (result == DialogResult.OK)
            {
                this.supplier = addForm.supplier; // assign new supplier created in the second form to Main form
            
                try
                {
                    messge = ProductSupplierManager.AddSupplier(supplier);//Add supplier and to the database and check adding sucess. Exception 

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
                    MessageBox.Show($"SupplierID: {supplier.SupplierId} Added Success!",
                                           "Success!");
                    DisplaySuppliers();
                   // suppliersList.Clear();
                    SelectChangeRow(supplier.SupplierId.ToString()); //select the newly added row.
                }
            }
        }

        /// <summary>
        /// When a new product adds to the table, select the particular row
        /// 
        /// <paramref name="supplierId"/>
        /// </summary>
        /// <param name="supplierId"></param>
        private void SelectChangeRow(string supplierId)
        {
            string cellVal;

            for (int i = 0; i < dgViewSupplier.Rows.Count; i++) // go through all the rows
            {
                cellVal = dgViewSupplier.Rows[i].Cells[0].Value.ToString().Trim(); // get the supplierId in the first cell

                if (cellVal == supplierId) // check if cell value is equals to SupplierId code
                {
                    dgViewSupplier.ClearSelection(); // clear default selection
                    dgViewSupplier.Rows[i].Selected = true; // select the row
                    dgViewSupplier.CurrentCell = dgViewSupplier.Rows[i].Cells[0]; // set the seelcted row to current row

                    break; // break the loop when equal supplierid  found
                }
            }
        }

        //--------------------------end of selectChangeRow------------------------------------------------------------------     

        /// <summary>
        /// Modify the suppliers - edit supplier name
        /// </summary>
        private void ModifySuppliers()
        {
            FormAddModifySuppliers addModifySupplerForm = new FormAddModifySuppliers();

            addModifySupplerForm.isAdd = false; // to set the form heading dynamically
            addModifySupplerForm.supplier = supplier;
            string messge = null; // message get after apdating
            DialogResult result = addModifySupplerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.supplier = addModifySupplerForm.supplier;
                    messge = ProductSupplierManager.updateSupplierName(supplier);//update the supplier name                    
                }
                catch (Exception ex)
                {
                    messge = ex.Message;
                    MessageBox.Show($"SupplierID: {supplier.SupplierId} Updated not Success! {messge}",
                                          "Success!");

                }
                if (messge == "success")
                {
                    DisplaySuppliers();
                    SelectChangeRow(supplier.SupplierId.ToString());
                    MessageBox.Show($"SupplierID: {supplier.SupplierId} Updated Success!",
                                          "Success!");
                }
            }
        }

        /// <summary>
        /// Click the modify button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //store index values for Modify button column
            const int ModifyIndex = 2;
            string supplierId = null;

            if (e.ColumnIndex == ModifyIndex)
            {
                supplierId = dgViewSupplier.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();//get the cell index
                supplier = ProductSupplierManager.GetSupplier(Convert.ToInt32(supplierId));//get the particular supplier object
                ModifySuppliers();
            }

        }
        //--------------------------------------end of ModifyProduct()----------------------------------------------



    }//end class
}
