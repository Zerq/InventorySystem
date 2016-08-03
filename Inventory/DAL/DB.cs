using Lock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inventory.DAL {
    [Singleton]
    public class DB: IDisposable {
        public DB(LockToken lockToken) {
            context = new Context();
        }
        public Context context { get; set; }
        public void Dispose() {
            context.Dispose();
        }
    }
}