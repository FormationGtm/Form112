using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionPrixMini: SearchOption
    {
        private readonly int? _prixMini;

        public SearchOptionPrixMini(SearchBase sb, int? prixMini)
            : base(sb)
        {
            _prixMini = prixMini;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return _prixMini!=0
                ? SearchBase.GetResult().Where(x => x.Prix >= _prixMini)
                : SearchBase.GetResult();
        }
    }
}