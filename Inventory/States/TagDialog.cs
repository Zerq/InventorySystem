using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Model;
using Inventory.Helpers;
using Lock;


namespace Inventory.States {

    public class TagItem : MenuItem {
public Model.Tag Tag { get; set; }
        public void DrawText(bool IsOdd, bool selected) {
            var text = "";
            if (selected) {
                text = $"[{Tag.Name}]";

            } else {
                text = $"{Tag.Name}";
            }

            if (IsOdd) {
                UI.WriteLine(text, ConsoleColor.White);
            }else {
                UI.WriteLine(text, ConsoleColor.Red);
            }
        }
    }

    public class TagDialog : IMenuState {
        TagDialog() {

        }
        static TagDialog instance;
        public static TagDialog Instance {
            get {
                if (TagDialog.instance == null) {
                    TagDialog.instance = new TagDialog();
                }
                return TagDialog.instance;
            }
            }

       static  bool selecting;


        protected int selectionIndex = 0;
        private List<MenuItem> menuItems = new List<MenuItem>();

        public void PageUpp() {
            selectionIndex-=10;
            if (selectionIndex < 0) {
                if (menuItems.Count > 0) {
                    selectionIndex = menuItems.Count - 1;
                } else {
                    selectionIndex = 0;
                }
            }
        }
        public void PageDown() {
            selectionIndex+=10;
            if (selectionIndex >= menuItems.Count) {
                selectionIndex = 0;
            }
        }

        public void Upp() {
            selectionIndex--;
            if (selectionIndex < 0) {
                if (menuItems.Count > 0) {
                    selectionIndex = menuItems.Count - 1;
                } else {
                    selectionIndex = 0;
                }
            }
        }
        public void Down() {
            selectionIndex++;
            if (selectionIndex >= menuItems.Count) {
                selectionIndex = 0;
            }
        }
        public void DoMenuAction() {
            menuItems[selectionIndex].Do(menuItems[selectionIndex]);
        }
        public void Select() {
            menuItems[selectionIndex].Do(menuItems[selectionIndex]);
        }


        private KeyInterface<TagDialog> keyInterface = new KeyInterface<TagDialog>(
             new KeyHook<TagDialog>(ConsoleKey.UpArrow, n => n.Upp()),
             new KeyHook<TagDialog>(ConsoleKey.DownArrow, n => n.Down()),
             new KeyHook<TagDialog>(ConsoleKey.Enter, n => n.DoMenuAction())
             );

        protected virtual KeyInterface<TagDialog> KeyInterface {
            get { return keyInterface; }
        }



  
         public List<Tag> SelectionMenu(List<Tag> selection) {
            TagDialog.Instance.KeyInterface.Listen(TagDialog.Instance);
            var db = Singleton<DAL.DB>.GetInstance().context;

            menuItems = db.Tags.Select(n => new TagItem() { Tag = n}).Cast<MenuItem>().ToList();
            UI.Clear();
            UI.WriteLine("Select a Tag or more with space press enter to finish", ConsoleColor.Cyan);


            for (var i = 0; i < menuItems.Count; i++) {
                TagItem tag = menuItems[i] as TagItem;

                if (selection.Contains(tag.Tag)) {
                    tag.DrawText(i % 2 == 0, true);
                } else {
                    tag.DrawText(i % 2 == 0, false);
                }
           
                 
            }
            return selection;
        }

        public List<Tag> Select(List<Tag> selection) {
            UI.Clear();
            selecting = true;


            while (selecting) {
                selection = SelectionMenu(selection );
            }

            return selection;
        }
    }
}