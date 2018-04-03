using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class TeamCreationViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Division> AvailableDivisions { get; set; }
        public string Error { get; set; }
    }
}