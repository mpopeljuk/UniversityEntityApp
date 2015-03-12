﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityWeb.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}