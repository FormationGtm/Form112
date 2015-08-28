using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Infrastructure.Utilitaires
{
    public class ListesChoix
    {

        public static List<KeyValuePair<int, string>> ListTranchePrix()
        {
            var ltp = new List<KeyValuePair<int, string>>();
            ltp.Add(new KeyValuePair<int, string>(1, "Moins de 1000€"));
            ltp.Add(new KeyValuePair<int, string>(2, "Entre 1000 et 3000€"));
            ltp.Add(new KeyValuePair<int, string>(3, "Entre 3000 et 5000€"));
            ltp.Add(new KeyValuePair<int, string>(4, "Plus de 5000€"));

            return ltp;
        }

        public static List<KeyValuePair<int, string>> ListTrancheDuree()
        {
            var ltd = new List<KeyValuePair<int, string>>();
            ltd.Add(new KeyValuePair<int, string>(1, "Moins de 7 jours"));
            ltd.Add(new KeyValuePair<int, string>(2, "Entre 7 et 10 jours"));
            ltd.Add(new KeyValuePair<int, string>(3, "Entre 10 et 15 jours"));
            ltd.Add(new KeyValuePair<int, string>(4, "Plus de 15 jours"));

            return ltd;
        }
    }
}