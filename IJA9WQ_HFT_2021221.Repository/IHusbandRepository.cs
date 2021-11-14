using IJA9WQ_HFT_2021221.Models;
using System.Linq;

namespace IJA9WQ_HFT_2021221.Repository
{
    public interface IHusbandRepository
    {
        void Create(Husband husband);
        void Delete(int id);
        Husband Read(int id);
        IQueryable<Husband> ReadAll();
        void Update(Husband husband);
    }
}