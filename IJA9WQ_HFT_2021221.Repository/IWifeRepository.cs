using IJA9WQ_HFT_2021221.Models;
using System.Linq;

namespace IJA9WQ_HFT_2021221.Repository
{
    public interface IWifeRepository
    {
        void Create(Wife Wife);
        void Delete(int id);
        Wife Read(int id);
        IQueryable<Wife> ReadAll();
        void Update(Wife Wife);
    }
}