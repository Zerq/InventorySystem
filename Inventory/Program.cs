using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory {
    class Program {
        public static States.StateBase Current;
      
        static void Main(string[] args) { 
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");
            Current = Lock.Singleton<States.RootState>.GetInstance();
            Current.Enter();
            while (true) {
                Current.Run();
            }
        }


        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine 
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType) {
            if (Lock.Singleton<DAL.DB>.HasInstance) { 
                    Lock.Singleton<DAL.DB>.GetInstance().Dispose();
            }
            return true;
        }




    }
}
