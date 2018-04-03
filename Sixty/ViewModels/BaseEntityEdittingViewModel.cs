using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.ViewModels
{
    public class BaseEntityEdittingViewModel<T> : IEntityEdittingViewModel
        where T : class, IEntity
    {
        #region IEntityEdittingViewModel
        public Guid? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                _isNew = value;
            }
        }

        public string Error { get; set; }
        #endregion

        private Guid? _id = null;
        private bool _isNew = true;

        public virtual void LoadEntity(IEntity entity)
        {
            if (entity == null)
            {
                _isNew = true;
                _id = null;
            }
            else
            {
                _id = entity.Id;
                _isNew = false;
            }
        }

        public virtual void FillEntity(ref IEntity entity)
        {
            //entity.Id = _id ?? Guid.Empty;
        }
    }
}