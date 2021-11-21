using IJA9WQ_HFT_2021221.Models;
using System.Collections.Generic;

namespace IJA9WQ_HFT_2021221.Logic
{
    public interface IHusbandLogic
    {
        void Create(Husband husband);
        void Delete(int id);
        Husband Read(int id);
        IEnumerable<Husband> ReadAll();
        void Update(Husband husband);
    }
}