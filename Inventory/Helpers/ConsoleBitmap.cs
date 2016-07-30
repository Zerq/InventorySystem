using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Helpers {
    public  class ConsoleBitmap
    {      
        public ConsoleBitmap(string path, ConsoleColor? transparent= null) {
             bmp = new Bitmap(Bitmap.FromFile(path));
            this.transparent = transparent;
        }
        Bitmap bmp;
        ConsoleColor? transparent;
        ConsoleColor ClosestColor(int r, int g, int b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }
        void DrawPixel(ConsoleColor color, int x, int y)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.ForegroundColor = color;
            Console.BackgroundColor = color;
            Console.Write("▓");
            Console.ResetColor();
        }
        public void Draw(int xOffset = 0, int yOffset = 0)
        {
          
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var color = bmp.GetPixel(x, y);
                    var consoleColor = ClosestColor(color.R,color.G,color.B);
                    if (transparent.HasValue)
                    {
                        if (transparent.Value == consoleColor)
                        {
                            Console.CursorLeft += 2;
                        }
                        else
                        {
                            DrawPixel(consoleColor, x + xOffset, y + yOffset);
                        }

                    }
                    else
                    {
                        DrawPixel(consoleColor, x + xOffset, y + yOffset);
                    }

                }
            }

        }
    }
}
