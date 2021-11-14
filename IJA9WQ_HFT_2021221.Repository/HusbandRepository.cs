using IJA9WQ_HFT_2021221.Data;
using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Repository
{
    public class HusbandRepository : IHusbandRepository
    {
        WeddingDbContext db;
        public HusbandRepository(WeddingDbContext db)
        {
            this.db = db;
        }

        public void Create(Husband husband)
        {
            db.Husbands.Add(husband);
            db.SaveChanges();
        }

        public Husband Read(int id)
        {
            return
                db.Husbands.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Husband> ReadAll()
        {
            return db.Husbands;
        }

        public void Delete(int id)
        {
            var HusbandToDelete = Read(id);
            db.Husbands.Remove(HusbandToDelete);
            db.SaveChanges();
        }

        public void Update(Husband husband)
        {
            var HusbandToUpdate = Read(husband.Id);
            HusbandToUpdate.Name = husband.Name;
            HusbandToUpdate.Age = husband.Age;
            HusbandToUpdate.WifeID = husband.WifeID;
            db.SaveChanges();
        }

    }
}
