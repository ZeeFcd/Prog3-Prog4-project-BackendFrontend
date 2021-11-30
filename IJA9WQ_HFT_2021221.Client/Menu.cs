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
        public Menu()
        {
            MenuCreate();
        }

        public void SomeAction() { }
        public void Marriedcouples() 
        {
            var couples = new List<KeyValuePair<string, string>>();
            Console.WriteLine("");

        }

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
                .Add("Married couples", SomeAction)
                .Add("Wedding places by wife", SomeAction)
                .Add("Wedding prices by husband", SomeAction)
                .Add("Wife where husband is oldest", SomeAction)
                .Add("Average age", SomeAction)
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
                .Add("Exit", () => Environment.Exit(0))
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