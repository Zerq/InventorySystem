using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lock;
using Inventory.Helpers;
 

namespace Inventory.States
{
    public abstract class MenuStateBase : StateBase  {
        public MenuStateBase(LockToken lockToken) : base(lockToken) {
        }

        private int selectionIndex = 0;
        public abstract List<MenuItem> menuItems { get; }
        public abstract string Title { get; }
        public abstract string Description { get; }
       

        private void Upp() {
            selectionIndex--;
            if (selectionIndex < 0) {
                if (menuItems.Count > 0) {
                    selectionIndex = menuItems.Count - 1;
                } else {
                    selectionIndex = 0;
                }
            }
        }
        private void Down() {
            selectionIndex++;
            if (selectionIndex >= menuItems.Count) {
                selectionIndex = 0;
            }
        }
        private void DoMenuAction() {
            menuItems[selectionIndex].Do();
        }

        private KeyInterface<MenuStateBase> KeyInterface = new KeyInterface<MenuStateBase>(
            new KeyHook<MenuStateBase>(ConsoleKey.UpArrow, n => n.Upp()),
            new KeyHook<MenuStateBase>(ConsoleKey.DownArrow, n=> n.Down()),
            new KeyHook<MenuStateBase>(ConsoleKey.Enter, n=> n.DoMenuAction())
            );

      

 


        protected override void PostRenderUpdate() {
            KeyInterface.Listen(this);
        }

        protected override void PreRenderUpdate() {
    
        }

        protected override void Render() {
            UI.Reset();
            UI.WriteLine(Title, ConsoleColor.Cyan);
            UI.WriteLine(Description, ConsoleColor.Yellow);
            for(var i=0; i<menuItems.Count; i++) {
                var item = menuItems[i];
                if (i == selectionIndex) {
                    UI.WriteLine(item.Text, ConsoleColor.Red);
                } else {
                    UI.WriteLine(item.Text, ConsoleColor.White);
                }
            }
        }
    }
}
