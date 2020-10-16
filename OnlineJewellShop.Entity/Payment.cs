using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJewellShop.Entity
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [MaxLength(30)]
        [Required]
        public string CardHolderName { get; set; }
        [NotMapped]
        public long CardNumber { get; set; }
        [NotMapped]
        public int Cvv { get; set; }
        [MaxLength(5)]
        [NotMapped]
        public string ValidDate { get; set; }
        [Required]
        public decimal Total { get; set; }
        
    }
}
