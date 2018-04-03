using NHibernate.Criterion;
using Sixty.Helpers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Managers
{
    public class SeasonManager : BaseManager<Season>, IManager
    {
        public override IEnumerable<IEntity> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<Season>()
                .AddOrder(Order.Desc("BeginDate"))
                .List<Season>();
        }
    }
}