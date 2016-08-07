using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omnitory.Model
{
    public class Container : Item
    {

           public virtual List<Item> Items { get; set; }
    }
}
