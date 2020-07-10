using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.BL
{
    public interface IProductCategoryBL
    {
        void AddProductCategory(ProductCatogeries productCatogeries);
        void UpdateProductCategory(ProductCatogeries product);
        void DeleteProductCategory(ProductCatogeries product);
        IEnumerable<ProductCatogeries> DisplayProduct();
        ProductCatogeries GetProduct(int id);



    }
    public class ProductCategoryBL: IProductCategoryBL
    {
        IProductCategoryRepositary productCategoryRepositary;
        public ProductCategoryBL()
        {
            productCategoryRepositary = new ProductCategoryRepositary();
        }
        public IEnumerable<ProductCatogeries> DisplayProduct()
        {
            return productCategoryRepositary.DisplayProduct();
        }
        public void AddProductCategory(ProductCatogeries productCatogeries)
        {
            productCategoryRepositary.AddProductCategory(productCatogeries);
        }
        public ProductCatogeries GetProduct(int id)
        {
            return productCategoryRepositary.GetProduct(id);
        }
        
        
        public void UpdateProductCategory(ProductCatogeries product)
        {
            productCategoryRepositary.UpdateProductCategory(product);
        }
        public void DeleteProductCategory(ProductCatogeries product)
        {
            productCategoryRepositary.DeleteProductCategories(product);
        }

    }
}
