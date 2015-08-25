using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionDureeDeSejour : SearchOption
    {
        private readonly int _idDuree;

        public SearchOptionDureeDeSejour(SearchBase sb, int idDuree)
            : base(sb)
        {
            _idDuree = idDuree;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchBase.GetResult().Where(x => x.IdDuree == _idDuree);
        }
    }
}