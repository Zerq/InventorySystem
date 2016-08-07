using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lock;
using Inventory.Helpers;
 

namespace Inventory.States
{
    public abstract class MenuStateBase : StateBase, IMenuState {
        public MenuStateBase(LockToken lockToken) : base(lockToken) {
        }

        protected int selectionIndex = 0;
        public abstract List<MenuItem> menuItems { get; }
        public abstract string Title { get; }
        public abstract string Description { get; }


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


       private KeyInterface<IMenuState> keyInterface = new KeyInterface<IMenuState>(
            new KeyHook<IMenuState>(ConsoleKey.UpArrow, n => n.Upp()),
            new KeyHook<IMenuState>(ConsoleKey.DownArrow, n => n.Down()),
            new KeyHook<IMenuState>(ConsoleKey.Enter, n => n.DoMenuAction())
            );

        protected virtual KeyInterface<IMenuState> KeyInterface {
          get { return keyInterface; }
        }




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
                item.DrawText(i == selectionIndex);
            }
        }
    }

    public interface IMenuState {
        void DoMenuAction();
        void Down();
        void Upp();
    }
}
