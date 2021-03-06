﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Omnitory.Model
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public virtual List<Tag> Tags { get; set; }
        [JsonIgnore]
        public virtual Container Container { get; set; }
        public virtual string ContainerId { get; set; }
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
