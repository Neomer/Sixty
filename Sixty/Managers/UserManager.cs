using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Managers
{
    public class UserManager : BaseManager<User>, IManager
    {
        public void JoinTeam(User user, Team team)
        {
            user.Team = team;
            CreateEntity(user);
        }
    }
}