using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Sixty.Models;

namespace Sixty.Helpers
{
    public sealed class NHibernateHelper
    {
        #region Singleton
        private static NHibernateHelper _instance;
        public static NHibernateHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NHibernateHelper();
                }
                return _instance;
            }
        }
        #endregion

        private ISessionFactory _sessionFactory = null;
        private ISession _session = null;

        private NHibernateHelper()
        {
        }

        public void Initialize(string appPath)
        {
            var configuration = new Configuration();
            var configurePath = appPath + "\\nhibernate.cfg.xml";
            configuration.Configure(configurePath);
            try
            {
                configuration.AddAssembly(typeof(User).Assembly);
            }
            catch (MappingException ex)
            {
                throw ex;
            }
            new SchemaUpdate(configuration).Execute(true, true);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            if (_sessionFactory != null)
            {
                return _sessionFactory.OpenSession();
            }
            else
            {
                throw new Exception("Фабрика сущностей не инициализирована!");
            }
        }

        public ISession GetCurrentSession()
        {
            if (_session == null)
            {
                try
                {
                    _session = _sessionFactory.GetCurrentSession();
                    if (_session == null)
                    {
                        _session = OpenSession();
                    }
                }
                catch (Exception)
                {
                    _session = OpenSession();
                }

            }
            return _session;
        }

        public ITransaction BeginTransaction()
        {
            return GetCurrentSession().BeginTransaction();
        }

        public void Commit(ITransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void Rollback(ITransaction transaction)
        {
            transaction.Rollback();
        }
    }
}