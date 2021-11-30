using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    static class HusbandCrud
    {
        public static List<Husband> ReadAll(RestService rest) 
        {
            return rest.Get<Husband>("husband");
        }

        public static Husband Read(RestService rest,int id) 
        {
            return rest.Get<Husband>(id,"husband");
        }
        public static void Create(RestService rest, string name, int age,int wifeid )
        {
            rest.Post<Husband>(new Husband()
            {
                WifeID= wifeid,
                Name = name,
                Age=age
            }, "husband");
        }

        public static void Update(RestService rest, int id,string name, int age, int wifeid)
        {
            rest.Put<Husband>(new Husband()
            {
                Id = id,
                WifeID = wifeid,
                Name = name,
                Age = age
            }, "husband"); 
        }

        public static void Delete(RestService rest, int id) 
        {

            rest.Delete(id, "husband");
        }
    }
}
