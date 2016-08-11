using System.Collections.Generic;
namespace Omnitory.Model
{
    public class Container : Item
    {
        public Container() {
            this.Items = new List<Item>();
        }
           public virtual List<Item> Items { get; set; }
    }
}
