using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    static class CrudMethods<T>
    {
        public static List<T> ReadAll(RestService rest, string modelname)
        {
            return rest.Get<T>(modelname);
        }

        public static T Read(RestService rest, int id, string modelname)
        {
            return rest.Get<T>(id, modelname);
        }

        public static void CreateHusband(RestService rest, string name, int age, int wifeid)
        {
            rest.Post<Husband>(new Husband()
            {
                WifeID = wifeid,
                Name = name,
                Age = age
            }, "husband");
        }
        public static void CreateWife(RestService rest, string name, int age)
        {
            rest.Post<Wife>(new Wife()
            {
                Name = name,
                Age = age
            }, "wife");
        }
        public static void CreateWedding(RestService rest, int hId, int wId, string place, int price)
        {
            rest.Post<Wedding>(new Wedding()
            {
                HusbandID = hId,
                WifeID = wId,
                Place = place,
                Price = price,

            }, "wedding");
        }

        public static void UpdateHusband(RestService rest, int id, string name, int age, int wifeid)
        {
            rest.Put<Husband>(new Husband()
            {
                Id = id,
                WifeID = wifeid,
                Name = name,
                Age = age
            }, "husband");
        }
        public static void UpdateWife(RestService rest, int id, string name, int age)
        {
            rest.Put<Wife>(new Wife()
            {
                Id = id,
                Name = name,
                Age = age
            }, "wife");
        }
        public static void UpdateWedding(RestService rest, int id, int hId, int wId, string place, int price)
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

        public static void Delete(RestService rest, int id, string modelname)
        {

            rest.Delete(id, modelname);
        }
    }
}
