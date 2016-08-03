using System;
using System.Collections.Generic;
using Lock;
using Inventory.Helpers;

namespace Inventory.States {
    internal class RegisterNewContainer : MenuStateBase {
        public RegisterNewContainer(LockToken lockToken) : base(lockToken) {
        }
        string description = "scan an existing barcode or opt to print a new one";
        public override string Description {
            get {
                return description;
            }
        }
        List<MenuItem> list = new List<MenuItem>() {
            new MenuItem() { Text="Scan",  Do=()=>ScanWizard() },
            new MenuItem() { Text="Print", Do=()=>PrintWizard()},
            new MenuItem() { Text="Back", Do=()=> Program.Current.ChangeState(Lock.Singleton<ListContainersState>.GetInstance())
            }
        };

        private static void PrintWizard() {
            throw new NotImplementedException();
        }

        private static void ScanWizard() {
            var container = new Model.Container();
            var startX = Console.CursorLeft;
            var startY = Console.CursorTop;

            UI.Write("Scan Container Barcode:",ConsoleColor.Yellow);
            container.Id = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Name the container:", ConsoleColor.Yellow);
            container.Name = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a description:", ConsoleColor.Yellow);
            container.Description = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a comma separated taglist:", ConsoleColor.Yellow);
            container.Tags = Console.ReadLine();
            UI.WriteLine("");

            UI.WriteLine("type y to confirm and save", ConsoleColor.Red);
            if (Console.ReadKey().KeyChar.ToString().ToLower() == "y") {
                container.Added = DateTime.Now;
                Singleton<DAL.DB>.GetInstance().context.Containers.Add(container);
                Singleton<DAL.DB>.GetInstance().context.SaveChanges();
                Program.Current.ChangeState(Lock.Singleton<ListContainersState>.GetInstance());
                
            }
        }

        public override List<MenuItem> menuItems {
            get {
                return list;
            }
        }
        string title = "Register Container";
        public override string Title {
            get {
                return title;
            }
        }
    }
}