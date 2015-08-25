using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionPortDeDepart : SearchOption
    {
        private readonly int _idPort;

        public SearchOptionPortDeDepart(SearchBase sb, int idPort)
            : base(sb)
        {
            _idPort = idPort;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.IdPort == _idPort);
        }
    }
}