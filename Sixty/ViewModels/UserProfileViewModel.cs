using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            BirthDate = user.BirthDate;
            EMail = user.Email;
        }

        public string EMail { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public HttpPostedFileBase Photo { get; set; }
    }
}