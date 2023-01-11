using System.Diagnostics;
using System.Numerics;

namespace Labirintus
{
    class J
    {
        private static char[,] matrix;
        private static byte[] koord;
        private static string eleresiUt;
        private static byte oldalBekezdes, felsoBekezdes = 3, felfedezettTermek = 0, termekSzama;
        private static List<byte[]> teremkoordinatak = new(), szelsokoordianata = new();
        private static bool fedettTerkep = false, fenyveszto = false, vaksag = false, kijuthat = false, bentvan = true;
        private static SzinIndex szin = Adatok.szinek;
        private static Nyelv szoveg = Adatok.szoveg;
        private static Gombok gombok = Adatok.gombok;
        public static void JatekMain() => M.Valaszt(new string[] { szoveg.AlapJatek, szoveg.Cim[7], szoveg.Vissza }, new Action[] { AlapJatek, NehezsegValaszto, P.Valaszt }, szoveg.Cim[2]);
        public static void NehezsegValaszto() => M.Valaszt(new string[] { szoveg.Nehezitesek[0], szoveg.Nehezitesek[1], szoveg.Nehezitesek[2], szoveg.Vissza }, new Action[] { () => { fedettTerkep = true; AlapJatek(); }, () => { fenyveszto = true; AlapJatek(); }, () => { vaksag = true; AlapJatek(); }, JatekMain }, szoveg.Cim[7]);
        private static void AlapJatek()
        {
            Console.ForegroundColor = (ConsoleColor)szin.SzovegSzine;
            Console.Write(szoveg.BekerPalyaNev[2]);
            matrix = T.Betolt(Console.ReadLine(), ref eleresiUt, 2);

            oldalBekezdes = (byte)((Console.WindowWidth - matrix.GetLength(0)) / 2);

            Console.Clear();
            PalyaRajzol();
            Console.ForegroundColor = (ConsoleColor)szin.LabirintusSzine;
            byte[] koord = { 0, 1 };
            Mozgas();
        }

