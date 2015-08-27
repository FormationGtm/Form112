using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionDureeMaxi: SearchOption
    {
        private readonly int? _dureeMaxi;

        public SearchOptionDureeMaxi(SearchBase sb, int dureeMaxi)
            : base(sb)
        {
            _dureeMaxi = dureeMaxi;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return _dureeMaxi!=0
                ? SearchBase.GetResult().Where(x => x.Durees.NbJours <= _dureeMaxi)
                : SearchBase.GetResult();
        }
    }
}