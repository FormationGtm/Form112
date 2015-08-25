using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionPrixMaxi:SearchOption
    {
         private readonly int? _prixMaxi;

        public SearchOptionPrixMaxi(SearchBase sb, int? prixMaxi)
            : base(sb)
        {
            _prixMaxi = prixMaxi;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            if (_prixMaxi != null)
            {
                return SearchBase.GetResult().Where(x => x.Prix <= _prixMaxi);
            }
            return SearchBase.GetResult();
        }
    }
}