using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.DAL
{
    public class ProductConnect : DbContext
    {
        public DbSet<Product> ProductData { get; set; }
        public ProductConnect() : base("DBConnection")
        {

        }

    }

    public class ProductRepositary
    {
        
       
        public List<Product> List()
            {
            using (ProductConnect dbConnect = new ProductConnect())
            {
                return dbConnect.ProductData.ToList();
            }
            }
            public void AddProduct(Product product)
            {
            using (ProductConnect dbConnect = new ProductConnect())
            {
                dbConnect.ProductData.Add(product);
                dbConnect.SaveChanges();
            }
            }
        public IEnumerable<Product> DisplayProduct()
        {
            using (ProductConnect dbConnect = new ProductConnect())
            {
                List<Product> products = dbConnect.ProductData.ToList();
                return products;
            }
        }
        public Product GetProduct(int productNumber)
        {
            using (ProductConnect dbConnect = new ProductConnect())
            {
                List<Product> products = dbConnect.ProductData.ToList();
                Product product = dbConnect.ProductData.Where(id => id.ProductNumber == productNumber).SingleOrDefault();
                return product;
            }
        }
        public void UpdateProduct(Product product)
        {
            using (ProductConnect productConnect = new ProductConnect())
            {
                productConnect.Entry(product).State = EntityState.Modified;
                productConnect.SaveChanges();
            }
        }
        public void DeleteProduct(Product product)
        {
            using (ProductConnect productConnect = new ProductConnect())
            {
                Product products = productConnect.ProductData.Where(id => id.ProductNumber == product.ProductNumber).SingleOrDefault();
                productConnect.ProductData.Attach(products);
                productConnect.ProductData.Remove(products);
                productConnect.SaveChanges();
            }
        }
        
    }
}
