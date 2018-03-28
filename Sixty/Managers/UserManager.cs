using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;

namespace Sixty.Managers
{
    public class UserManager : BaseManager<User>, IManager
    {
        public void JoinTeam(User user, Team team)
        {
            user.Team = team;
            CreateEntity(user);
        }

        public User GetByEmailPassword(string email, string password)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<User>()
                .Add(Restrictions.Eq("Email", email))
                .Add(Restrictions.Eq("Password", password))
                .UniqueResult<User>();
        }
    }
}