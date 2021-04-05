using System.ComponentModel.DataAnnotations;

namespace OnlineJewellShop.Entity
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public  Product Product { get; set; }
        public  OrderEntity Order { get; set; }


    }
}
