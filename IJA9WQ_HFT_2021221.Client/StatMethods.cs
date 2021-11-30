using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    static class StatMethods
    {
        public static List<KeyValuePair<string, string>> MarriedCouples(RestService rest)
        {
            return  rest.Get<KeyValuePair<string, string>>("/stat/marriedcouples");
        }

        public static List<KeyValuePair<string, string>> WeddingPlacesByWife(RestService rest)
        {
            return rest.Get<KeyValuePair<string, string>>("/stat/weddingplacesbywife");
        }
               
        public static List<KeyValuePair<string, int>> WeddingPricesByHusband(RestService rest)
        {
            return  rest.Get<KeyValuePair<string, int>>("/stat/weddingpricesbyhusband");
        }
      
        public static double AverageAge(RestService rest)
        {
            return rest.GetSingle<double>("/stat/averageage");
        }
       
        public static string WifeWhereHusbandIsOldest(RestService rest)
        {
            return rest.GetSingle<string>("/stat/wifewherehusbandisoldest");
        }

    }
}
