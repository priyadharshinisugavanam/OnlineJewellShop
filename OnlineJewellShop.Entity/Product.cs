using System.ComponentModel.DataAnnotations;
namespace OnlineJewellShop.Entity
{
    public class Product
    {
        [Key]

        public int ProductId { get; set; }
        public int ProductCatogeryId { get; set; }
        public ProductCatogeries ProductCatogeries { get; set;}
        [Required]
        [MaxLength(25)]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductRate { get; set; }
        public string ProductImagePath { get; set; }
        
        

    }
}
