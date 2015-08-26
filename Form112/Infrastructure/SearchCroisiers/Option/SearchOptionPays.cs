using DataLayer.Model;
using Form112.Infrastructure.SearchCroisiers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Form112.Infrastructure.SearchCroisiers.Option
{
    internal class SearchOptionPays : SearchOption
    {
        private readonly string _codeIso2;

        /// <summary>
        /// Constructeur qui définit la valeur de tri par pays
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="codeIso2"></param>
        public SearchOptionPays(SearchBase sb, string codeIso2) : base (sb)
        {
            _codeIso2 = codeIso2;
        }

        /// <summary>
        /// Méthode publique permettant de filter la liste des croisières 
        /// selon le critère du pays choisi
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Croisieres> GetResult()
        {
            if (_codeIso2 != null)
            {
                return SearchBase.GetResult().Where(c => c.Ports.Pays.CodeIso2 == _codeIso2);
            }
            return SearchBase.GetResult();
        }
    }
}