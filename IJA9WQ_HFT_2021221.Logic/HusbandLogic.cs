using IJA9WQ_HFT_2021221.Models;
using IJA9WQ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Logic
{
    public class HusbandLogic : IHusbandLogic
    {
        IHusbandRepository husbandRepo;
        public HusbandLogic(IHusbandRepository husbandRepo)
        {
            this.husbandRepo = husbandRepo;
        }
        public void Create(Husband husband)
        {
            if (husband.Age < 16)
            {
                throw new ArgumentException("Not legal age for wedding!");
            }
            husbandRepo.Create(husband);
        }

        public Husband Read(int id)
        {
            return husbandRepo.Read(id);
        }

        public IEnumerable<Husband> ReadAll()
        {
            return husbandRepo.ReadAll();
        }

        public void Delete(int id)
        {
            husbandRepo.Delete(id);
        }

        public void Update(Husband husband)
        {
            husbandRepo.Update(husband);
        }




    }
}
