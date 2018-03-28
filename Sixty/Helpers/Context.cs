using Sixty.Managers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Helpers
{
    public class Context
    {
        #region Singleton
        private static Context _instance;
        public static Context Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Context();
                }
                return _instance;
            }
        }
        #endregion

        private User _currentUser;

        public User CurrentUser(Guid? id = null)
        {
            if (_currentUser == null)
            {
                if (id == null)
                {
                    throw new Exception(TR.T("Пользователь не авторизован!"));
                }
                var manager = ManagerProvider.Instance.Get<User>();
                if (manager == null)
                {
                    throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "User"));
                }
                _currentUser = manager.GetById((Guid)id) as User;
                if (_currentUser == null)
                {
                    throw new Exception(TR.T("Пользователь с идентификатором %1 не зарегистрирован в системе!", id.ToString()));
                }
            }
            return _currentUser;
        }

    }
}