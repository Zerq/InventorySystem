using Inventory.Helpers;
using System;

namespace Inventory.States {
    public class MenuItem {
        public string Text { get; set; }
        public virtual void DrawText(bool IsOdd) {
            if (IsOdd) {
                UI.WriteLine(Text, ConsoleColor.Red);
            } else {
                UI.WriteLine(Text, ConsoleColor.White);
            }
        }
        public Action<MenuItem> Do { get; set; }
        public int Index { get; set; }
    }
}