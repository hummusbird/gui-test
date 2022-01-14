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

            Button button1 = new Button("X", 0, 26);
            Button button2 = new Button("-", 5, 26);
            Button button3 = new Button("#", 10, 26);
            Button button4 = new Button(" ", 15, 26);
            Button button5 = new Button("Clear", 20, 26, ConsoleColor.Black, ConsoleColor.White, ConsoleColor.Red);

            Button red = new Button("R", 30, 26, ConsoleColor.Black, ConsoleColor.Red);
            Button green = new Button("G", 35, 26, ConsoleColor.Black, ConsoleColor.Green);
            Button blue = new Button("B", 40, 26, ConsoleColor.Black, ConsoleColor.Blue);
            Button white = new Button("W", 45, 26, ConsoleColor.Black, ConsoleColor.White);

            char brush = 'X';
            ConsoleColor colour = ConsoleColor.White;

            while (i)
            {
                button1.Draw();
                button2.Draw();
                button3.Draw();
                button4.Draw();
                button5.Draw();

                red.Draw();
                green.Draw();
                blue.Draw();
                white.Draw();

                if (button1.clicked) { brush = 'X'; }
                if (button2.clicked) { brush = '-'; }
                if (button3.clicked) { brush = '#'; }
                if (button4.clicked) { brush = ' '; }
                if (button5.clicked) { Console.Clear(); }

                if (red.clicked) { colour = ConsoleColor.Red; }
                if (green.clicked) { colour = ConsoleColor.Green; }
                if (blue.clicked) { colour = ConsoleColor.Blue; }
                if (white.clicked) { colour = ConsoleColor.White; }

                if ( Mouse.MDown(Mouse.MouseButton.Left))
                {
                    Console.SetCursorPosition(Window.GetMousePosition().X, Window.GetMousePosition().Y);
                    Console.ForegroundColor = colour;
                    Console.Write(brush);

                }
                Console.WriteLine("PX: "+ Window.GetMousePosition(false).X + "," + Window.GetMousePosition(false).Y + "  \tROW: " + Window.GetMousePosition().X + "," + Window.GetMousePosition().Y);
            }

            Console.ReadKey();
        }
    }
}

