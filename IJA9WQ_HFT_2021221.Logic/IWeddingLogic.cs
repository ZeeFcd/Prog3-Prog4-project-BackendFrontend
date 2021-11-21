using IJA9WQ_HFT_2021221.Models;
using System.Collections.Generic;

namespace IJA9WQ_HFT_2021221.Logic
{
    public interface IWeddingLogic
    {
        double AverageAge();
        void Create(Wedding wedding);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, string>> MarriedCouples();
        Wedding Read(int id);
        IEnumerable<Wedding> ReadAll();
        void Update(Wedding wedding);
        IEnumerable<KeyValuePair<string, string>> WeddingPlacesByWife();
        IEnumerable<KeyValuePair<string, int>> WeddingPricesByHusband();
        string WifeWhereHusbandIsOldest();
    }
}