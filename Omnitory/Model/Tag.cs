using System;

namespace Omnitory.Model {
    public class Tag {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public override string ToString() {
            return Name;
        }
    }
}