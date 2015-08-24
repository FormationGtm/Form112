using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Model;

namespace Form112.Infrastructure.SearchCroisiers.Base
{
    
        internal abstract class SearchBase
        {
            protected IEnumerable<Croisieres> SearchCroisiers;

            public abstract IEnumerable<Croisieres> GetResult();
        }
    
}