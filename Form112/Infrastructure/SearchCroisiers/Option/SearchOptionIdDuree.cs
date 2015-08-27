using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionIdDuree: SearchOption
    {
        private readonly int? _idDuree;

        int dureeMini;
        int dureeMaxi;
        public SearchOptionIdDuree(SearchBase sb, int? idDuree)
            : base(sb)
        {
            _idDuree = idDuree;

            switch (idDuree)
            {
                case 1:
                    dureeMini = 1;
                    dureeMaxi = 7;
                    break;
                case 2:
                    dureeMini = 7;
                    dureeMaxi = 10;
                    break;
                case 3:
                    dureeMini = 10;
                    dureeMaxi = 15;
                    break;
                case 4:
                    dureeMini = 15;
                    break;
            }
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return _idDuree!=0
                ? SearchBase.GetResult().Where(x => x.Durees.NbJours <= dureeMaxi && x.Durees.NbJours >= dureeMini)
                : SearchBase.GetResult();
        }
    }
}