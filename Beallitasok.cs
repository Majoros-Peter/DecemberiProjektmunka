using System.Text.Json;

namespace Labirintus
{
    class B
    {
        public static void BeallitasokMain()
        {
            Console.Clear();
            Console.Write("[j]�t�k be�ll�t�sok\n[t]�rk�pszerkeszt� be�ll�t�sok");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.J:
                    JatekBeallitasok();
                    break;
                case ConsoleKey.T:
                    TerkepBeallitasok();
                    break;
            }
        }

        private static void TerkepBeallitasok()
        {

        }

        private static void JatekBeallitasok()
        {
            
        }
    }
    class Adatok
    {
        public static ConsoleColor
            labirintusKeretSzine = ConsoleColor.DarkYellow,
            labirintusSzine = ConsoleColor.White,
            uresHelySzine = ConsoleColor.Black,
            kivalasztottSzine = ConsoleColor.Cyan,
            elemSzine = ConsoleColor.Red,
            elemKereteSzine = ConsoleColor.DarkYellow,
            elemSorszamSzine = ConsoleColor.Green,
            bejartLabirintusSzine = ConsoleColor.Green,
            szovegSzine = ConsoleColor.White;
        public static string mappa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - "\\bin\\Debug\\net6.0".Length);
    }
}