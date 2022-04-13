using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email is Required")]
        [EmailAddress(ErrorMessage="Invalid format email")]
        public string Email{get;set;}

        [Required(ErrorMessage="Password Required")]
        [StringLength(20,ErrorMessage="The {0} must be at least {2} and at max"+ "{1} characters long" , MinimumLength=10)]
        [DataType(DataType.Password)]
        public string Password{get;set;}


        public string ReturnUrl{get;set;}
    }
}