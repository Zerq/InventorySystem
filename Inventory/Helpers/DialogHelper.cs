using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Helpers {
    public static class DialogHelper
    {
        public static void WriteDialog(int x, int y, int? size, string text, ConsoleColor? fore=null, ConsoleColor? back=null)
        {
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int widest;

            if (size.HasValue)
            { widest = size.Value; }
            else
            { widest = lines.Max(n => n.Length); }

            StringBuilder builder = new StringBuilder();

            var empty = "║ ".PadRight(widest - 1, ' ') + "║";
            UI.WriteOffset("╔".PadRight(widest - 1, '═') + "╗",  x, y, fore, back);//start
            UI.WriteOffset(empty,  x, y + 1, fore, back);//start

            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                UI.WriteOffset($"║  {line}".PadRight(widest - 1, ' ') + "║",  x, y + 2 + i, fore, back);
            }

            UI.WriteOffset(empty,  x, y + 2 + lines.Count(), fore, back);//start
            UI.WriteOffset("╚".PadRight(widest - 1, '═') + "╝",x, y + 3 + lines.Count(), fore, back);//end
        }
  
    }
}
