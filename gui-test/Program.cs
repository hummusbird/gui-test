using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace gui_test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool i = true;
            DisableEdit.Go();
            Console.CursorVisible = false;

            Button button1 = new Button("also different colours", 16, 7, ConsoleColor.Black, ConsoleColor.Blue);
            Button button2 = new Button("GAMING", 26, 13);
            Button button3 = new Button("buttons can be VERY LONG", 36, 13, ConsoleColor.Black, ConsoleColor.White, ConsoleColor.Red);

            while (i)
            {

                button1.Draw();
                button2.Draw();
                button3.Draw();

                //Console.WriteLine("PX: "+ Window.GetMousePosition(false).X + "," + Window.GetMousePosition(false).Y + "  \tROW: " + Window.GetMousePosition().X + "," + Window.GetMousePosition().Y);
                //Console.WriteLine(Mouse.IsButtonPressed(Mouse.MouseButton.Left));
            }

            Console.ReadKey();
        }
    }
}

