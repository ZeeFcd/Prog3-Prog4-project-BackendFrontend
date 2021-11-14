using IJA9WQ_HFT_2021221.Data;
using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Repository
{
    public class WifeRepository : IWifeRepository
    {
        WeddingDbContext db;
        public WifeRepository(WeddingDbContext db)
        {
            this.db = db;
        }

        public void Create(Wife Wife)
        {
            db.Wives.Add(Wife);
            db.SaveChanges();
        }

        public Wife Read(int id)
        {
            return
                db.Wives.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Wife> ReadAll()
        {
            return db.Wives;
        }

        public void Delete(int id)
        {
            var WifeToDelete = Read(id);
            db.Wives.Remove(WifeToDelete);
            db.SaveChanges();
        }

        public void Update(Wife Wife)
        {
            var WifeToUpdate = Read(Wife.Id);
            WifeToUpdate.Name = Wife.Name;
            WifeToUpdate.Age = Wife.Age;


            db.SaveChanges();
        }
    }
}
