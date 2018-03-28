using Sixty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {

        }

        public UserProfileViewModel(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            BirthDate = user.BirthDate;
            Email = user.Email;
        }

        [Display(Name = "Эл. почта")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [Display(Name = "Фотография")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Photo { get; set; }
    }
}