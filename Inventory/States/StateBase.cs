using Inventory.Helpers;
using Lock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.States
{

    [Singleton]
    public abstract class StateBase {

 
        public StateBase(LockToken lockToken) {
           
            typeof(LockToken).GetMethod("Enforce").MakeGenericMethod(this.GetType()).Invoke(null,new object[] { lockToken });      
        }

        public bool Initilized { get; private set; }
        public bool ReDraw { get; private set; }
        protected void Redraw() {
            this.ReDraw = true;
        }

        public void Enter() {       
            if (Initilized == false) {
                Initialize();
            } else {
                ReEnter();
            }
        }

        protected virtual void Initialize() {
            Initilized = true;
            ReDraw = true;
        }
        protected virtual void ReEnter() {
            ReDraw = true;
        }

        protected abstract void PreRenderUpdate();
        protected abstract void PostRenderUpdate();
        protected virtual void ExitState() {
            UI.Clear();
        }

        protected abstract void Render();

        public void ChangeState(StateBase newState) {
            Program.Current.ExitState();
            Program.Current = newState;
            newState.Enter();
        }

        public void Run() {
            PreRenderUpdate();
            if (ReDraw) {
                Render();
            }
            PostRenderUpdate();
        }
         
    }
}
