﻿using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class TeamInfoViewModel
    {
        public TeamInfoViewModel()
        {

        }

        public TeamInfoViewModel(Team model)
        {
            if (model == null)
            {
                return;
            }
            Name = model.Name;
        }

        public string Name { get; set; }
        public string DivisionName { get; set; }
    }
}