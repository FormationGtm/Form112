using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionBudget: SearchOption
    {
        private readonly int _idBudget;

        public SearchOptionBudget(SearchBase sb, int idBudget)
            : base(sb)
        {
            _idBudget = idBudget;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.Prix == _idBudget);
        }
    }
}