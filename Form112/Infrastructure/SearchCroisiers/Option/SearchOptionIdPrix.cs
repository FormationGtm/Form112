using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionIdPrix:SearchOption
    {
         private readonly int? _idPrix;

         int prixMaxi;
         int prixMini;

        public SearchOptionIdPrix(SearchBase sb, int? idPrix)
            : base(sb)
        {
            _idPrix = idPrix;
          
            switch (idPrix)
            {
                case 1:
                    prixMini = 1;
                    prixMaxi = 999;
                    break;
                case 2:
                    prixMini = 1000;
                    prixMaxi = 2999;
                    break;
                case 3:
                    prixMini = 3000;
                    prixMaxi = 4999;
                    break;
                case 4:
                    prixMini = 5000;
                    break;
            }
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return _idPrix!=0
                ? SearchBase.GetResult().Where(x => x.Prix <= prixMaxi && x.Prix >= prixMini)
                : SearchBase.GetResult();
        }
    }
}