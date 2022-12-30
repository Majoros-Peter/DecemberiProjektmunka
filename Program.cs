namespace Labirintus
{
    class P
    {
        public static ConsoleKey[] terkepGombok = { };

        static void Main()
        {
            string[] szovegek = { "Játék indítása", "Pálya szerkesztése" };
            Action[] methods = {J.JatekMain, T.TerkepMain };

            M.Valaszt(szovegek, methods);
            Console.CursorVisible = false;
            Console.Write("[j]áték indítása\n[p]álya szerkesztése\n[b]eállítások");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.P:
                    T.TerkepMain();
                    return;
                case ConsoleKey.J:
                    J.JatekMain();
                    return;
                case ConsoleKey.B:
                    B.BeallitasokMain();
                    return;
            }
        }
    }
}