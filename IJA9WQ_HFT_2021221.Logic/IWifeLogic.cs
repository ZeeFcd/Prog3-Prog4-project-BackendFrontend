using IJA9WQ_HFT_2021221.Models;
using System.Collections.Generic;

namespace IJA9WQ_HFT_2021221.Logic
{
    public interface IWifeLogic
    {
        void Create(Wife wife);
        void Delete(int id);
        Wife Read(int id);
        IEnumerable<Wife> ReadAll();
        void Update(Wife wife);
    }
}