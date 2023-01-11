namespace Labirintus
{
    class J
    {
        private static char[,] matrix;
        private static string eleresiUt;
        private static byte oldalBekezdes, felsoBekezdes = 3, felfedezettTermek = 0;
        private static bool fedettTerkep = false, sotet = false, vaksag = false;
        private static SzinIndex szin = Adatok.szinek;
        private static Nyelv szoveg = Adatok.szoveg;
        private static Gombok gombok = Adatok.gombok;
        public static void JatekMain() => M.Valaszt(new string[] { szoveg.AlapJatek, szoveg.Cim[7], szoveg.Vissza }, new Action[] { AlapJatek, NehezsegValaszto, P.Valaszt }, szoveg.Cim[2]);
        public static void NehezsegValaszto() => M.Valaszt(new string[] { szoveg.Nehezitesek[0], szoveg.Nehezitesek[1], szoveg.Nehezitesek[2], szoveg.Vissza }, new Action[] { () => { fedettTerkep = !fedettTerkep; vaksag = false; NehezsegValaszto(); }, () => { sotet = !sotet; vaksag = false; NehezsegValaszto(); }, ()=> { vaksag = true; NehezsegValaszto(); }, JatekMain }, szoveg.Cim[7] );

        private static void AlapJatek()
        {
            Console.ForegroundColor = (ConsoleColor)szin.SzovegSzine;
            Console.Write(szoveg.BekerPalyaNev[2]);
            matrix = T.Betolt(Console.ReadLine(), ref eleresiUt, 2);

            oldalBekezdes = (byte)((Console.WindowWidth-matrix.GetLength(0))/2);

            Console.Clear();
            PalyaRajzol();
            Console.ForegroundColor = (ConsoleColor)szin.LabirintusSzine;
            Mozgas();
        }

        private static void PalyaRajzol()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = (ConsoleColor)szin.LabirintusKeretSzine;
            for (byte i = 0; i < matrix.GetLength(0); i++)
            {
                Console.SetCursorPosition(i+oldalBekezdes, felsoBekezdes-1);
                Console.Write('═');
                Console.SetCursorPosition(i+oldalBekezdes, felsoBekezdes+matrix.GetLength(1));
                Console.Write('═');
            }
            Console.Write('╝');
            Console.SetCursorPosition(oldalBekezdes-1, felsoBekezdes-1);
            Console.Write('╔');
            Console.SetCursorPosition(oldalBekezdes-1, felsoBekezdes+matrix.GetLength(1));
            Console.Write('╚');
            Console.SetCursorPosition(oldalBekezdes+matrix.GetLength(0), felsoBekezdes-1);
            Console.Write('╗');
            for (byte i = 0; i < matrix.GetLength(1); i++)
            {
                Console.SetCursorPosition(oldalBekezdes-1, felsoBekezdes+i);
                Console.Write('║');
                Console.SetCursorPosition(oldalBekezdes+matrix.GetLength(0), felsoBekezdes+i);
                Console.Write('║');
            }

            
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                Console.SetCursorPosition(oldalBekezdes, oszlop+felsoBekezdes);
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                    BeirElem(sor, oszlop);
                Console.WriteLine();
            }
        }

        private static void BeirElem(byte x, byte y)
        {
            if (matrix[x, y] == '.')
                Console.ForegroundColor = (ConsoleColor)szin.UresHelySzine;
            else
                Console.ForegroundColor = (ConsoleColor)szin.LabirintusSzine;
            Console.Write(matrix[x, y]);
        }

        private static byte[] GombNyomas(ref byte[] koord, byte nyomottGomb)
        {
            //FEL
            if (gombok.Fel == nyomottGomb)
            {
                if (koord[1] > 0 && "╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]]) && "╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]-1]))
                {
                    Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[1]--;
                }
                return koord;
            }
            //LE
            else if (gombok.Le == nyomottGomb)
            {
                if (koord[1]+1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]]) && "╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]+1]))
                {
                    Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[1]++;
                }
                return koord;
            }
            //BAL     
            else if (gombok.Bal == nyomottGomb)
            {
                if (koord[0] > 0 && "╬═╦╩╣╗╝█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╠╚╔█".Contains(matrix[koord[0]-1, koord[1]]))
                {
                    Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[0]--;
                }
                return koord;
            }
            //JOBB
            else if (gombok.Jobb == nyomottGomb)
            {
                if (koord[0]+1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╣╗╝█".Contains(matrix[koord[0]+1, koord[1]]))
                {
                    Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[0]++;
                }
                return koord;
            }
            return koord;
        }

        private static void Mozgas()
        {
            byte[] koord = { 0, 1 };
            Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                if (matrix[koord[0], koord[1]] == '█')
                    felfedezettTermek++;
                Console.Write(matrix[koord[0], koord[1]]);
                Informaciok(koord);
                Console.SetCursorPosition(GombNyomas(ref koord, (byte)Console.ReadKey(true).Key)[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            }
        }

        private static void Informaciok(byte[] koord)
        {
            Console.ResetColor();
            T.Torol();
            Console.SetCursorPosition(0, 0);
            Console.Write($"{szoveg.Informaciok[0]}: {eleresiUt}.txt, {szoveg.Informaciok[1]}: {matrix.GetLength(0)}x{matrix.GetLength(1)}");
            Console.SetCursorPosition(0, 1);
            Console.Write(szoveg.Informaciok[2]);
            if (!vaksag)
            {
                if (koord[1] > 0 && "╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]]) && "╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]-1])) Console.Write(szoveg.Iranyok[0]);
                if (koord[1]+1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]]) && "╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]+1])) Console.Write(szoveg.Iranyok[1]);
                if (koord[0] > 0 && "╬═╦╩╣╗╝█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╠╚╔█".Contains(matrix[koord[0]-1, koord[1]])) Console.Write(szoveg.Iranyok[2]);
                if (koord[0]+1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╣╗╝█".Contains(matrix[koord[0]+1, koord[1]])) Console.Write(szoveg.Iranyok[3]);
            }
            else
                Console.Write(szoveg.VakVagy);
            Console.SetCursorPosition(0, 2);
            Console.Write($"F{szoveg.Informaciok[3]}: {felfedezettTermek}");
        }
    }
}