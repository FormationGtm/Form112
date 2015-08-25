using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionDestination : SearchOption
    {
        private readonly string _idDestenation;

        public SearchOptionDestination(SearchBase sb, string idDestenation)
            : base(sb)
        {
            _idDestenation = idDestenation;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.Ports.Pays.Regions.Nom == _idDestenation);
        }
    }
}