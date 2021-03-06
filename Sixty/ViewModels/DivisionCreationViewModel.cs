﻿using Sixty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class DivisionCreationViewModel : BaseEntityEdittingViewModel<Division>
    {
        public DivisionCreationViewModel() : base()
        {
        }

        public DivisionCreationViewModel(Division model)
        {
            LoadEntity(model);
        }

        public override void LoadEntity(IEntity entity)
        {
            base.LoadEntity(entity);
            if (entity != null)
            {
                var typed = entity as Division;
                Name = typed.Name;
                AvailableForNewbee = typed.AvailableForNewbee;
            }
        }

        public override void FillEntity(ref IEntity entity)
        {
            base.FillEntity(ref entity);
            var typed = entity as Division;
            typed.Name = Name;
            typed.AvailableForNewbee = AvailableForNewbee;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Доступен для новых команд")]
        public bool AvailableForNewbee { get; set; }
    }
}