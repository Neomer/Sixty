using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Models
{
    public class Season : IEntity
    {
        #region IEntity interface
        public virtual Guid Id { get; set; }
        #endregion

        public virtual string Name { get; set; }

        public virtual DateTime? BeginDate { get; set; }
        public virtual DateTime? EndDate { get; set; }

        public virtual bool IsOver { get; set; }
    }
}