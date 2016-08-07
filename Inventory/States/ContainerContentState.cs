using System;
using System.Collections.Generic;
using System.Linq;
using Lock;
using Inventory.Helpers;

namespace Inventory.States {

    public class ContentItem : MenuItem  {
        public static string distance = "  ";
  

        public Model.Item Item { get; set;}

        public override void DrawText(bool IsOdd) {
            if (IsOdd) {
                UI.Write(" Name: ", ConsoleColor.Yellow); UI.Write(this.Item.Name + distance, ConsoleColor.White);
                UI.Write(" Description: ", ConsoleColor.Yellow); UI.Write(this.Item.Description, ConsoleColor.White);
                UI.Write(" Tag: ", ConsoleColor.Yellow); UI.Write(this.Item.Tags + distance, ConsoleColor.White);
                UI.Write(" Added: ", ConsoleColor.Yellow); UI.WriteLine(this.Item.Added, ConsoleColor.White);
            } else {
                UI.Write(" Name: ", ConsoleColor.Magenta); UI.Write(this.Item.Name + distance, ConsoleColor.White);
                UI.Write(" Description: ", ConsoleColor.Magenta); UI.Write(this.Item.Description, ConsoleColor.White);
                UI.Write(" Tag: ", ConsoleColor.Magenta); UI.Write(this.Item.Tags + distance, ConsoleColor.White);
                UI.Write(" Added: ", ConsoleColor.Magenta); UI.WriteLine(this.Item.Added, ConsoleColor.White);
            }

        }
    }

    public class ContainerContentState : MenuStateBase {
        public ContainerContentState(LockToken lockToken, Model.Container content) : base(lockToken) {
            containerContent = content;
        }

        internal Model.Container containerContent { get; set; }

        string description = "";
        public override string Description {
            get {
                return description;
            }
        }

        private void RegisterAddItem(string itemId = null) {
            var item = new Model.Item();
            var startX = Console.CursorLeft;
            var startY = Console.CursorTop;
            if (itemId == null) {
                UI.Write("Scan item Barcode:", ConsoleColor.Yellow);
                item.Id = Console.ReadLine();
                UI.WriteLine("");
            } else {
                item.Id = itemId;
            }

            UI.Write("Name the container:", ConsoleColor.Yellow);
            item.Name = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a description:", ConsoleColor.Yellow);
            item.Description = Console.ReadLine();
            UI.WriteLine("");

            UI.Write("Add a comma separated taglist:", ConsoleColor.Yellow);
            item.Tags = TagDialog.Instance.Select(item.Tags);
            UI.WriteLine("");

            UI.WriteLine("type y to confirm and save", ConsoleColor.Red);
            if (Console.ReadKey().KeyChar.ToString().ToLower() == "y") {
                item.Added = DateTime.Now;
                var db = Singleton<DAL.DB>.GetInstance().context;
                UI.Clear();
                UI.WriteLine("Scan Item to add");
                item.Container = this.containerContent;
                db.Items.Add(item);
                db.SaveChanges();
            }
        }

