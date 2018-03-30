using NHibernate.Criterion;
using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Managers
{
    public class DivisionManager : BaseManager<Division>, IManager
    {
        public IEnumerable<Division> GetAvailableForNewbee()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<Division>()
                .Add(Restrictions.Eq("AvailableForNewbee", true))
                .List<Division>();
        }
    }
}