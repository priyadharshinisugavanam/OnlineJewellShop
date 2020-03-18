using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.Entity
{
    public class ProductCatogeries
    {
        [Key]
        public int ProductCatogeryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string productCatogeryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
