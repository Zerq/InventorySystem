using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnitory.DAL {
    public class Db {
        static Context context;
        public static Context Context { get {
                if (context == null) {
                    context = new Context();
                }
                return context;
            } }
    }
}
