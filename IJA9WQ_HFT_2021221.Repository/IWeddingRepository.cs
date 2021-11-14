using IJA9WQ_HFT_2021221.Models;
using System.Linq;

namespace IJA9WQ_HFT_2021221.Repository
{
    public interface IWeddingRepository
    {
        void Create(Wedding wedding);
        void Delete(int id);
        Wedding Read(int id);
        IQueryable<Wedding> ReadAll();
        void Update(Wedding wedding);
    }
}