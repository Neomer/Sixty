using Sixty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {

        }
        public SignInViewModel(User user)
        {

        }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}