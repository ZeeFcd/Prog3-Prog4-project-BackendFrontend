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

            Menu indit = new Menu();




            //tesztelés
            #region 
            /*
            CrudMethods<Wife>.CreateWife(rest, "Anyád", 43);
            CrudMethods<Wife>.CreateWife(rest, "Anyád3", 53);
            List<Wife> lista = CrudMethods<Wife>.ReadAll(rest,"wife");
            Wife feleseg = CrudMethods<Wife>.Read(rest, 5,"wife");
            ;
            CrudMethods<Wife>.UpdateWife(rest, 6, "Anyád1", 423);
            ;
            ;
            CrudMethods<Wife>.Delete(rest, 7, "wife");

            ;

            CrudMethods<Husband>.CreateHusband(rest, "Anyád", 43, 6);
            List<Husband> lista2 = CrudMethods<Husband>.ReadAll(rest,"husband");
            Husband ferj = CrudMethods<Husband>.Read(rest, 5, "husband");
            ;
            CrudMethods<Husband>.UpdateHusband(rest, 6, "Anyád2", 433, 6);
            ;

            CrudMethods<Wedding>.CreateWedding(rest, 6,6, "MAgyaro", 60000);
            List<Wedding> lista3 = CrudMethods<Wedding>.ReadAll(rest,"wedding");
            Wedding esk = CrudMethods<Wedding>.Read(rest, 5,"wedding");
            ;
            CrudMethods<Wedding>.UpdateWedding(rest,6, 6, 6, "AngolO", 70000);
            ;

            CrudMethods<Wedding>.Delete(rest, 6,"wedding");

            ;

            CrudMethods<Husband>.Delete(rest, 6,"husband");

            double atlag=StatMethods.AverageAge(rest);
            var hazasok=StatMethods.MarriedCouples(rest);
            var helyek=StatMethods.WeddingPlacesByWife(rest);
            var arak = StatMethods.WeddingPricesByHusband(rest);
            string felesegnevjnev=StatMethods.WifeWhereHusbandIsOldest(rest);*/
            #endregion
            ;

        }
    }
}
