using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers
{
    internal class Search : SearchBase
    {
        public Search()
        {
            SearchCroisiers = new Form112Entities().Croisieres;
        }


        public Search(IEnumerable<Croisieres> result)
        {
            SearchCroisiers = result;
        }

        public override IEnumerable<Croisieres> GetResult()
        {
            return SearchCroisiers;
        }
    }
}