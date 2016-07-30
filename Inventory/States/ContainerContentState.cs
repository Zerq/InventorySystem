using System;
using System.Collections.Generic;
using Lock;

namespace Inventory.States {
    public class ContainerContentState : MenuStateBase {
        public ContainerContentState(LockToken lockToken, Model.Container content) : base(lockToken) {
            containerContent = content;
        }

        Model.Container containerContent { get; set; }
        
        public override string Description {
            get {
                throw new NotImplementedException();
            }
        }

        public override List<MenuItem> menuItems {
            get {
                throw new NotImplementedException();
            }
        }

        public override string Title {
            get {
                throw new NotImplementedException();
            }
        }
    }
}