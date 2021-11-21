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
    }
}
