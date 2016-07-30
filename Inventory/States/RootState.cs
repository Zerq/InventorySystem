using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.States {
    public class RootState : MenuStateBase  {
        public RootState(Lock.LockToken token) : base(token) { }


        private string desc = "bla bla bla";
        public override string Description {
            get {
                return desc;
            }
        }
        private List<MenuItem> items = new List<MenuItem>() {
            new MenuItem { Text="List All Containers", Do=()=> {
                Program.Current.ChangeState(Lock.Singleton<ListContainersState>.GetInstance());
 
            }
            },
                new MenuItem { Text="option 2", Do=()=> {

            }
            },
                    new MenuItem { Text="option 3", Do=()=> {

            }
            }
        };

        public override List<MenuItem> menuItems {
            get {
                return items;
            }
        }
        string title = "root menu";
        public override string Title {
            get {
                return title;
            }
        }
    }
}
