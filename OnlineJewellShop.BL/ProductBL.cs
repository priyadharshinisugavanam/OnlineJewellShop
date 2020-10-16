using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.BL
{
    public interface IProductBL
    {
        void AddProduct(Product product);
        //void AddPaymentDB(Payment payment);
        IEnumerable<Product> DisplayProduct();
        void UpdateProduct(Product product);
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
        public void AddProduct(Product product)
        {
            repositary.AddProduct(product);
        }
        public IEnumerable<Product> DisplayProduct()
        {

            return repositary.DisplayProduct();
        }
        
        public void UpdateProduct(Product product)
        {
            repositary.UpdateProduct(product);
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
