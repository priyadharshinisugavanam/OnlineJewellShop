using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using System.Collections.Generic;
namespace OnlineJewellShop.BL
{
    public interface IProductCategoryBL
    {
        int AddProductCategory(ProductCatogeries productCatogeries);
        int UpdateProductCategory(ProductCatogeries product);
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
        public int AddProductCategory(ProductCatogeries productCatogeries)
        {
            return productCategoryRepositary.AddProductCategory(productCatogeries);
        }
        public ProductCatogeries GetProduct(int id)
        {
            return productCategoryRepositary.GetProduct(id);
        }
        
        
        public int UpdateProductCategory(ProductCatogeries product)
        {
           return productCategoryRepositary.UpdateProductCategory(product);
        }
        public void DeleteProductCategory(ProductCatogeries product)
        {
            productCategoryRepositary.DeleteProductCategories(product);
        }

    }
}
