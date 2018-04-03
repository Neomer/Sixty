using Sixty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class SeasonEdittingViewModel : BaseEntityEdittingViewModel<Season>
    {
        public SeasonEdittingViewModel() : base()
        {
        }

        public SeasonEdittingViewModel(Season model)
        {
            LoadEntity(model);
        }

        public override void LoadEntity(IEntity entity)
        {
            base.LoadEntity(entity);
            if (entity != null)
            {
                var typed = entity as Season;
                Name = typed.Name;
                BeginDate = typed.BeginDate;
            }
        }

        public override void FillEntity(ref IEntity entity)
        {
            base.FillEntity(ref entity);
            var typed = entity as Season;
            typed.Name = Name;
            typed.BeginDate = BeginDate;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата начала")]
        public Nullable<System.DateTime> BeginDate { get; set; }

    }
}