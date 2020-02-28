using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OnlineJewellShop.Entity
{
    public enum RoleOfMembers
    {
        User,
        Admin
    }
    public class UserDetails
    {
        [Required]

        [Key]
        public string userID { get; set; }
        [Required]
        //[DataType(DataType.Password,ErrorMessage ="invalid")]
        //[RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$",ErrorMessage ="Invalid Password")]
        public string password { get; set; }
        [Required]
        public string conformPassword { get; set; }
        [Required]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Inval  id Mail Id")]
        public string mailId { get; set; }
        //[Required]
       
        public string Role
        {
            get;set;
        }

            [Required]
            //[DataType(DataType.PhoneNumber)]
            // [RegularExpression(@"^[6789]\d{9}$",ErrorMessage ="invalid phone number")]
            public long phoneNumber { get; set; }
        public UserDetails(string userID, string password, long phoneNumber, string mailId)
        {
            this.userID = userID;
            this.password = password;
            this.mailId = mailId;
            this.phoneNumber = phoneNumber;

        }
        public UserDetails(string userID, string password)
        {
            this.userID = userID;
            this.password = password;

        }
        public UserDetails(string userID)
        {
            this.userID = userID;
        }
        public UserDetails()
        {

        }
    }
   
}




