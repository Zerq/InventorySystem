using System;

namespace Inventory.States {
    public class MenuItem { 
        public string Text { get;   set; }
        public Action Do { get; set; }
    }
}