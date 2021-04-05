using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class ProductCatogeryModel
    {
        
        public string ProductCatogeryId { get; set; }
        [Required]
        public string productCatogeryName { get; set; }

        public string ProductImagePath { get; set; }
     
        [Required]
        public HttpPostedFileBase ImageUpload { get; set; }
        public ProductCatogeryModel()
        {

        }
    }
}