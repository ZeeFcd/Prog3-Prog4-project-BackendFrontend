using System;
using System.Linq;
using System.Collections.Generic;
using IJA9WQ_HFT_2021221.Models;


namespace IJA9WQ_HFT_2021221.Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:18885");

            //tesztelés
            #region 
            /*
            WifeCrud.Create(rest, "Anyád", 43);
            WifeCrud.Create(rest, "Anyád3", 53);
            List<Wife> lista = WifeCrud.ReadAll(rest);
            Wife feleseg = WifeCrud.Read(rest, 5);
            ;
            WifeCrud.Update(rest, 6, "Anyád1", 423);
            ;
            ;
            WifeCrud.Delete(rest, 7);

            ;

            HusbandCrud.Create(rest, "Anyád", 43, 6);
            List<Husband> lista2 = HusbandCrud.ReadAll(rest);
            Husband ferj = HusbandCrud.Read(rest, 5);
            ;
            HusbandCrud.Update(rest, 6, "Anyád2", 433, 6);
            ;

            WeddingCrud.Create(rest, 6,6, "MAgyaro", 60000);
            List<Wedding> lista3 = WeddingCrud.ReadAll(rest);
            Wedding esk = WeddingCrud.Read(rest, 5);
            ;
            WeddingCrud.Update(rest,6, 6, 6, "AngolO", 70000);
            ;

            WeddingCrud.Delete(rest, 6);

            ;

            HusbandCrud.Delete(rest, 6);

            double atlag=StatMethods.AverageAge(rest);
            List<KeyValuePair<string,string>> hazasok=StatMethods.MarriedCouples(rest);
            List<KeyValuePair<string, string>> helyek=StatMethods.WeddingPlacesByWife(rest);
            List<KeyValuePair<string, int>> arak = StatMethods.WeddingPricesByHusband(rest);
            string felesegnevjnev=StatMethods.WifeWhereHusbandIsOldest(rest);*/
            #endregion 



            ;

        }
    }
}
