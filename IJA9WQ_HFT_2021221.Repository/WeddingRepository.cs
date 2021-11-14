using IJA9WQ_HFT_2021221.Data;
using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Repository
{
    public class WeddingRepository : IWeddingRepository
    {
        WeddingDbContext db;
        public WeddingRepository(WeddingDbContext db)
        {
            this.db = db;
        }

        public void Create(Wedding wedding)
        {
            db.Weddings.Add(wedding);
            db.SaveChanges();
        }

        public Wedding Read(int id)
        {
            return
                db.Weddings.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Wedding> ReadAll()
        {
            return db.Weddings;
        }

        public void Delete(int id)
        {
            var WeddingToDelete = Read(id);
            db.Weddings.Remove(WeddingToDelete);
            db.SaveChanges();
        }

        public void Update(Wedding wedding)
        {
            var WeddingToUpdate = Read(wedding.Id);
            WeddingToUpdate.Place = wedding.Place;
            WeddingToUpdate.Price = wedding.Price;
            WeddingToUpdate.HusbandID = wedding.HusbandID;
            WeddingToUpdate.WifeID = wedding.WifeID;

            db.SaveChanges();
        }
    }
}
