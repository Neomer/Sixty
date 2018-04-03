using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sixty.Models;

namespace Sixty.ViewModels
{
    public interface IEntityEdittingViewModel
    {
        Guid? Id { get; set; }
        bool IsNew { get; set; }

        string Error { get; set; } 

        void LoadEntity(IEntity entity);
        void FillEntity(ref IEntity entity);
    }
}
