﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewellShop.Models
{
    public class LoginModel
    {
            [Required]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Mail Id")]
            public string MailId { get; set; }
            [Required]
            [DataType(DataType.Password, ErrorMessage = "invalid")]
            [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$", ErrorMessage = "Invalid Password")]
            public string Password { get; set; }
            public string Role { get; set; }

        }
    }
