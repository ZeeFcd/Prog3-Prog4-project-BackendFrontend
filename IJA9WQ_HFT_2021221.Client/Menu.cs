using ConsoleTools;
using IJA9WQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Client
{
    class Menu
    {
        public RestService Rest { get; }
        public Menu(RestService rest)
        {
            Rest = rest;
            MenuCreate();
        }

        //Non crud metódusok kiírása konzolra
        public void SomeAction() { }
        public void MarriedCouplesCW() 
        {
            Console.Clear();
            var couples = StatMethods.MarriedCouples(Rest);
            Console.WriteLine("Married couples:");
            Console.WriteLine("-----------------------------");
            foreach (var couple in couples)
            {
               Console.WriteLine("Husband: "+couple.Key+", Wife: "+couple.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
        public void WeddingPlacesByWifeCW() 
        {
            Console.Clear();
            var placesbywife = StatMethods.WeddingPlacesByWife(Rest);
            Console.WriteLine("Wedding places by wife:");
            Console.WriteLine("-----------------------------");
            foreach (var item in placesbywife)
            {
                Console.WriteLine("Wife: " + item.Key + ", Place: " + item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
        public void WeddingPricesByHusbandCW() 
        {
            Console.Clear();
            var pricesbyhusband = StatMethods.WeddingPricesByHusband(Rest);
            Console.WriteLine("Wedding places by wife:");
            Console.WriteLine("-----------------------------");
            foreach (var item in pricesbyhusband)
            {
                Console.WriteLine("Husband: " + item.Key + ", Price: " + item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
        public void WifeWhereHusbandIsOldestCW() 
        {
            Console.Clear();
            var wifewherehusbandisoldest = StatMethods.WifeWhereHusbandIsOldest(Rest);
            Console.WriteLine("Wife where husband is oldest:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(wifewherehusbandisoldest);
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
        public void AverageAgeCW() 
        {
            Console.Clear();
            var averageage = StatMethods.AverageAge(Rest);
            Console.WriteLine("Average age:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(averageage);
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }

        //Crud metódusok kiírása konzolra

        private ConsoleMenu Submenu1()
        {
            var submenu1 = new ConsoleMenu();

            submenu1
               .Add("Read all (table)", SomeAction)
                .Add("Read a row(from table)", SomeAction)
                .Add("Create a row", SomeAction)
                .Add("Update a row", SomeAction)
                .Add("Delete a row", SomeAction)
                .Add("Close", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Husband CRUD";
                    config.EnableWriteTitle = true;
                });

            return submenu1;

        }
        private ConsoleMenu Submenu2()
        {
            var submenu2 = new ConsoleMenu();
            submenu2
                .Add("Married couples", MarriedCouplesCW)
                .Add("Wedding places by wife", WeddingPlacesByWifeCW)
                .Add("Wedding prices by husband", WeddingPricesByHusbandCW)
                .Add("Wife where husband is oldest", WifeWhereHusbandIsOldestCW)
                .Add("Average age", AverageAgeCW)
                .Add("Close", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Stat methods";
                    config.EnableWriteTitle = true;
                });
            return submenu2;
        }
        private void MenuCreate()
        {
            var menu = new ConsoleMenu();
            var submenu1 = Submenu1();
            var submenu2 = Submenu2();


            menu
                .Add("CRUD", submenu1.Show)
                .Add("Stat methods", submenu2.Show)
                .Add("Exit", ConsoleMenu.Close) //() => Environment.Exit(0)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.Title = "Wedding Client Main menu";
                    config.EnableWriteTitle = true;
                });
            ;

            menu.Show();
        }

    }
}