        private void AddItem() {
            UI.Clear();
            UI.WriteLine("Scan Item to add", ConsoleColor.Yellow);
            var db = Singleton<DAL.DB>.GetInstance().context;
            var itemId = Console.ReadLine();
            var item = db.Items.FirstOrDefault(n => n.Id == itemId);
            if (item == null) {
                UI.Write("Item does not exist! Register? y/n:", ConsoleColor.Red);
                var response = Console.ReadLine().ToLower();
                if (response == "y") {
                    RegisterAddItem(itemId);
                } else if (response == "n") {
                    Redraw();
                }
            } else {
                item.Container = this.containerContent;
                db.Entry<Model.Item>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


        private KeyInterface<IMenuState> keyInterface = new KeyInterface<IMenuState>(
             new KeyHook<IMenuState>(ConsoleKey.UpArrow, n => n.Upp()),
             new KeyHook<IMenuState>(ConsoleKey.DownArrow, n => n.Down()),
             new KeyHook<IMenuState>(ConsoleKey.Enter, n =>n.DoMenuAction()),    
             new KeyHook<IMenuState>(ConsoleKey.Delete, n => ((ContainerContentState)n).DeleteItem()));

        private void DeleteItem() {

            var x = menuItems[selectionIndex] as ContentItem;

            if (!(x == null || x.Item is Model.Container)) {
                UI.WriteLine("Are you sure? (y/n)", ConsoleColor.Red);
                var answer = Console.ReadKey();
                if (answer.KeyChar.ToString().ToLower() == "y") {
                    var db = Singleton<DAL.DB>.GetInstance().context;
                    db.Items.Remove(x.Item);
                    db.SaveChanges();
                    menuItems.Remove(x);
                    UI.Clear();
                    Redraw();
                } else {
                    UI.Clear();
                    Redraw();
                }
            } else if (x.Item is Model.Container){
                UI.WriteLine("This is a container. Move it to root? (y/n)", ConsoleColor.Red);
                var answer = Console.ReadKey();
                if (answer.KeyChar.ToString().ToLower() == "y") {
                    var db = Singleton<DAL.DB>.GetInstance().context;
                    //  var container = db.Containers.First(n => n.Id == x.Item.Id);
                    //container.Container = null;
                    x.Item.Container = null;
                    db.Entry(x.Item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    UI.Clear();
                    Redraw();
                }
                }
        }



        protected override KeyInterface<IMenuState> KeyInterface {
            get {
                return keyInterface;
            }
        }

        List<MenuItem> items = new List<MenuItem>() {
             new MenuItem() {
                  Text="Add Item",
                   Do = act=> Singleton<ContainerContentState>.GetInstance().AddItem()
             },
                     new MenuItem() {
                  Text="Register and add Item",
                   Do = act=> Singleton<ContainerContentState>.GetInstance().RegisterAddItem()
             },
                new MenuItem() {
                  Text="back",
                   Do =  act=> Program.Current.ChangeState(Lock.Singleton<ListContainersState>.GetInstance())
    }
        };

     

        public override List<MenuItem> menuItems {
            get {
                var result = new List<MenuItem>();
                result.AddRange(items);
                var i = 0;
               var dynmaicitems = containerContent.Items.Select(n => {
                    var temp = new ContentItem() {
                        Item = n,
                        Do = act => this.EditItem(n)
                    };
                    i++;
                    return temp;
                }).ToArray();
                result.AddRange(dynmaicitems);
                return result;
            }
        }

        private void EditItem(Model.Item item) {
            UI.Clear();
            UI.Write("Name is ", ConsoleColor.White);
            UI.Write($@"""{item.Name}""", ConsoleColor.Yellow);
            UI.Write(" write new or press enter to keep: ", ConsoleColor.White);
            var temp = Console.ReadLine();
            if (temp != string.Empty) {
                item.Name = temp;
            }

            UI.Write("Description is ", ConsoleColor.White);
            UI.Write($@"""{item.Description}""", ConsoleColor.Yellow);
            UI.Write(" write new or press enter to keep: ", ConsoleColor.White);
            temp = Console.ReadLine();
            if (temp != string.Empty) {
                item.Description = temp;
            }

            UI.Write("Tags is ", ConsoleColor.White);
            UI.Write($@"""{item.Tags}""", ConsoleColor.Yellow);
            UI.Write(" write new or press enter to keep: ", ConsoleColor.White);
            temp = Console.ReadLine();
            if (temp != string.Empty) {
                item.Tags = TagDialog.Instance.Select(item.Tags);
            }

            var db = Singleton<DAL.DB>.GetInstance();
            db.context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.context.SaveChanges();
            UI.Clear();
            Redraw();
        }

        public string distance = "  ";
        protected override void Render()
        {
            base.Render();
     
            //containerContent.Items.ForEach(n => {
             

            //    UI.Write(" Name: ", ConsoleColor.Yellow ); UI.Write(n.Name + distance, ConsoleColor.White);
            //    UI.Write(" Description: ", ConsoleColor.Yellow); UI.Write(n.Description,  ConsoleColor.White);
            //    UI.Write(" Tag: ", ConsoleColor.Yellow); UI.Write(n.Tags+ distance, ConsoleColor.White);
            //    UI.Write(" Added: ", ConsoleColor.Yellow); UI.WriteLine(n.Added, ConsoleColor.White); 
            //});
        }

        string title = "Container Content";
        public override string Title {
            get {
               return title;
            }
        }
    }
}