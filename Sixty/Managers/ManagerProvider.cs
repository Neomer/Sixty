using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Managers
{
    public class ManagerProvider
    {
        #region Singleton
        private static ManagerProvider _instance;
        public static ManagerProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerProvider();
                }
                return _instance;
            }
        }
        #endregion

        private IList<IManager> _managers;
        private ManagerProvider()
        {
            _managers = new List<IManager>();
        }

        /// <summary>
        /// Регистрирует менеджер сущности в системе
        /// </summary>
        public void Register(IManager manager)
        {
            _managers.Add(manager);
        }
        /// <summary>
        /// Возвращает менеджер для сущностей указанного типа
        /// </summary>
        public IManager Get<T>() where T : class, IEntity
        {
            foreach (var m in _managers)
            {
                if (m.EntityType == typeof(T))
                {
                    return m;
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает менеджер указанного типа
        /// </summary>
        public IManager Get(Type type)
        {
            foreach (var m in _managers)
            {
                if (m.GetType() == type)
                {
                    return m;
                }
            }
            return null;
        }
    }
}