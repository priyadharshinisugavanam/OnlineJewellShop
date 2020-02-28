using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class LoginModel
    {
            [Required]
            public string userID { get; set; }
            [Required]
            [DataType(DataType.Password, ErrorMessage = "invalid")]
            [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$", ErrorMessage = "Invalid Password")]
            public string password { get; set; }
            public string Role { get; set; }

        }
    }
