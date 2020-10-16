using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OnlineJewellShop.Entity
{
    
    public class User
    {
       
        [Required]
        [MaxLength(25)]
        [Key]
        public string UserID { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        [NotMapped]
        public string ConformPassword { get; set; }
        [Required]
        [MaxLength(45)]
        [Index(IsUnique =true)]
        public string MailId { get; set; }
        [MaxLength(5)]
        public string Role
        {
            get;set;
        }

            [Required]
            
            public long PhoneNumber { get; set; }
       
        
    }
   
}




