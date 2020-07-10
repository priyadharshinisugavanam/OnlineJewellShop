
using OnlineJewellShop.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineJewellShop.DAL
{
    public interface IProductCategoryRepositary
    {
        void AddProductCategory(ProductCatogeries productCategories);
        ProductCatogeries GetProduct(int productNumber);
        void DeleteProductCategories(ProductCatogeries product);
        void UpdateProductCategory(ProductCatogeries product);
        IEnumerable<ProductCatogeries> DisplayProduct();
    }



        public class ProductCategoryRepositary:IProductCategoryRepositary
        {


        //    public List<ProductCatogeries> List()
        //    {
        //        using (DbConnect dbConnect = new DbConnect())
        //        {
        //            return dbConnect.ProductCategoryData.ToList();
        //        }
        //   }
       
            //Add product category
        public void AddProductCategory(ProductCatogeries productCategories)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                dbConnect.ProductCategoryData.Add(productCategories);
                dbConnect.SaveChanges();
            }
        }
        public IEnumerable<ProductCatogeries> DisplayProduct()
        {
            using (DbConnect dbConnect = new DbConnect())
            {

                List<ProductCatogeries> products = dbConnect.ProductCategoryData.ToList();
                return products;
            }
        }
       
        
        //get productcategory using productcategory id
        public ProductCatogeries GetProduct(int productNumber)
        {
            using (DbConnect dbConnect = new DbConnect())
            {
                List<Product> products = dbConnect.ProductData.ToList();
                ProductCatogeries product = dbConnect.ProductCategoryData.Where(id => id.ProductCatogeryId == productNumber).SingleOrDefault();
                return product;
            }
        }
        //update category using object
        public void UpdateProductCategory(ProductCatogeries product)
        {
            using (DbConnect productConnect = new DbConnect())
            {
                productConnect.Entry(product).State = EntityState.Modified;
                productConnect.SaveChanges();
            }
        }
        //delete category using object
        public void DeleteProductCategories(ProductCatogeries product)
        {
            using (DbConnect productConnect = new DbConnect())
            {
                ProductCatogeries products = productConnect.ProductCategoryData.Where(id => id.ProductCatogeryId == product.ProductCatogeryId).SingleOrDefault();
                productConnect.ProductCategoryData.Attach(products);
                productConnect.ProductCategoryData.Remove(products);
                productConnect.SaveChanges();
            }
        }
    }
}
