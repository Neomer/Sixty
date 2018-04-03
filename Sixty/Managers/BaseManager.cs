using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Managers
{
    public class BaseManager<T> : IManager
        where T : class, IEntity
    {
        public System.Type EntityType
        {
            get
            {
                return typeof(T);
            }
        }

        public virtual void CreateEntity(IEntity entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("NHiberante session failed!");
            }
            using (var tr = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public virtual void DeleteEntity(IEntity entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("NHiberante session failed!");
            }
            using (var tr = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public virtual IEnumerable<IEntity> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<T>().List<T>();
        }

        public virtual IEntity GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<T>(id);
        }

        public virtual IEnumerable<IEntity> GetLimit(int limit)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveEntity(IEntity entity)
        {
            NHibernateHelper.Instance.GetCurrentSession().Save(entity);
        }

        public virtual void UpdateEntity(IEntity entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("NHiberante session failed!");
            }
            using (var tr = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }
    }
}