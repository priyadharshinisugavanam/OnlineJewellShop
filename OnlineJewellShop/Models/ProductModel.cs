using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class ProductModel
    {
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductRate { get; set; }

        public ProductModel(int productNumber, string productName, int productRate)
        {
            this.ProductNumber = productNumber;
            this.ProductName = productName;
            this.ProductRate = productRate;
        }

        public ProductModel()
        {
        }

    }
}