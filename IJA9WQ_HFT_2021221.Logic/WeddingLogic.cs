using IJA9WQ_HFT_2021221.Models;
using IJA9WQ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Logic
{
    class WeddingLogic
    {
        IWeddingRepository weddingRepo;
        public WeddingLogic(IWeddingRepository weddingRepo)
        {
            this.weddingRepo = weddingRepo;
        }
        public void Create(Wedding wedding)
        {
            if (wedding.Price < 0)
            {
                throw new ArgumentException("Negative wedding price is forbidden!");
            }
            weddingRepo.Create(wedding);
        }

        public Wedding Read(int id)
        {
            return weddingRepo.Read(id);
        }

        public IEnumerable<Wedding> ReadAll()
        {
            return weddingRepo.ReadAll();
        }

        public void Delete(int id)
        {
            weddingRepo.Delete(id);
        }

        public void Update(Wedding wedding)
        {
            weddingRepo.Update(wedding);
        }

        public IEnumerable<KeyValuePair<string, string>> MarriedCouples()
        {
            return from x in weddingRepo.ReadAll()
                   select new KeyValuePair<string, string>
                   (x.Husband.Name, x.Wife.Name);

        }
        public IEnumerable<KeyValuePair<string, string>> WeddingPlacesByWife()
        {
            return from x in weddingRepo.ReadAll()
                   select new KeyValuePair<string, string>
                          (x.Wife.Name, x.Place);

        }

        public IEnumerable<KeyValuePair<string, int>> WeddingPricesByHusband()
        {
            return from x in weddingRepo.ReadAll()
                   select new KeyValuePair<string, int>
                          (x.Husband.Name, x.Price);

        }


        public double AverageAge() 
        {
            var q = weddingRepo.ReadAll();
            return q.Select(x => x.Husband.Age).Concat(q.Select(y => y.Wife.Age)).Average();
                         
        }

        public  string WifeWhereHusbandIsOldest() 
        {
            var q = weddingRepo.ReadAll();

            /*var q2 = q.Where(x => x.Husband.Age == q.Max(y => y.Husband.Age))
                    .Select(z=>z.Wife.Name)
                    .FirstOrDefault();*/

            return (from x in q
                    where x.Husband.Age == q.Max(y => y.Husband.Age)
                    select x.Wife.Name)
                     .FirstOrDefault();
                       
        }



    }
}
