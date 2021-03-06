﻿using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineJewellShop.DAL
{
    public interface IProductRepositary
    {
        int AddProduct(Product product);
        //void AddPaymentDB(Payment payment);
        IEnumerable<Product> DisplayProduct();
        IEnumerable<Product> GetProductCategory(int productNumber);
        Product GetProduct(int productNumber);
        int UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
    public class ProductRepositary:IProductRepositary
    {
        //public List<Product> List()
        //{
        //    using (DbConnect dbConnect = new DbConnect())
        //    {
        //        return dbConnect.ProductData.ToList();
        //    }
        //}
        //Adding the product in db
            public int AddProduct(Product product)
            {
            using (DbConnect dbConnect = new DbConnect())
            {
                //using (var transaction = dbConnect.Database.BeginTransaction())
                //{
                //    try {
                //        SqlParameter ProductName = new SqlParameter("@ProductName", product.ProductName);
                //        SqlParameter ProductRate = new SqlParameter("@ProductRate", product.ProductRate);
                //        SqlParameter Prod = new SqlParameter("@ProductCatogeryId", product.ProductCatogeryId);
                //        var result = dbConnect.Database.ExecuteSqlCommand("[dbo].[Product_Insert] @ProductCatogeryId, @ProductName, @ProductRate", Prod, ProductRate, ProductName);
                //        transaction.Commit();}
                //catch (Exception)
                //{
                //    transaction.Rollback();
                //}}
                dbConnect.ProductData.Add(product);
                
                return dbConnect.SaveChanges();
            }
        }
        //displays product
        public IEnumerable<Product> DisplayProduct()
        {
            using (DbConnect dbConnect = new DbConnect())
            {

                List<Product> products = dbConnect.ProductData.Include("ProductCatogeries").ToList();
                return products;
            }
        }
        //Getting productCategory using productcategoryid
        public IEnumerable<Product> GetProductCategory(int productNumber)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                List<Product> result = dbConnect.ProductData.
                              Where(x=>x.ProductCatogeryId == productNumber).ToList() ;
                return result;
            }
        }
        
        //Getting product using productid
        public Product GetProduct(int productNumber)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                Product product = dbConnect.ProductData.Include("ProductCatogeries").Where(id => id.ProductId == productNumber).SingleOrDefault();
                return product;
            }
        }
        //update product with productid
        public int UpdateProduct(Product product)
        {
            using (DbConnect productConnect = new DbConnect())
            {
                productConnect.Entry(product).State = EntityState.Modified;
                
                return productConnect.SaveChanges();
            }
        }

        
        //delete product with object
        public void DeleteProduct(Product product)
        {
            using (DbConnect productConnect = new DbConnect())
            { 
                using (var transaction = productConnect.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter ProductId = new SqlParameter("@ProductId", product.ProductId);
                        var result = productConnect.Database.ExecuteSqlCommand("Product_Delete @ProductId", ProductId);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                //Product products = productConnect.ProductData.Where(id => id.ProductId == product.ProductId).SingleOrDefault();
                //productConnect.ProductData.Attach(products);
                //productConnect.ProductData.Remove(products);
                //productConnect.SaveChanges();
            }
        }
        //public void AddPaymentDB(Payment payment)
        //{
        //    using (DbConnect dbConnect = new DbConnect())
        //    {
                
        //            dbConnect.Data.Add(payment);
        //            dbConnect.SaveChanges();
               
        //    }
        //}

    }
}
