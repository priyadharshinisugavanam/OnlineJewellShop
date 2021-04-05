using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineJewellShop.Entity
{
    public class ProductCatogeries
    {
        [Key]
        public int ProductCatogeryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string productCatogeryName { get; set; }
        public string ProductImagePath { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
