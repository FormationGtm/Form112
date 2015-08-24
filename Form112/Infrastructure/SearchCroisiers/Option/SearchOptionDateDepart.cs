using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionDateDepart : SearchOption
    {
        private readonly DateTime _idDateDepart;

        public SearchOptionDateDepart(SearchBase sb, DateTime idDateDepart)
            : base(sb)
        {
            _idDateDepart = idDateDepart;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.DateDepart == _idDateDepart);
        }
    }
}