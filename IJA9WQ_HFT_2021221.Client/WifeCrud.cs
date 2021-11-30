using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    static class WifeCrud
    {
        public static List<Wife> ReadAll(RestService rest)
        {
            return rest.Get<Wife>("wife");
        }

        public static Wife Read(RestService rest, int id)
        {
            return rest.Get<Wife>(id,"wife");
        }
        public static void Create(RestService rest, string name, int age)
        {
            rest.Post<Wife>(new Wife()
            {
                Name = name,
                Age = age
            }, "wife");
        }

        public static void Update(RestService rest, int id, string name, int age)
        {
            rest.Put<Wife>(new Wife()
            {
                Id = id,
                Name = name,
                Age = age
            }, "wife");
        }

        public static void Delete(RestService rest, int id)
        {

            rest.Delete(id, "wife");
            
        }
    }
}
