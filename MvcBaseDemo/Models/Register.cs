using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBaseDemo.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please input your name!")]
        [StringLength(10, MinimumLength = 4)]
        //[Display("User Name", Order=15000)]
        public string UserName { get; set; }

        
        [Range(0.01, 100.0, ErrorMessage = "this")]
        public decimal GetNum { get; set; }

        [Range(0.01, 100.0, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+[A-Za-z]{2,4}", ErrorMessage="Email is not valid")]
        public string Email { get; set; }


    }
}