using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBaseDemo.Areas.PC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please input UserName")]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please input password")]
        [DisplayName("Password")]
        public string LoginPassword { get; set; }
    }
}