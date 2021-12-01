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
        public RestService rest; 
        public Menu(RestService rest)
        {
            this.rest = rest;
            MenuCreate();
        }

        //Non crud metódusok kiírása konzolra
        private void SomeAction() { }
        private void MarriedCouplesCW() 
        {
            Console.Clear();
            var couples = StatMethods.MarriedCouples(rest);
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
        private void WeddingPlacesByWifeCW() 
        {
            Console.Clear();
            var placesbywife = StatMethods.WeddingPlacesByWife(rest);
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
        private void WeddingPricesByHusbandCW() 
        {
            Console.Clear();
            var pricesbyhusband = StatMethods.WeddingPricesByHusband(rest);
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
        private void WifeWhereHusbandIsOldestCW() 
        {
            Console.Clear();
            var wifewherehusbandisoldest = StatMethods.WifeWhereHusbandIsOldest(rest);
            Console.WriteLine("Wife where husband is oldest:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(wifewherehusbandisoldest);
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
        private void AverageAgeCW() 
        {
            Console.Clear();
            var averageage = StatMethods.AverageAge(rest);
            Console.WriteLine("Average age:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(averageage);
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }

        //Crud metódusok kiírása konzolra
        private void ReadAllCW()
        {
            Console.Clear();
            Console.WriteLine("From which table(Model) would you like to get all?");
            Console.Write("Choose one (a) husband, (b) wife, (c) wedding : ");
            var read = Console.ReadLine();
            
            switch (read)
            {
                case "a":
                    var husbands = CrudMethods<Husband>.ReadAll(rest,"husband");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Husbands:");
                    Console.WriteLine("-----------------------------");
                    foreach (var husband in husbands)
                    {
                        Console.WriteLine("Husband ID: " + husband.Id + ", WifeID: " + husband.WifeID+", Name: "+husband.Name + ", Age: "+husband.Age);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "b":
                    var wives = CrudMethods<Wife>.ReadAll(rest, "wife");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Wives:");
                    Console.WriteLine("-----------------------------");
                    foreach (var wife in wives)
                    {
                        Console.WriteLine("Wife ID: " + wife.Id + ", Name: " + wife.Name + ", Age: " + wife.Age);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "c":
                    var weddings = CrudMethods<Wedding>.ReadAll(rest, "wedding");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Weddings:");
                    Console.WriteLine("-----------------------------");
                    foreach (var wedding in weddings)
                    {
                        Console.WriteLine("Wedding ID: " + wedding.Id + ", HusbandID: "+ wedding.HusbandID + ", WifeID: " + wedding.WifeID+", Place: "+wedding.Place+ ", Price: " + wedding.Price);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }

        }

        private void ReadCW() 
        {
            Console.Clear();
            Console.WriteLine("From which table(Model) would you like to get one?");
            Console.Write("Choose one (a) husband, (b) wife, (c) wedding : ");
            var read = Console.ReadLine();
            Console.Write("Give a model Id: ");
            var id = Console.ReadLine();

            switch (read)
            {
                case "a":
                    var husband = CrudMethods<Husband>.Read(rest,int.Parse(id), "husband");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Selected Husband:");
                    Console.WriteLine("-----------------------------");                 
                    Console.WriteLine("Husband ID: " + husband.Id + ", WifeID: " + husband.WifeID + ", Name: " + husband.Name + ", Age: " + husband.Age);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "b":
                    var wife = CrudMethods<Wife>.Read(rest, int.Parse(id), "wife");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Selected wife:");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Wife ID: " + wife.Id + ", Name: " + wife.Name + ", Age: " + wife.Age);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "c":
                    var wedding = CrudMethods<Wedding>.Read(rest, int.Parse(id), "wedding");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Weddings:");
                    Console.WriteLine("-----------------------------");                   
                    Console.WriteLine("Wedding ID: " + wedding.Id + ", HusbandID: " + wedding.HusbandID + ", WifeID: " + wedding.WifeID + ", Place: " + wedding.Place + ", Price: " + wedding.Price);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }

        //Createlni csak wife--->husband---> wedding sorrendben (fk constraint)
        private void CreateCW()
        {
            Console.Clear();
            Console.WriteLine("What row(Model) would you like to create? (You MUST make wife first, husband second, wedding third!)");
            Console.Write("Choose one (a) husband, (b) wife, (c) wedding : ");
            var read = Console.ReadLine();

            switch (read)
            {
                case "a":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give WifeID: ");
                    var wifeidH = Console.ReadLine();
                    Console.Write("Give Name: ");
                    var nameH = Console.ReadLine();
                    Console.Write("Give Age (16 is legal age): ");
                    var ageH = Console.ReadLine();

                    CrudMethods<Husband>.CreateHusband(rest, nameH, int.Parse(ageH), int.Parse(wifeidH));

                    Console.WriteLine("-----------------------------");                   
                    Console.WriteLine("Created Husband;  WifeID: " + wifeidH + ", Name: " + nameH + ", Age: " + ageH);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "b":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give Name: ");
                    var nameW = Console.ReadLine();
                    Console.Write("Give Age (16 is legal age): ");
                    var ageW = Console.ReadLine();

                    CrudMethods<Wife>.CreateWife(rest, nameW, int.Parse(ageW));

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Created Wife; Name: " + nameW + ", Age: " + ageW);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "c":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give HusbandID: ");
                    var husbandid = Console.ReadLine();
                    Console.Write("Give WifeID: ");
                    var wifeid = Console.ReadLine();
                    Console.Write("Give Place: ");
                    var place = Console.ReadLine();
                    Console.Write("Give Price: ");
                    var price = Console.ReadLine();

                    CrudMethods<Wedding>.CreateWedding(rest, int.Parse(husbandid), int.Parse(wifeid), place,int.Parse(price));

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Created Wedding; HusbandID: " + husbandid + ", WifeID: " + wifeid + ", Place: "+place+ ", Price: " +price);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }
        //idegen kulcsokat megfelelő utána járással tudunk csak updatelni mert adatbázis constraintek exceptiont dobnak
        private void UpdateCW()
        {
            Console.Clear();
            Console.WriteLine("What row(Model) would you like to update?");
            Console.Write("Choose one (a) husband, (b) wife, (c) wedding : ");
            var read = Console.ReadLine();
            Console.Write("Give a model Id: ");
            var id = Console.ReadLine();

            switch (read)
            {
                case "a":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give updated WifeID: ");
                    var wifeidH = Console.ReadLine();
                    Console.Write("Give updated Name: ");
                    var nameH = Console.ReadLine();
                    Console.Write("Give updated Age (16 is legal age): ");
                    var ageH = Console.ReadLine();

                    CrudMethods<Husband>.UpdateHusband(rest, int.Parse(id),nameH, int.Parse(ageH), int.Parse(wifeidH));

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Updated Husband; Id: " +id+", Wife: " + wifeidH + ", Name: " + nameH + ", Age: " + ageH);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "b":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give updated Name: ");
                    var nameW = Console.ReadLine();
                    Console.Write("Give updated Age (16 is legal age): ");
                    var ageW = Console.ReadLine();

                    CrudMethods<Wife>.UpdateWife(rest,int.Parse(id), nameW, int.Parse(ageW));

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Updated Wife; Id: "+id+" Name: " + nameW + ", Age: " + ageW);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "c":
                    Console.WriteLine("-----------------------------");
                    Console.Write("Give updated HusbandID: ");
                    var husbandid = Console.ReadLine();
                    Console.Write("Give updated WifeID: ");
                    var wifeid = Console.ReadLine();
                    Console.Write("Give updated Place: ");
                    var place = Console.ReadLine();
                    Console.Write("Give updated Price: ");
                    var price = Console.ReadLine();

                    CrudMethods<Wedding>.UpdateWedding(rest, int.Parse(id),int.Parse(husbandid), int.Parse(wifeid), place, int.Parse(price));

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Created Wedding; Id: "+id+", HusbandID: " + husbandid + ", WifeID: " + wifeid + ", Place: " + place + ", Price: " + price);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }

        //Delete-ni csak wedding--->husband---> wife sorrendben (fk constraint)
        private void DeleteCW() 
        {
            Console.Clear();
            Console.WriteLine("From which table(Model) would you like to delete one? (You MUST delete wedding first, husband second, wife third!)");
            Console.Write("Choose one (a) husband, (b) wife, (c) wedding : ");
            var read = Console.ReadLine();
            Console.Write("Give a model Id: ");
            var id = Console.ReadLine();
            switch (read)
            {
                case "a":
                    CrudMethods<Husband>.Delete(rest, int.Parse(id), "husband");

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Selected Husband(id="+id+ ") deleted!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "b":
                    CrudMethods<Wife>.Delete(rest, int.Parse(id), "wife");

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Selected Wife(id=" + id + ") deleted!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                case "c":
                    CrudMethods<Wedding>.Delete(rest, int.Parse(id), "wedding");

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Selected Wedding(id=" + id + ") deleted!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to menu...");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }

        }


        //Menu
        private ConsoleMenu Submenu1()
        {
            var submenu1 = new ConsoleMenu();

            submenu1
               .Add("Read all (table)", ReadAllCW)
                .Add("Read a row(from table)", ReadCW)
                .Add("Create a row", CreateCW)
                .Add("Update a row", UpdateCW)
                .Add("Delete a row", DeleteCW)
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