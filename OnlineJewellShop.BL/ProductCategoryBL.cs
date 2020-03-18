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
        IEnumerable<ProductCatogeries> GetProductCatogeries();
        void UpdateProductCategory(ProductCatogeries product);
        void DeleteProductCategory(ProductCatogeries product);

        ProductCatogeries GetProduct(int id);



    }
    public class ProductCategoryBL: IProductCategoryBL
    {
        IProductCategoryRepositary productCategoryRepositary;
        public ProductCategoryBL()
        {
            productCategoryRepositary = new ProductCategoryRepositary();
        }
        public void AddProductCategory(ProductCatogeries productCatogeries)
        {
            productCategoryRepositary.AddProductCategory(productCatogeries);
        }
        public ProductCatogeries GetProduct(int id)
        {
            return productCategoryRepositary.GetProduct(id);
        }
        
        public IEnumerable<ProductCatogeries> GetProductCatogeries()
        {
            return productCategoryRepositary.GetProductCatogeries();
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
