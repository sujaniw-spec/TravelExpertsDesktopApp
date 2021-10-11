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
Purpose: Main page to display all packages, navigations to other functionalities
 */
namespace TravelExpertPKgManagmentGUI
{
    public partial class FormTravelPackagesMain : Form
    {
        private Package package; // Package entity
        private ProductsSupplier productSupplier; // ProductSupplier Entity

        public FormTravelPackagesMain()
        {
            InitializeComponent();
        }

        /*
         * Display all packages when he form laoding
         
         */
        private void FormTravelPackagesMain_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            dgViewPackages.Width = this.Width - 100;

            DisplayPackages(); // display all packages
        }


        /// <summary>
        /// Display all the packages in the datagrid view.
        /// </summary>
        private void DisplayPackages()
        {
            dgViewPackages.EnableHeadersVisualStyles = false; // turn off default visual style
            dgViewPackages.DataSource = PackageManager.GetPackages(); //bind data to the datagrid data source

            foreach (DataGridViewColumn item in dgViewPackages.Columns) //set columns values align middle center
            {
              //  item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgViewPackages.Columns[5].DefaultCellStyle.Format = "c";
            dgViewPackages.Columns[6].DefaultCellStyle.Format = "c";

           // dgViewPackages.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // set middle left
           // dgViewPackages.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; //set middle left
            dgViewPackages.Columns[0].Width = 145; // set the PackageId column width
            dgViewPackages.Columns[1].Width = 300; // set the pacakgename column width
            dgViewPackages.Columns[2].Width = 150; // set the start date column width
            dgViewPackages.Columns[3].Width = 150; // set the end date column width
            dgViewPackages.Columns[4].Width = 550; // set the end date column width
            dgViewPackages.Columns[5].Width = 200; // set the description column width
            dgViewPackages.Columns[6].Width = 250; // set the end date column width
            dgViewPackages.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy"; // date format
            dgViewPackages.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy"; // date format

            dgViewPackages.Columns[0].HeaderText = "Package ID";
            dgViewPackages.Columns[1].HeaderText = "Package Name";            
            dgViewPackages.Columns[2].HeaderText = "Start Date";
            dgViewPackages.Columns[3].HeaderText = "End Date";
            dgViewPackages.Columns[4].HeaderText = "Description";
            dgViewPackages.Columns[5].HeaderText = "Base Price";
            dgViewPackages.Columns[6].HeaderText = "Agency Commission";

            dgViewPackages.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgViewPackages.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgViewPackages.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgViewPackages.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //format grid
            dgViewPackages.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            
            // dgViewPackages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgViewPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgViewPackages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgViewPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgViewPackages.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.MistyRose;
            dgViewPackages.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Wheat;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormPackageAddModify addForm = new FormPackageAddModify(); //create an object of second form
            addForm.isAdd = true; // to set the form heading dynamically

            string messge = ""; // to get the message return from the Add method.

            DialogResult result = addForm.ShowDialog(); //show dialog to dispaly second form

            if (result == DialogResult.OK)
            {
                this.package = addForm.package; // assign new package created in the second form to Main form
                this.productSupplier = addForm.productSupplier; // assign new productSupplier created in the second form to Main form
                
                try
                {
                    messge = PackageManager.AddTravelPackage(package, productSupplier);     //Add package and product supplier to the database and check adding sucess. Exception 
                    
                    //throws, if the prodcuctCode already in the database
                    if (messge != "success") // Any other exceptions occur in the Add method
                    {
                        MessageBox.Show($"{messge}");
                    }
                    DisplayPackages(); // display all packages
                }
                catch (Exception ex) // Exception handling
                {
                    MessageBox.Show($"Error when adding product: {ex.Message}", // show the error message
                                       ex.GetType().ToString());
                }

                if (messge == "success") // if product added to the database
                {
                    MessageBox.Show($"ProductCode: {package.PackageId} Added Success!",
                                           "Success!");
                    SelectChangeRow(package.PackageId.ToString()); //select the newly added row.
                }
            }
        }
        //-------------------------------------------------end of DisplayProducts-----------------------------------------------------

        /// <summary>
        /// When a new package adds to the table, select the particular row
        /// 
        /// <paramref name="packageId"/>
        /// </summary>
        /// <param name="packageId"></param>
        private void SelectChangeRow(string packageId)
        {
            string cellVal;

            for (int i = 0; i < dgViewPackages.Rows.Count; i++) // go through all the rows
            {
                cellVal = dgViewPackages.Rows[i].Cells[0].Value.ToString().Trim(); // get the packageId in the first cell

                if (cellVal == packageId) // check if cell value is equals to PackageId code
                {
                    dgViewPackages.ClearSelection(); // clear default selection
                    dgViewPackages.Rows[i].Selected = true; // select the row
                    dgViewPackages.CurrentCell = dgViewPackages.Rows[i].Cells[0]; // set the seelcted row to current row

                    break; // break the loop when equal packageid  found
                }
            }
        }
        //------------------------- end of SelectChangeRow------------------------------------------------------------------------------

        /*
         * Exit the application
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
//----------------------- end of btnCancel_Click------------------------------------------------------------------------------

/**
 * Update the package
 */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormPackageAddModify modifyForm = new FormPackageAddModify(); // get the second form
            modifyForm.isAdd = false; // this not Add but Modify
            string flag="success"; // flag to display messages

            DataGridViewRow row = dgViewPackages.Rows[dgViewPackages.CurrentRow.Index];//get the user selected row
            string packageID = row.Cells[0].Value.ToString().Trim(); // get the productCode of selected row.
            package = PackageManager.GetPackage(Convert.ToInt32(packageID)); // get the Package related to the packageId from the database

            modifyForm.package = this.package; // Assign the seelcted package to modify form

            DialogResult result = modifyForm.ShowDialog(); //display modify form
            if (result == DialogResult.OK) // if user clicks the OK button
            {
                this.package = modifyForm.package; // assign modified package to old product
                this.productSupplier = modifyForm.productSupplier; // assign new productSupplier created in the second form to Main form
                try
                {
                    flag = PackageManager.Modify(package, productSupplier); // package has new data values
                    DisplayPackages(); //dispaly packages again
                }

                catch (Exception ex) // if exception occur
                {
                    flag = "error"; // make the flag false
                    MessageBox.Show($"Error when updating package: {ex.Message}",
                                       ex.GetType().ToString());
                }

                if (flag == "success") // if flag true dispaly the success message
                {
                    MessageBox.Show($"PackageID: {packageID} Modified Success!",
                                           "Success!");

                   SelectChangeRow(packageID); // Select the updated row.

                }
                else
                {
                    MessageBox.Show($"PackageID: {packageID} ModifiedError! {flag}",
                                           "Error!");

                    SelectChangeRow(packageID); // Select the updated row.
                }
            }
        }
        //-------------------- end of btnEdit_Click------------------------------------------------------------------------------


        //go to the next form to manage products
        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            FormManageProduct manageProductForm = new FormManageProduct();
            manageProductForm.Show();
        }

        /**
         *Supplier management
         */
        private void btnManageSupplier_Click(object sender, EventArgs e)
        {
            FormManageSupplier manageSupplierForm = new FormManageSupplier();
            manageSupplierForm.Show();
        }
    

        //-------------End of btnManageSupplier_Click ----------------------------------------------------------
    }//end of the class
}
