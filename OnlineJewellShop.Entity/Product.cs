using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.Entity
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductNumber { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductRate { get; set; }

        public Product(int productNumber, string productName, int productRate)
        {
            this.ProductNumber = productNumber;
            this.ProductName = productName;
            this.ProductRate = productRate;
        }

        public Product()
        {
        }

    }
}
