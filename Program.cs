namespace Labirintus
{
    class P
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Valaszt();
        }
        public static void Valaszt() => M.Valaszt(new string[] { Adatok.szoveg.Inditas, Adatok.szoveg.Szerkesztes, Adatok.szoveg.Beallitas, Adatok.szoveg.Kilepes }, new Action[] { J.JatekMain, T.TerkepMain, B.BeallitasokMain, Kilep }, Adatok.szoveg.Cim[0]);
        
        private static void Kilep()
        {
            return;
        }
    }
}