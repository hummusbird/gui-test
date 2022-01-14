using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_test
{
    class Button
    {
        public string _text;
        private int _x, _y;
        private readonly ConsoleColor _bg;
        private readonly ConsoleColor _fg;
        private readonly ConsoleColor _cg;

        public bool clicked = false;

        public Button(string text = "button", int x = 0, int y = 0, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Green, ConsoleColor cg = ConsoleColor.DarkGray)
        {
            _text = text;
            _x = x;
            _y = y;
            _bg = bg;
            _fg = fg;
            _cg = cg;
        }

        public void Draw()
        {
            Mouse.POINT pos = Window.GetMousePosition();

            var bg = _bg;
            var fg = _fg;

            bool mouseover = pos.X > _x - 1 && pos.X < _x + _text.Length + 4 && pos.Y > _y - 1 && pos.Y < _y + 3;

            if (mouseover) // if mouseover
            {
                bg = _fg;
                fg = _bg;

                if (Mouse.MDown(Mouse.MouseButton.Left)) // if clicked
                {
                    bg = _cg;
                }
            }

            if (mouseover && Mouse.MDown(Mouse.MouseButton.Left)) { clicked = true; }
            else { clicked = false; }

            string row = new string('─', _text.Length + 2);

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            Console.SetCursorPosition(_x, _y);
            Console.WriteLine("┌" +  row + "┐");

            Console.SetCursorPosition(_x, _y +1);
            Console.WriteLine("│ " + _text + " │");

            Console.SetCursorPosition(_x, _y +2);
            Console.WriteLine("└" +  row + "┘");

            Console.ResetColor();
        }
    }
}
