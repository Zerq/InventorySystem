﻿using System.Collections.Generic;
namespace Omnitory.Model
{
    public class Container : Item
    {
           public virtual List<Item> Items { get; set; }
    }
}
