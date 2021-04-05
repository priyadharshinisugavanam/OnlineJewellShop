using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public enum RoleOfMembers
    {
        User,
        Admin
    } 
    public class UserEntityModel
    {
            [Required]
            public string UserID { get; set; }
            [Required]
            [DataType(DataType.Password,ErrorMessage ="invalid")]
            [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$",ErrorMessage ="password should be 'more than 8 char' 'atleast 1 captial' 'atleast 1 number' 'atleast special character' ")]
            public string Password { get; set; }
            [Required]
            public string ConformPassword { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Invalid Mail Id")]
            public string MailId { get; set; }
            [Required]
            public string Role
            {
                get
                {
                    return RoleOfMembers.User.ToString();
                }
                set
                {
                    value = RoleOfMembers.User.ToString();
                }
            }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^[6789]\d{9}$",ErrorMessage ="invalid phone number")]
            public long PhoneNumber { get; set; }
            public UserEntityModel(string userID, string password, long phoneNumber, string mailId)
            {
                this.UserID = userID;
                this.Password = password;
                this.MailId = mailId;
                this.PhoneNumber = phoneNumber;

            }
            
            public UserEntityModel()
            {

            }
        }
        
    }



