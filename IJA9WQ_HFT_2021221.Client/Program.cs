using System;
using IJA9WQ_HFT_2021221.Data;
using System.Linq;

namespace IJA9WQ_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WeddingDbContext db = new WeddingDbContext();

            var q = from x in db.Weddings
                    select new
                    {
                        Hely = x.Place,



                    };

            ;

        }
    }
}
