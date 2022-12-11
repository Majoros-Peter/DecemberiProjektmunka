using System;
using Terkep;
using Jatek;

namespace Program
{
    class P
    {
        static void Main()
        {
            while(true)
            {
                Console.CursorVisible = false;
                Console.Write("[j]áték indítása\n[p]álya szerkesztése");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.P:
                        T.TerkepMain();
                        return;
                    case ConsoleKey.J:
                        J.JatekMain();
                        return;
                }
            }
        }
    }
}