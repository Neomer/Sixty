using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Models
{
    public class Division : IEntity
    {
        #region IEntity interface
        public virtual Guid Id { get; set; }
        #endregion

        public virtual string Name { get; set; }
        public virtual Season CurrentSeason { get; set; }
    }
}