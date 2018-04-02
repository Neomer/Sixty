using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class DivisionCreationViewModel
    {
        public DivisionCreationViewModel()
        {

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