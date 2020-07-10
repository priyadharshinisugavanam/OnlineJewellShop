using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
