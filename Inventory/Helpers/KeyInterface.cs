using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Helpers {
    //ok so i should have this as two separete files but meh it only a inparameter class so i can use params...
    public class KeyHook<T> {
        public KeyHook(ConsoleKey key, Action<T> action) {
            this.Key = key;
            this.Action = action;
        }
        public ConsoleKey Key { get; set; }
        public Action<T> Action { get; set; }
    }

    public class KeyInterface<T> {
        public KeyInterface(params KeyHook<T>[] hooks) {
            dictionary = new Dictionary<ConsoleKey, Action<T>>();
            foreach (var hook in hooks) {
                dictionary.Add(hook.Key, hook.Action);
            }
        }
        Dictionary<ConsoleKey, Action<T>> dictionary;
        List<ConsoleKey> pressed = new List<ConsoleKey>();
        public void Listen(T source) {
        //    if (Console.KeyAvailable)
          //  {
                var key = Console.ReadKey(true).Key;
                if (dictionary.ContainsKey(key)) {
                    dictionary[key].Invoke(source);
                }
                //  System.Threading.Thread.Sleep(300);
            //}
        }
       
    }
}
