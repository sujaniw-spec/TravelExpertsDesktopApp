using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* TravelExpert Workshop 3
 * Purpose:Handle DB connections for products and suppliers management
 * Author: Sujani Wijesundera
 * Date:17/September/2021
 * 
 */
namespace PackageManagement
{
    public static class ProductSupplierManager
    {
        /// <summary>
        /// Get all the products in descending order by product id
        /// </summary>
        /// <returns>List<PackageDTO></returns>
        public static List<ProductDTO> GetProducts()
        {

            List<Product> products = null;
            List<ProductDTO> productDTOs = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                products = db.Products.OrderBy(p => p.ProductId).ToList(); // get data from db desc order by product id

                if (products != null)
                {
                    productDTOs = new List<ProductDTO>();//to simplify add data to DTO
                    foreach (Product p in products)
                        productDTOs.Add(new ProductDTO
                        {
                            ProductId = p.ProductId,
                            ProdName = p.ProdName

                        });
                }
            }
            return productDTOs;

        }

        //-------------------------------------end of GetProducts-------------------------------------------------------------
        /// <summary>
        /// Get all the suppliers of relavent productId
        /// <Params>prodId</Params>
        /// /// </summary>
        /// <returns>List<SupplierDTO></returns>
        public static List<ProductsSupplier> GetSuppliersOfProduct(int prodId)
        {

            List<ProductsSupplier> suppliers = null;
            //  List<ProductSupplierDTO> supplierDTOs = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                suppliers = db.ProductsSuppliers.Where(s => s.ProductId == prodId).ToList(); // get data from db desc order by product id
            }
            return suppliers;

        }

        //-------------------------------------end of GetSuppliersOfProduct-------------------------------------------------------------


        /// <summary>
        /// Get all the suppliers in asc order by supplier id
        /// </summary>
        /// <returns>List<SupplierDTO></returns>
        public static List<SupplierDTO> GetSuppliers()
        {

            List<Supplier> suppliers = null;
            List<SupplierDTO> supplierDTOs = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                suppliers = db.Suppliers.OrderBy(s => s.SupplierId).ToList(); // get data from db desc order by supplier id

                if (suppliers != null)
                {
                    supplierDTOs = new List<SupplierDTO>();
                    foreach (Supplier s in suppliers)
                        supplierDTOs.Add(new SupplierDTO
                        {
                            SupplierId = s.SupplierId,
                            SupName = s.SupName

                        });
                }
            }
            return supplierDTOs;

        }
        //-------------------------------------end of GetSuppliers-------------------------------------------------------------

        /// <summary>
        /// retrieves data of a supplier based on supplierId
        /// </summary>
        /// <param name="supplierId"> SupplierId</param>
        /// <returns>supplier object or null if not found</returns>
        public static Supplier GetSupplier(int supplierId)
        {
            Supplier supplier = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                supplier = db.Suppliers.Find(supplierId);
            }
            return supplier;
        }
        //-------------------------------------end of GetSuppliers-------------------------------------------------------------

        /// <summary>
        /// retrieves data of a productsupplier based on supplierId
        /// </summary>
        /// <param name="supplierId"> SupplierId</param>
        /// <returns>supplier object or null if not found</returns>
        public static ProductsSupplier GetSupplieProductrByProductId(int productid, int supplierId)
        {
            ProductsSupplier supplier = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                supplier = db.ProductsSuppliers.Where(y => y.ProductId.Equals(productid) && y.SupplierId.Equals(supplierId)).FirstOrDefault();
                //seelct productsuppliers equals to productid and supplierid
            }
            return supplier;
        }
        //-------------------------------------end of GetSuppliers-------------------------------------------------------------




        /// <summary>
        /// Add product table record and add record to the productsupplier
        /// </summary>
        /// <param name="p">product</param>
        /// <param name="supList">supList</param>
        /// <returns>string end message</returns>

        public static string addProductProductSupplier(Product p, List<Supplier> supList)
        {
            int productId = 0;
            string message = "success";

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                try
                {
                    //Start database transaction since inserting in to 3 tables
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        //Insert into package table
                        context.Products.Add(p);
                        context.SaveChanges();
                        //Get product Id from the newly added row
                        productId = p.ProductId;
                        if (supList.Count != 0) //if user select suppliers
                        {
                            foreach (Supplier s in supList)
                            {
                                ProductsSupplier ps = new ProductsSupplier();
                                ps.ProductId = productId;
                                ps.SupplierId = s.SupplierId;
                                //context.SaveChanges();

                                context.ProductsSuppliers.Add(ps);
                                context.SaveChanges();
                            }
                        }

                        //End transactions
                        dbContextTransaction.Commit();
                    }
                }
                catch (DbUpdateException exception)
                {
                    var sqlException = (SqlException)exception.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        if (error.Number == 2627)
                        { // Error message for primary key unique constraint violate.
                            message = "PackageId Not Unique";
                            break;
                        }
                        else
                        {
                            message = message += "ERROR CODE:  " + error.Number + " " +
                                           error.Message + "\n";
                        }
                    }

                }
                catch (Exception ex)
                {

                    message = ex.Message + " " + ex.GetType().ToString();

                }
            }
            return message;

        }



        /// <summary>
        ///update product table record and add record to the productsupplier
        /// </summary>
        /// <param name="p">product</param>
        /// <param name="supList">supList</param>
        /// <returns>string end message</returns>

        public static string updateProductProductSupplier(Product p, List<Supplier> supList)
        {
            int productId = 0;
            string message = "success";
            bool deleteFlag = false;
            List<ProductsSupplier> newUpdatelist = new List<ProductsSupplier>();
            List<ProductsSupplier> listProdSup1 = new List<ProductsSupplier>();

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        //Update product table
                        Product pEx = context.Products.First(pe => pe.ProductId == p.ProductId);

                        pEx.ProdName = p.ProdName;
                        context.Update(pEx);
                       context.SaveChanges();

                        productId = p.ProductId;

                        if (supList.Count != 0) //if user select the supplier
                        {
                            foreach (Supplier s in supList)
                            {
                                //ProductsSupplier pSold = context.ProductsSuppliers.First(po => po.ProductId == productId && po.SupplierId == s.SupplierId);
                                ProductsSupplier pSold = context.ProductsSuppliers.Where(y => y.ProductId.Equals(productId) && y.SupplierId.Equals(s.SupplierId)).FirstOrDefault();
                                //int? val=  pSold.ProductId;
                                ProductsSupplier psNew = null;
                                if (pSold == null)// insert new supplier and product id
                                {
                                    psNew = new ProductsSupplier();
                                    psNew.ProductId = productId;
                                    psNew.SupplierId = s.SupplierId;
                                    context.ProductsSuppliers.Add(psNew);
                                    context.SaveChanges();
                                }
                                else// update existing supplier to the product
                                {

                                    pSold.ProductId = productId;
                                    pSold.SupplierId = s.SupplierId;
                                    context.Update(pSold);
                                    int prodsuppId = context.SaveChanges();
                                    ProductsSupplier pSold1 = context.ProductsSuppliers.Where(p => p.ProductId == productId && p.SupplierId == s.SupplierId).FirstOrDefault();

                                    newUpdatelist.Add(pSold1);
                                }

                            }
                      
                        }
                        else // delete the existing records. Because user deselect them from the datagrid
                        {
                            List<ProductsSupplier> listSupp = GetSuppliersOfProduct(productId);
                            foreach (ProductsSupplier ps in listSupp)
                            {
                                context.Remove(ps);
                                context.SaveChanges();
                            }
                            deleteFlag = true;
                        }


                        //End transactions
                        dbContextTransaction.Commit();

                        if (!deleteFlag)
                        {

                            if (supList.Count != 0)
                            {

                                foreach (Supplier sup in supList)
                                {
                                    ProductsSupplier supProd = GetSupplieProductrByProductId(productId, sup.SupplierId);
                                    listProdSup1.Add(supProd); // list form the user
                                }

                            }

                            List<ProductsSupplier> listPS = GetSuppliersOfProduct(productId);//get all from db

                            List<ProductsSupplier> result1 = new List<ProductsSupplier>();

                           // result1.AddRange(listPS.Except(listProdSup1));

                      
                            if (listProdSup1.Count != listPS.Count)
                            {
                                var result = listPS.Where(p => listProdSup1.All(p2 => !p2.Equals(p))).ToList();
                                List<ProductsSupplier> list = result;

                                foreach (ProductsSupplier psD in listProdSup1)
                                {
                                    // if (!(listProdSup1.Contains(psD)))
                                    if (listPS.Find(m => m.SupplierId == psD.SupplierId) == null)
                                        // {
                                        //foreach (ProductsSupplier psNew in newUpdatelist)
                                        //{

                                        //    if (psD.SupplierId != psNew.SupplierId)
                                        //    {
                                        using (TravelExpertsContext db = new TravelExpertsContext())
                                        {
                                            db.Remove(psD);
                                          db.SaveChanges();
                                        }
                                }
                            }
                        }
                       
                    }
                }
                catch (DbUpdateException exception)
                {

                    var sqlException = (SqlException)exception.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        if (error.Number == 547)
                        { // Error message for primary key unique constraint violate.
                            message = "YOU CANT DELETE THIS SUPPLIER. IT HAS PACKAGE ASSOCIATED";
                            break;
                        }
                        else
                        {
                            message += "ERROR CODE:  " + error.Number + " " +
                                           error.Message + "\n";
                        }
                    }

                }
                catch (Exception ex)
                {

                    message = ex.Message + " " + ex.GetType().ToString();

                }
            }
            return message;

        }

        /// <summary>
        /// retrieves data of a package based on packageId
        /// </summary>
        /// <param name="packageId"> PackageId</param>
        /// <returns>package object or null if not found</returns>
        public static Product GetProduct(int prodId)
        {
            Product prod = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                prod = db.Products.Find(prodId);
            }
            return prod;
        }
        //---------------------------end of getProduct--------------------------------------------------------------

        /// <summary>
        /// Add a new supplier to the db - create a suppler id by adding 1 to max id
        /// </summary>
        /// <param name="sup"></param>
        /// <returns>message</returns>
        public static string AddSupplier(Supplier sup)
        {
            string message = "success";
            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                try
                {
                    //Insert into Supplier table                    
                    int maxSupId = context.Suppliers.Max(s => s.SupplierId);//get the maxium supplierid
                    maxSupId = maxSupId + 1; //adding one to the supplierid
                    sup.SupplierId = maxSupId; //set max+1 to supplierid
                    context.Suppliers.Add(sup); //Add supplier
                    context.SaveChanges();
                }
                catch (DbUpdateException exception)
                {
                    var sqlException = (SqlException)exception.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        if (error.Number == 2627)
                        { // Error message for primary key unique constraint violate.
                            message = "SupplierID Not Unique";
                            break;
                        }
                        else
                        {
                            message = message += "ERROR CODE:  " + error.Number + " " +
                                           error.Message + "\n";
                        }
                    }

                }
                catch (Exception ex)
                {

                    message = ex.Message + " " + ex.GetType().ToString();

                }
            }

            return message;
        }
        //----------------------------End Add Supplier-----------------------------------------------------------------
/// <summary>
/// update suppler name in teh suppler dtable
/// </summary>
/// <param name="supplier">supplier</param>
/// <returns>string message </returns>
        public static string updateSupplierName(Supplier supplier)
        {
            string message = "success";

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                try
                {
                    //Update product table
                    Supplier sOld = context.Suppliers.First(s => s.SupplierId == supplier.SupplierId);

                    sOld.SupName = supplier.SupName;
                    context.Update(sOld);
                    context.SaveChanges();

                }
                catch (DbUpdateException exception)
                {
                    var sqlException = (SqlException)exception.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        if (error.Number == 2627)
                        { // Error message for primary key unique constraint violate.
                            message = "SupplierID Not Unique";
                            break;
                        }
                        else
                        {
                            message = message += "ERROR CODE:  " + error.Number + " " +
                                           error.Message + "\n";
                        }
                    }

                }
                catch (Exception ex)
                {

                    message = ex.Message + " " + ex.GetType().ToString();

                }
                
            }
            return message;
        }

        }//end class
        
    }
