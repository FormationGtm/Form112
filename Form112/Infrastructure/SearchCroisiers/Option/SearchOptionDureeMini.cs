using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionDureeMini : SearchOption
    {
        private readonly int? _dureeMini;

        public SearchOptionDureeMini(SearchBase sb, int dureeMini)
            : base(sb)
        {
            _dureeMini = dureeMini;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return _dureeMini!=0
                ? SearchBase.GetResult().Where(x => x.Durees.NbJours >= _dureeMini)
                : SearchBase.GetResult();
        }
    }
}