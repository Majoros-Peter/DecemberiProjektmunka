namespace Labirintus
{
    class P
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Valaszt();
        }
        public static void Valaszt() => M.Valaszt(new string[] { Adatok.szoveg.Szerkesztes, Adatok.szoveg.Inditas, Adatok.szoveg.Beallitas, Adatok.szoveg.Kilepes }, new Action[] { T.TerkepMain, J.JatekMain, B.BeallitasokMain, Kilep }, Adatok.szoveg.Cim[0]);
        
        private static void Kilep()
        {
            return;
        }
    }
}