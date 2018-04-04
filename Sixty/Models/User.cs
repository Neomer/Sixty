using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Models
{
    public class User : IEntity
    {
        #region IEntity interface
        public virtual Guid Id { get; set; }
        #endregion

        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? BirthDate { get; set; }

        public virtual DateTime RegistrationDate { get; set; }
        public virtual DateTime? LastVisitDate { get; set; }

        public virtual Team Team { get; set; }

        public virtual string StatusString { get; set; }
        public virtual string PhotoPath { get; set; }
        public virtual string PhotoPreviewPath { get; set; }

        public virtual string Phone { get; set; }
        public virtual bool IsAdmin { get; set; }
    }
}