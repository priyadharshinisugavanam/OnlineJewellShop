using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class ProductCatogeryModel
    {
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid")]
        public string ProductCatogeryId { get; set; }
        [Required]
        public string productCatogeryName { get; set; }
        public string ProductImagePath { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public ProductCatogeryModel()
        {

        }
    }
}