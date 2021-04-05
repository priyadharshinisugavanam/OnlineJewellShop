using OnlineJewellShop.Entity;                                                                                                                                                                                                                                                                                                                                                                                    
using System;    
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class ProductModel
    {
     
        public int ProductId { get; set; }
        [Required]
        public int ProductCatogeryId { get; set; }
        public ProductCatogeries ProductCatogeries { get; set; }
        [Required]
        
        public string ProductName { get; set; }
        [Required]
        [RegularExpression(@"^\s*-?[1-9]\d*(\.\d{1,2})?\s*$", ErrorMessage = "The Product rate should be greater than 0 with only 2 numbers after decimal point")]
        public float ProductRate { get; set; }
        public string ProductImagePath { get; set; }
        
        [Required]
        public HttpPostedFileBase ImageUpload { get; set; }
        
    }
}