using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public string Tags { get; set; }
        public virtual Container Container { get; set; }
        public override bool Equals(object obj) {
            if (obj is Item) {
                return this.Id == (obj as Item).Id;
            } else {
                return false;
            }    
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return this.Name;
        }
    }
}
