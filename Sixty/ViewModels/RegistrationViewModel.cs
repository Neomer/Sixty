using Sixty.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class RegistrationViewModel : SignInViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string PasswordRetype { get; set; }
    }
}