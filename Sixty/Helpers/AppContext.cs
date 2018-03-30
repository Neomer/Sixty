using Sixty.Managers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Sixty.Helpers
{
    public class AppContext
    {
        #region Singleton
        private static AppContext _instance;
        public static AppContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppContext();
                }
                return _instance;
            }
        }
        #endregion

        private User _currentUser;

        public User CurrentUser(IIdentity identity)
        {
            if (!identity.IsAuthenticated)
            {
                return null;
            }

            if (_currentUser == null)
            {
                var manager = ManagerProvider.Instance.Get<User>();
                if (manager == null)
                {
                    throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "User"));
                }
                Guid id;
                if (!Guid.TryParse(identity.Name, out id))
                {
                    throw new Exception(TR.T("Неверный формат данных! Получено '%1' ожидается %2", identity.Name, "Guid"));
                }
                _currentUser = manager.GetById(id) as User;
                if (_currentUser == null)
                {
                    throw new Exception(TR.T("Пользователь с идентификатором %1 не зарегистрирован в системе!", identity.Name));
                }
            }
            return _currentUser;
        }

    }
}