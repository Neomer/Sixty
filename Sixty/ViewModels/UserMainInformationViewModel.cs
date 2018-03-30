using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class UserMainInformationViewModel
    {
        public UserMainInformationViewModel()
        {

        }

        public UserMainInformationViewModel(User user)
        {
            PhotoPath = user.PhotoPath;
            Fullname = user.Name + ' ' + user.Surname;
            StatusMessage = user.StatusString;
            HasTeam = user.Team != null;
            if (HasTeam)
            {
                TeamName = user.Team.Name;
            }
            else
            {
                TeamName = TR.T("Нет команды");
            }
        }

        public string Fullname { get; set; }
        public string PhotoPath { get; set; }
        public string StatusMessage { get; set; }

        public bool HasTeam { get; set; }
        public string TeamName { get; set; }
    }
}