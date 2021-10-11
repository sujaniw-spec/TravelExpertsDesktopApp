using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PackageManagement
{
/* TravelExpert Workshop 3
 * Purpose:Handle DB connections for Package management
 * Author: Sujani Wijesundera
 * 
 */

    public static class PackageManager
    {
        /// <summary>
        /// Get all the package in descending order by Release Date
        /// </summary>
        /// <returns>List<PackageDTO></returns>
        public static List<PackageDTO> GetPackages()
        {

            List<Package> packages      = null;
            List<PackageDTO>packageDTOs = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                packages = db.Packages.OrderByDescending(p => p.PkgStartDate).ToList(); // get data from db desc order by start date

                if (packages != null)
                {
                    packageDTOs = new List<PackageDTO>();
                    foreach (Package i in packages)
                        packageDTOs.Add(new PackageDTO
                        {
                            PackageId = i.PackageId,
                            PkgName   = i.PkgName,
                            PkgStartDate = i.PkgStartDate,
                            PkgEndDate   = i.PkgEndDate,
                            PkgDesc      = i.PkgDesc,
                            PkgBasePrice = i.PkgBasePrice,
                            PkgAgencyCommission = i.PkgAgencyCommission
                        }) ;
                }
            }
            return packageDTOs;

        }

        //-------------------------------------end of GetPackages-------------------------------------------------------------

        /// <summary>
        /// Get list of products from the products table
        /// </summary>
        /// <returns>List<ProductDTO></returns>
        public static List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                products = db.Products
                                    .Select(p => new ProductDTO
                                    {
                                        ProductId = p.ProductId,
                                        ProdName  = p.ProdName
                                    })
                                    .ToList();
            }

            return products;
        }

        //-----------------------------------end of GetProducts-------------------------------------------------------------

        /// <summary>
        /// Get List of suppliers form Supplier table
        /// </summary>
        /// <returns>List<SupplierDTO></returns>
        public static List<SupplierDTO> GetSuppliers()
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                suppliers = db.Suppliers
                        .Select(s => new SupplierDTO
                        {
                            SupplierId = s.SupplierId,
                            SupName    = s.SupName
                        })
                        .ToList();
            }

            return suppliers;
        }

        //------------------------------end of GetSuppliers-------------------------------------------------------------


        /// <summary>
        /// Get List of suppliers form Supplier table
        /// </summary>
        /// <returns>List<SupplierDTO></returns>
        public static List<Supplier> GetSuppliersByProductId(int prodcutId)
        {
           // List<SupplierDTO> suppliers = new List<SupplierDTO>();
            List<Supplier> suppliers1 = new List<Supplier>();
            List<ProductsSupplier> productsuppliers = new List<ProductsSupplier>();

            Supplier sup;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productsuppliers = db.ProductsSuppliers.Where(s => s.ProductId == prodcutId).ToList();
                int i = 0;
              
                while (i < productsuppliers.Count)
                {
                   // using (TravelExpertsContext db1 = new TravelExpertsContext())
                    //{
                       
                        sup = db.Suppliers.Find(productsuppliers[i].SupplierId);
                        suppliers1.Add(sup);
                    //}

                    i++;
                }
            }

            return suppliers1;
        }

        //------------------------------end of GetSuppliers-------------------------------------------------------------

        /// <summary>
        /// Addd travel packages to the database
        /// </summary>
        /// <param name="p">Instance of a Package object</param>
        /// <param name="ps">Instance of a ProductsSupplier object</param>
        
        public static string AddTravelPackage(Package p, ProductsSupplier ps)
        {  
            int packageId    = 0;
            int productSupId = 0;
            string message = "success";

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                try
                {
                    //Start database transaction since inserting in to 3 tables
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        //Insert into package table
                        context.Packages.Add(p);
                        context.SaveChanges();
                        //Get package Id from the newly added row
                        packageId = p.PackageId;
                        productSupId = GetProductSupplier(ps.ProductId,ps.SupplierId);

                        //Insert in to PackagesProductsSupplier table
                        PackagesProductsSupplier pps = new PackagesProductsSupplier();
                        pps.PackageId = packageId;
                        pps.ProductSupplierId = productSupId;
                        context.SaveChanges();

                        context.PackagesProductsSuppliers.Add(pps);
                        context.SaveChanges();

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

        //----------------------end of AddTravelPackage-------------------------------------------------------

        /// <summary>
        /// Update teh pacakge
        /// </summary>
        /// <param name="package">Pacakge object</param>
        /// <param name="ps">Instance of a ProductsSupplier object</param>
        /// <returns>flag - true or false</returns>
        public static string Modify(Package newPackage, ProductsSupplier ps)
        {
            string message   = "success";
            Package oldPacakge; //package already in the db
            int packageId    = 0;
            int productSupId = 0;

            try
            {
                //Start database transaction since inserting in to 2 tables
                using (TravelExpertsContext context = new TravelExpertsContext())
                {
                    try
                    {
                        //Start database transaction since inserting in to 3 tables
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            oldPacakge = context.Packages.Find(newPackage.PackageId);// find the object to modify
                            context.Entry(oldPacakge).CurrentValues.SetValues(newPackage);// set values to old product
                            context.SaveChanges();
                            packageId = newPackage.PackageId;
                            productSupId = GetProductSupplier(ps.ProductId, ps.SupplierId);

                            //Get package Id from the newly added row
                            //Insert in to PackagesProductsSupplier table
                            PackagesProductsSupplier ppsNew = new PackagesProductsSupplier();
                            ppsNew.PackageId = packageId;
                            ppsNew.ProductSupplierId = productSupId;

                            //Delete old PackagesProductsSupplier
                            PackagesProductsSupplier ppsOld = context.PackagesProductsSuppliers.First(p => p.PackageId == packageId);  //.Find(packageId);
                            context.Remove(ppsOld);
                            context.SaveChanges();

                            //Add new PackagesProductsSupplier
                            context.Add(ppsNew);
                            context.SaveChanges();

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
              
            }
            catch (Exception ex)
            {

                message = ex.Message + " " + ex.GetType().ToString();

            }
            return message;
    }

        //---------------------------------end of Modify-------------------------------------------------------------


        /// <summary>
        /// retrieves data of a package based on packageId
        /// </summary>
        /// <param name="packageId"> PackageId</param>
        /// <returns>package object or null if not found</returns>
        public static Package GetPackage(int packageId)
        {
            Package package = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                package = db.Packages.Find(packageId);
            }
            return package;
        }

      
        /// <summary>
        /// retrieves data of a package based on packageId
        /// </summary>
        /// <param name="packageId"> PackageId</param>
        /// <returns>package object or null if not found</returns>
        public static int GetProductSupplier(int? productId,int? supplierId)
        {
            ProductsSupplier productSupplier = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productSupplier= db.ProductsSuppliers.First(ps => ps.ProductId == productId && ps.SupplierId == supplierId);
            }
            return productSupplier.ProductSupplierId;
        }

        //-------------------------------------end of GetPackage-------------------------------------------------------------

        /// <summary>
        /// retrieves data of a package_product_suppliers based on packageId
        /// </summary>
        /// <param name="packageId"> PackageId</param>
        /// <returns>pkgProductSupplier</returns>
        public static PackagesProductsSupplier GetProductSupplierId(int packageId)
        {
            PackagesProductsSupplier pkgProductSupplier = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                pkgProductSupplier = db.PackagesProductsSuppliers.First(p =>p.PackageId == packageId);
            }
            return pkgProductSupplier;
        }

        //---------------------------------end of PackagesProductsSupplier-------------------------------------------------------------

        /// <summary>
        /// retrieves data of a package_product_suppliers based on packageId
        /// </summary>
        /// <param name="productSupplierId"> productSupplierId</param>
        /// <returns>productId</returns>
        public static int GetProductIdFromproductSuppliers(int? productSupplierId)
        {
            ProductsSupplier productSupplier = null;
            int? productId = 0;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productSupplier = db.ProductsSuppliers.Find(productSupplierId);
            }
            productId = productSupplier.ProductId;
            return (int)productId;
        }

        //------------------------------------end of GetProductSupplierId-------------------------------------------------------------

        /// <summary>
        /// retrieves data of a package_product_suppliers based on packageId
        /// </summary>
        /// <param name="productSupplierId"> productSupplierId</param>
        /// <returns>supplierId</returns>
        public static int GetSupplierIdFromproductSuppliers(int? productSupplierId)
        {
            ProductsSupplier productSupplier = null;
            int? supplierId = 0;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productSupplier = db.ProductsSuppliers.Find(productSupplierId);
            }
            supplierId = productSupplier.SupplierId;
            return (int)supplierId;
        }

        //-----------------------------------end of GetSupplierIdFromproductSuppliers-------------------------------------------------------------

    } // end of class
}
