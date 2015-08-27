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
        private readonly string _idDestination;

        public SearchOptionDestination(SearchBase sb, string idDestination)
            : base(sb)
        {
            _idDestination = idDestination;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            if (!string.IsNullOrEmpty(_idDestination))
            {
                return SearchBase.GetResult().Where(x => x.Ports.Pays.CodeIso3 == _idDestination);
            }
            else
            {
                return SearchBase.GetResult();
            }
        }
    }
}