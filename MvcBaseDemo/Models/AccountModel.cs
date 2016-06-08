using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBaseDemo.Models
{
    public class AccountModel
    {
        
    }

    public class RegisterModel
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "querenmima")]
        [Compare("Password", ErrorMessage = "ConfirmPassword is Inconsistent")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Agree")]
        public bool IsAgree { get; set; }
    }
}