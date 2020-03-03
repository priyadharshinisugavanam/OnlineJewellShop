using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OnlineJewellShop.Entity
{
    
    public class UserDetails
    {
        //public enum RoleOfMembers
        //{
        //    User,
        //    Admin
        //}
        [Required]

        [Key]
        public string UserID { get; set; }
        [Required]
        //[DataType(DataType.Password,ErrorMessage ="invalid")]
        //[RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$",ErrorMessage ="Invalid Password")]
        public string Password { get; set; }
        [Required]
        public string ConformPassword { get; set; }
        [Required]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Inval  id Mail Id")]
        public string MailId { get; set; }
        //[Required]
       
        public string Role
        {
            get;set;
        }

            [Required]
            //[DataType(DataType.PhoneNumber)]
            // [RegularExpression(@"^[6789]\d{9}$",ErrorMessage ="invalid phone number")]
            public long phoneNumber { get; set; }
       
        public UserDetails()
        {

        }
    }
   
}




