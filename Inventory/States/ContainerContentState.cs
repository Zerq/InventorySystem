using System;
using System.Collections.Generic;
using System.Linq;
using Lock;
using Inventory.Helpers;

namespace Inventory.States {
    public class ContainerContentState : MenuStateBase {
        public ContainerContentState(LockToken lockToken, Model.Container content) : base(lockToken) {
            containerContent = content;
        }

        Model.Container containerContent { get; set; }

        string description = "";
        public override string Description {
            get {
              return description;
            }
        }

        private void RegisterAddItem()
        {
            var item = new Model.Item();
            var startX = Console.CursorLeft;
            var startY = Console.CursorTop;

            UI.Write("Scan item Barcode:", ConsoleColor.Yellow);
            item.Id = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Name the container:", ConsoleColor.Yellow);
            item.Name = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a description:", ConsoleColor.Yellow);
            item.Description = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a comma separated taglist:", ConsoleColor.Yellow);
            item.Tags = Console.ReadLine();
            UI.WriteLine("");

            UI.WriteLine("type y to confirm and save", ConsoleColor.Red);
            if (Console.ReadKey().KeyChar.ToString().ToLower() == "y")
            {
                item.Added = DateTime.Now;
                var db = Singleton<DAL.DB>.GetInstance().context;
                UI.Clear();
                UI.WriteLine("Scan Item to add"); 
                item.Container = this.containerContent;
                db.Entry<Model.Item>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void AddItem()
        {
            UI.Clear();
            UI.WriteLine("Scan Item to add");
            var db = Singleton<DAL.DB>.GetInstance().context;
            var item = db.Items.FirstOrDefault(n => n.Id == Console.ReadLine());
            item.Container = this.containerContent;
            db.Entry<Model.Item>(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


        List<MenuItem> items = new List<MenuItem>() {
             new MenuItem() {
                  Text="Add Item",
                   Do = ()=> Singleton<ContainerContentState>.GetInstance().AddItem()
             },
                     new MenuItem() {
                  Text="Register and add Item",
                   Do = ()=> Singleton<ContainerContentState>.GetInstance().RegisterAddItem()
             },
                new MenuItem() {
                  Text="back",
                   Do =  ()=> Program.Current.ChangeState(Lock.Singleton<ListContainersState>.GetInstance())
    }
        };

     

        public override List<MenuItem> menuItems {
            get {
                return items;
            }
        }

        public string distance = "  ";
        protected override void Render()
        {
            base.Render();
 
            containerContent.Items.ForEach(n => {
             

                UI.Write(" Name: ", ConsoleColor.Yellow ); UI.Write(n.Name + distance, ConsoleColor.White);
                UI.Write(" Description: ", ConsoleColor.Yellow); UI.Write(n.Description,  ConsoleColor.White);
                UI.Write(" Tag: ", ConsoleColor.Yellow); UI.Write(n.Tags+ distance, ConsoleColor.White);
                UI.Write(" Added: ", ConsoleColor.Yellow); UI.WriteLine(n.Added, ConsoleColor.White); 
            });
        }

        string title = "Container Content";
        public override string Title {
            get {
               return title;
            }
        }
    }
}