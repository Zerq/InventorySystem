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
                      Do= act =>  Program.Current.ChangeState(Singleton<States.RegisterNewContainer>.GetInstance())
                 });


                for(var i=0; i<containers.Count; i++) {
                  
                    var newMenuItem = new MenuItem();
                    newMenuItem.Index = i;
                    newMenuItem.Text = containers[newMenuItem.Index].Name;
                    newMenuItem.Do = act => {

                        if (Singleton<States.ContainerContentState>.HasInstance){
                           var state = Singleton<States.ContainerContentState>.GetInstance(containers[act.Index]);
                            state.containerContent = containers[act.Index];
                            Program.Current.ChangeState(state);

                        } else {               
                            Program.Current.ChangeState(Singleton<States.ContainerContentState>.GetInstance(containers[act.Index]));
                        };

                    };
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
