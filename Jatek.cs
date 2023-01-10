namespace Labirintus
{
    class J
    {
        private static byte oldalBekezdes, felsoBekezdes = 3;
        private static char[,] matrix;
        private static bool sotet = false;
        private static SzinIndex szin = Adatok.szinek;
        private static Nyelv szoveg = Adatok.szoveg;
        private static Gombok gombok = Adatok.gombok;
        public static void JatekMain() => M.Valaszt(new string[] { "Alap játék", "" }, new Action[] { AlapJatek }, szoveg.Cim[2]);
        public static void NehezsegValaszto() => M.Valaszt(new string[] { "Sötét", "" }, new Action[] { () =>sotet=!sotet } );

        private static void AlapJatek()
        {
            Console.ForegroundColor = (ConsoleColor)szin.SzovegSzine;
            Console.Write(szoveg.BekerPalyaNev[1]);

            matrix = T.Betolt(Console.ReadLine());
            oldalBekezdes = (byte)((Console.WindowWidth-matrix.GetLength(0))/2);

            Console.Clear();
            PalyaRajzol();
            Console.ForegroundColor= (ConsoleColor)szin.LabirintusSzine;
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
                if ("╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]]) && "╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]-1]))
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
                if ("╬╦║╣╠╗╔█".Contains(matrix[koord[0], koord[1]]) && "╬╩║╣╠╝╚█".Contains(matrix[koord[0], koord[1]+1]))
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
                if ("╬═╦╩╣╗╝█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╠╚╔█".Contains(matrix[koord[0]-1, koord[1]]))
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
                if ("╬═╦╩╠╚╔█".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╣╗╝█".Contains(matrix[koord[0]+1, koord[1]]))
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
                    break;
                Console.Write(matrix[koord[0], koord[1]]);
                Console.SetCursorPosition(GombNyomas(ref koord, (byte)Console.ReadKey(true).Key)[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            }
        }
    }
}