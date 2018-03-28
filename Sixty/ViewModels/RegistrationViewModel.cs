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
        public string PasswordRetype { get; set; }
    }
}