using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionPortDepart:SearchOption
    {
        private readonly int? _idPort;

        public SearchOptionPortDepart(SearchBase sb, int idPort)
            : base(sb)
        {
            _idPort = idPort;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            if (_idPort != null)
            {
                return SearchBase.GetResult().Where(x => x.Ports.IdPort == _idPort);
            }
            return SearchBase.GetResult();
        }
    }
}