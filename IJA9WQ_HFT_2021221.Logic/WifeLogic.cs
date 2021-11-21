using IJA9WQ_HFT_2021221.Models;
using IJA9WQ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Logic
{
    public class WifeLogic
    {
        IWifeRepository wifeRepo;
        public WifeLogic(IWifeRepository wifeRepo)
        {
            this.wifeRepo = wifeRepo;
        }
        public void Create(Wife wife)
        {
            if (wife.Age < 16)
            {
                throw new ArgumentException("Not legal age for wedding!");
            }
            wifeRepo.Create(wife);
        }

        public Wife Read(int id)
        {
            return wifeRepo.Read(id);
        }

        public IEnumerable<Wife> ReadAll()
        {
            return wifeRepo.ReadAll();
        }

        public void Delete(int id)
        {
            wifeRepo.Delete(id);
        }

        public void Update(Wife wife)
        {
            wifeRepo.Update(wife);
        }

       

    }
}
