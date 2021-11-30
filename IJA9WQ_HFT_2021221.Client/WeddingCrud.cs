using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    static class WeddingCrud
    {
        public static List<Wedding> ReadAll(RestService rest)
        {
            return rest.Get<Wedding>("wedding");
        }

        public static Wedding Read(RestService rest, int id)
        {
            return rest.Get<Wedding>(id, "wedding");
        }
        public static void Create(RestService rest,int hId,int wId, string place, int price)
        {
            rest.Post<Wedding>(new Wedding()
            {
                HusbandID=hId,
                WifeID =wId,
                Place=place,
                Price=price,

            }, "wedding");
        }

        public static void Update(RestService rest, int id, int hId, int wId, string place, int price)
        {
            rest.Put<Wedding>(new Wedding()
            {
                Id = id,
                HusbandID = hId,
                WifeID = wId,
                Place = place,
                Price = price,

            }, "wedding");
        }

        public static void Delete(RestService rest, int id)
        {

            rest.Delete(id, "wedding");

        }
    }
}
