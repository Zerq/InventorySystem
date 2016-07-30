using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lock;

namespace Inventory.States {
    public class ListContainersState : MenuStateBase {
        public ListContainersState(LockToken lockToken) : base(lockToken) {
        }

        public override string Description {
            get {
                return "Blarg";
            }
        }

  
        public override List<MenuItem> menuItems {
            get {
                var containers = Singleton<DAL.DB>.GetInstance().context.Containers.Where(n => n.Container == null).ToList();
                List<MenuItem> result = new List<MenuItem>();
                result.Add(new MenuItem() {
                     Text= "Register Container",
                      Do= ()=>  Program.Current.ChangeState(Singleton<States.RegisterNewContainer>.GetInstance())
                 });

                foreach (var item in containers) {
                    var newMenuItem = new MenuItem();
                    newMenuItem.Text = item.Name;
                    newMenuItem.Do = () => Program.Current.ChangeState(Singleton<States.ContainerContentState>.GetInstance(item));
                    result.Add(newMenuItem);
                }
                return result;                
            }
        }
        
        private string title = "Listing Containers..";
        public override string Title {
            get {
                return title;
            }
        }
    }
}