        private static void PalyaRajzol()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = (ConsoleColor)szin.LabirintusKeretSzine;
            for (byte i = 0; i < matrix.GetLength(0); i++)
            {
                Console.SetCursorPosition(i + oldalBekezdes, felsoBekezdes - 1);
                Console.Write('═');
                Console.SetCursorPosition(i + oldalBekezdes, felsoBekezdes + matrix.GetLength(1));
                Console.Write('═');
            }
            Console.Write('╝');
            Console.SetCursorPosition(oldalBekezdes - 1, felsoBekezdes - 1);
            Console.Write('╔');
            Console.SetCursorPosition(oldalBekezdes - 1, felsoBekezdes + matrix.GetLength(1));
            Console.Write('╚');
            Console.SetCursorPosition(oldalBekezdes + matrix.GetLength(0), felsoBekezdes - 1);
            Console.Write('╗');
            for (byte i = 0; i < matrix.GetLength(1); i++)
            {
                Console.SetCursorPosition(oldalBekezdes - 1, felsoBekezdes + i);
                Console.Write('║');
                Console.SetCursorPosition(oldalBekezdes + matrix.GetLength(0), felsoBekezdes + i);
                Console.Write('║');
            }


            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                Console.SetCursorPosition(oldalBekezdes, oszlop + felsoBekezdes);
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                {

                    BeirElem(sor, oszlop);
                    

                }
                Console.WriteLine();
            }
        }

        private static void BeirElem(byte x, byte y)
        {
            if (vaksag || fedettTerkep)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(matrix[x, y]);
                return;
            }
            if (matrix[x, y] == '.')
                Console.ForegroundColor = (ConsoleColor)szin.UresHelySzine;
            else
                Console.ForegroundColor = (ConsoleColor)szin.LabirintusSzine;
            Console.Write(matrix[x, y]);
            if (matrix[x, y] == '█')
                termekSzama++;

        }

        private static byte[] GombNyomas(ref byte[] koord, byte nyomottGomb)
        {
            
            //FEL
            if (gombok.Fel == nyomottGomb)
            {
                if (kijuthat && koord[1] == 0 && "╬╩║╣╠╝╚█▓".Contains(matrix[koord[0], koord[1]]))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(szoveg.Gratulalok);
                    bentvan = false;
                    return koord;
                }
                if (koord[1] > 0 && "╬╩║╣╠╝╚█▓".Contains(matrix[koord[0], koord[1]]) && "╬╦║╣╠╗╔█▓".Contains(matrix[koord[0], koord[1] - 1]))
                {
                    Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                    if (vaksag || fenyveszto)
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[1]--;
                }
                return koord;
            }
            //LE
            else if (gombok.Le == nyomottGomb)
            {
                if (kijuthat && koord[1] == matrix.GetLength(1)-1 && "╬╦║╣╠╗╔█▓".Contains(matrix[koord[0], koord[1]]))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Gratulálunk, kivitted a játékot");
                    bentvan = false;
                    return koord;
                }
                if (koord[1] + 1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█▓".Contains(matrix[koord[0], koord[1]]) && "╬╩║╣╠╝╚█▓".Contains(matrix[koord[0], koord[1] + 1]))
                {
                    Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                    if (vaksag || fenyveszto)
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[1]++;
                }
                return koord;
            }
            //BAL
            

            else if (gombok.Bal == nyomottGomb)
            {
                if (kijuthat && koord[0] == 0 && "╬═╦╩╣╗╝█▓".Contains(matrix[koord[0], koord[1]]))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Gratulálunk, kivitted a játékot");
                    bentvan = false;
                    return koord;
                }
                if (koord[0] > 0 && "╬═╦╩╣╗╝█▓".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╠╚╔█▓".Contains(matrix[koord[0] - 1, koord[1]]))
                {
                    Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                    if (vaksag || fenyveszto)
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[0]--;
                }
                return koord;
            }
            //JOBB
            else if (gombok.Jobb == nyomottGomb)
            {
                if (kijuthat && koord[0] == matrix.GetLength(0)-1 && "╬═╦╩╠╚╔█▓".Contains(matrix[koord[0], koord[1]]))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Gratulálunk, kivitted a játékot");
                    bentvan = false;
                    return koord;
                }
                if (koord[0] + 1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█▓".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╣╗╝█▓".Contains(matrix[koord[0] + 1, koord[1]]))
                {
                    Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                    if (vaksag || fenyveszto)
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.Write(matrix[koord[0], koord[1]]);
                    koord[0]++;
                }
                return koord;
            }
            
            return koord;
            

                
        }
        private static void KezdoEllenorzes()
        {
        for (byte sor = 0; sor <  matrix.GetLength(0); sor++)
            {
                if ("╬╩║╣╠╝╚█".Contains(matrix[sor, 0]))
                    szelsokoordianata.Add(new byte[] { sor, 0});
                if ("╬╦║╣╠╗╔█".Contains(matrix[sor, matrix.GetLength(1)-1]))
                    szelsokoordianata.Add(new byte[] { sor, (byte)(matrix.GetLength(1)-1)});
            }
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                if ("╬═╦╩╣╗╝█".Contains(matrix[0, oszlop]))
                    szelsokoordianata.Add(new byte[] { 0, oszlop});
                if ("╬═╦╩╠╚╔█".Contains(matrix[matrix.GetLength(0)-1,oszlop]))
                    szelsokoordianata.Add(new byte[] {(byte)(matrix.GetLength(0)-1),oszlop });
            }
        }
      
        private static void Mozgas()
        {
            Random rand = new();
            KezdoEllenorzes();
            koord = szelsokoordianata[rand.Next(0,szelsokoordianata.Count)];
            Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            while (bentvan)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                    if (matrix[koord[0], koord[1]] == '█')
                    { 
                felfedezettTermek++;
                    matrix[koord[0], koord[1]] = '▓';
                    }
                if (termekSzama == felfedezettTermek)                
                    kijuthat = true;
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
                if (koord[1] > 0 && "╬╩║╣╠╝╚█▓".Contains(matrix[koord[0], koord[1]]) && "╬╦║╣╠╗╔█▓".Contains(matrix[koord[0], koord[1]-1])) Console.Write(szoveg.Iranyok[0]);
                if (koord[1]+1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█▓".Contains(matrix[koord[0], koord[1]]) && "╬╩║╣╠╝╚█▓".Contains(matrix[koord[0], koord[1]+1])) Console.Write(szoveg.Iranyok[1]);
                if (koord[0] > 0 && "╬═╦╩╣╗╝█▓".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╠╚╔█▓".Contains(matrix[koord[0]-1, koord[1]])) Console.Write(szoveg.Iranyok[2]);
                if (koord[0]+1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█▓".Contains(matrix[koord[0], koord[1]]) && "╬═╦╩╣╗╝█▓".Contains(matrix[koord[0]+1, koord[1]])) Console.Write(szoveg.Iranyok[3]);
            }
            else
                Console.Write(szoveg.VakVagy);
            Console.SetCursorPosition(0, 2);
            Console.Write($"{szoveg.Informaciok[3]}: {felfedezettTermek}");
        }
    }
}