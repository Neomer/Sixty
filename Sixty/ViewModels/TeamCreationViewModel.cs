﻿using Sixty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class TeamCreationViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название команды")]
        public string Name { get; set; }
        [Display(Name = "Логотоип")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Logo { get; set; }


        public IEnumerable<Division> AvailableDivisions { get; set; }
        public string Error { get; set; }
    }
}
