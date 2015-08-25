using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.SearchCroisiers.Base
{
    internal class SearchOption : SearchBase {
        protected SearchBase SearchBase;

        protected SearchOption(SearchBase sb) {
            SearchBase = sb;
        }


    }

    
}