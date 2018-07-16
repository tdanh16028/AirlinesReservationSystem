using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARSWebMVC.Models
{
    public class LoginModels
    {
        [Required]
        [Display(Name = "UserName")]
        [MaxLength(16, ErrorMessage = "UserName must be less than 16 characters")]
        [MinLength(6, ErrorMessage = "UserName must be at least 6 characters long")]
        public string UserID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(32, ErrorMessage = "Password must be less than 32 characters")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}