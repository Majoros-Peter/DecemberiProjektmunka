using System;
using Terkep;
using Jatek;
using Methods;

namespace Program
{
    class P
    {
        static void Main()
        {
            string[] szovegek = { "Játék indítása", "Pálya szerkesztése" };
            Action[] methods = {J.JatekMain, T.TerkepMain };

            M.Valaszt(szovegek, methods);
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