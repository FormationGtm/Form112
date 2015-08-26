using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionTheme:SearchOption
    {
        private readonly int? _idTheme;

        public SearchOptionTheme(SearchBase sb, int idTheme)
            : base(sb)
        {
            _idTheme = idTheme;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            if (_idTheme!=null)
            {
                return SearchBase.GetResult().Where(x => x.IdTheme == _idTheme);
            }
            return SearchBase.GetResult();
        }
    }
}