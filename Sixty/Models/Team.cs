﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Models
{
    public class Team : IEntity
    {
        #region IEntity interface
        public virtual Guid Id { get; set; }
        #endregion

        public virtual string Name { get; set; }
        public virtual Division Division { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Game> Games { get; set; }
    }

    public enum TeamDivision
    {
        A,
        B
    }
}