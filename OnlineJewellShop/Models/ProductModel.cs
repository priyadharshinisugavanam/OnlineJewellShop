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
        [RegularExpression(@"^[0-9]*$",ErrorMessage ="Invalid")]
        public int ProductRate { get; set; }
        //public string ImagePath { get; set; }

        //public HttpPostedFileBase ImageFile { get; set; }
        public ProductModel()
        {
        }

    }
}