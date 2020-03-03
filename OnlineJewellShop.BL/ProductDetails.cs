using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.BL
{
    public class ProductDetails
    {
        ProductRepositary repositary = new ProductRepositary();
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
    }
}
