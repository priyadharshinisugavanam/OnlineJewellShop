using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OnlineJewellShop.Entity
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}