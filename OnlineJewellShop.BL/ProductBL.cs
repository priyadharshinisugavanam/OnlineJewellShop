using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System.Collections.Generic;
namespace OnlineJewellShop.BL
{
    public interface IProductBL
    {
        int AddProduct(Product product);
        //void AddPaymentDB(Payment payment);
        IEnumerable<Product> DisplayProduct();
        int UpdateProduct(Product product);
        Product GetProduct(int id);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetProductCategory(int productNumber);

    }
    
    public class ProductBL:IProductBL
    {
        //creating object for IProductRepositary interface
        IProductRepositary repositary;
        public ProductBL()
        {
            repositary = new ProductRepositary();
        }
        public int AddProduct(Product product)
        {
            return repositary.AddProduct(product);
        }
        public IEnumerable<Product> DisplayProduct()
        {

            return repositary.DisplayProduct();
        }
        
        public int UpdateProduct(Product product)
        {
             return repositary.UpdateProduct(product);
        }
        public void DeleteProduct(Product product)
        {
            repositary.DeleteProduct(product);
        }
        public Product GetProduct(int id)
        {
            return repositary.GetProduct(id);
        }
        public IEnumerable<Product> GetProductCategory(int productNumber)
        {
            return repositary.GetProductCategory(productNumber);
        }
        //public void AddPaymentDB(Payment payment)
        //{
        //    repositary.AddPaymentDB(payment);
        //}

    }
}
