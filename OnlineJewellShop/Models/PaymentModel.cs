using OnlineJewellShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
           
       
        
        public string CardHolderName { get; set; }

        
        public long CardNumber { get; set; }

        public int Cvv { get; set; }
        public string ValidDate { get; set; }
        public decimal Total { get; set; }
        
    }
}