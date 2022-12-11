using System;
using System.Collections.Generic;
using Methods;

namespace Terkep
{
    class T
    {
        private static bool vege = false;
        private static char[,] karakterek = { { '║', '═', '║', '═' }, { '╗', '╝', '╚', '╔'}, { '╦', '╣', '╩', '╠' }, { '╬', '╬', '╬', '╬' }, { '█', '█', '█', '█' } };
        private static char[,] matrix;
        private static byte bekezdes;
        private static Random rnd = new Random();

        public static void TerkepMain()
        {
            Console.Clear();
            Console.WriteLine("[s]aját pálya készítése\n[g]enerálás\n[m]eglévő pályán módosítás");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    SajatPalya();
                    break;
                case ConsoleKey.G:
                    Console.Clear();
                    GeneralPalya();
                    break;
                case ConsoleKey.M:
                    Console.Clear();
                    MeglevoModositas();
                    break;
            }
        }

        private static void SajatPalya()
        {

            Console.Write("Adja meg a pálya hosszát ;-vel elválasztva (szélesség;magasság): ");
            byte[] szelMag = M.Koordinata(Console.ReadLine());
            matrix = new char[szelMag[0], szelMag[1]];
            bekezdes = (byte)((Console.WindowWidth-szelMag[0])/2);
            byte[] koord = { 0, 0 };


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
            PalyaRajzol();
            ElemekRajzol();


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0+bekezdes, 0);

            byte hanyadik = 0, forgatas = 0;
            while(!vege)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(KeyPressed(ref koord, ref hanyadik, ref forgatas)[0]+bekezdes, koord[1]);
            }

            if(Ellenorzes())
            {
                Console.Clear();
                Console.Write("A pálya mentéséhez adja meg az elérési utat, és a nevét: ");
                MentTerkepet(matrix, Console.ReadLine());
            }
        }

        //W.I.P
        private static void GeneralPalya()
        {
            Console.Write("Adja meg a pálya hosszát ;-vel elválasztva (szélesség;magasság): ");
            byte[] szelMag = M.Koordinata(Console.ReadLine());
            matrix = new char[szelMag[0], szelMag[1]];
            Console.Write("Adja meg a pálya kezdőkoordinátáját ;-vel elválasztva (x;y): ");
            byte[] koord = M.Koordinata(Console.ReadLine());


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
        }

        //W.I.P
        private static void MeglevoModositas()
        {
            Console.WriteLine("W.I.P");
        }

        private static void PalyaRajzol()
        {
            Console.SetCursorPosition(0, 0);
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                for(byte i = 0; i < bekezdes; i++)
                    Console.Write(" ");
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
        }

        private static void ElemekRajzol()
        {
            byte bekezdes = (byte)((Console.WindowWidth-30)/2);
            for (byte index = 0; index < 5; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 6);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("║╗╦╬█"[index]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ║");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {"12345"[index]}");
            }
        }

        private static byte[] KeyPressed(ref byte[] koord, ref byte index, ref byte forgatas)
        {
            switch (Console.ReadKey(true).Key)
            {
                //MOZATGÁS
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(koord[0]+bekezdes, koord[1]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[1]==0)
                        return koord;
                    koord[1]--;
                    return koord;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(koord[0]+bekezdes, koord[1]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[1]==matrix.GetLength(1)-1)
                        return koord;
                    koord[1]++;
                    return koord;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(koord[0]+bekezdes, koord[1]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[0]==0)
                        return koord;
                    koord[0]--;
                    return koord;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(koord[0]+bekezdes, koord[1]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[0]==matrix.GetLength(0)-1)
                        return koord;
                    koord[0]++;
                    return koord;


                //ELEM KIVÁLASZTÁS
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    forgatas=0;
                    index=0;
                    return koord;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    forgatas=0;
                    index=1;
                    return koord;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    forgatas=0;
                    index=2;
                    return koord;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    forgatas=0;
                    index=3;
                    return koord;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    forgatas = 0;
                    index=4;
                    return koord;


                //FORGATÁS
                case ConsoleKey.Q:
                    if(forgatas==0)
                        forgatas=4;
                    forgatas--;
                    return koord;
                case ConsoleKey.E:
                    forgatas++;
                    forgatas%=4;
                    return koord;


                //LERAKÁS
                case ConsoleKey.Enter:
                    matrix[koord[0], koord[1]] = karakterek[index, forgatas];
                    PalyaRajzol();
                    return koord;


                //KLÉPÉS
                case ConsoleKey.Escape:
                    vege=true;
                    return koord;


                default:
                    return koord;
            }
        }

        private static bool Ellenorzes()
        {
            string koord = M.Koordinata(0, 0);
            List<string> meglatogatott = new List<string>();
            List<string> vizsgalandok = new List<string>() { koord };


            while (vizsgalandok.Count > 0)
            {
                string vizsgalando = vizsgalandok.Last();
                vizsgalandok.RemoveAt(vizsgalandok.Count - 1);

                if (!meglatogatott.Contains(vizsgalando))
                {
                    koord = vizsgalando;

                    meglatogatott.Add(vizsgalando);

                    foreach (string mezo in Szomszedok(M.Koordinata(koord)))
                    {
                        if (!meglatogatott.Contains(mezo))
                            vizsgalandok.Add(mezo);
                    }
                }
            }


            byte[] koordinata;
            foreach (string mezo in meglatogatott)
            {
                koordinata = M.Koordinata(mezo);
                if (matrix[koordinata[0], koordinata[1]] == '█')
                    return true;
            }

            return false;
        }

        private static List<string> Szomszedok(byte[] koord)
        {
            List<string> szomszedok = new List<string>();
            byte x = koord[0], y = koord[1];
            byte[] temp;

            //jobb
            if(koord[0]+1<matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[x, y]) && "╬═╦╩╣╗╝█".Contains(matrix[x+1, y]))
            {
                temp = koord;
                szomszedok.Add(M.Koordinata((byte)(temp[0]+1), temp[1]));
            }
            //le
            if(koord[1]+1<matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[x, y]) && "╬╩║╣╠╝╚█".Contains(matrix[x, y+1]))
            {
                temp = koord;
                szomszedok.Add(M.Koordinata(temp[0], (byte)(temp[1]+1)));
            }
            //bal
            if(koord[0]>0 && "╬═╦╩╣╗╝█".Contains(matrix[x, y]) && "╬═╦╩╠╚╔█".Contains(matrix[x-1, y]))
            {
                temp = koord;
                szomszedok.Add(M.Koordinata((byte)(temp[0]-1), temp[1]));
            }
            //fel
            if(koord[1]>0 && "╬╩║╣╠╝╚█".Contains(matrix[x, y]) && "╬╦║╣╠╗╔█".Contains(matrix[x, y-1]))
            {
                temp = koord;
                szomszedok.Add(M.Koordinata(temp[0], (byte)(temp[1]-1)));
            }


            return szomszedok;
        }
        
        private static void KiirKoordinata(byte[] koord)
        {
            Console.SetCursorPosition(bekezdes, matrix.GetLength(1)+2);
            Console.Write("       ");
            Console.SetCursorPosition(bekezdes, matrix.GetLength(1)+2);
            Console.WriteLine($"{koord[0]};{koord[1]}");
        }

        private static void MentTerkepet(char[,] palya, string palyaNeve)
        {
            string[] sorok = new string[palya.GetLength(1)];

            for (byte oszlop = 0; oszlop < palya.GetLength(0); oszlop++)
                for (byte sor = 0; sor < sorok.Length; sor++)
                    sorok[sor] += palya[oszlop, sor];
            File.WriteAllLines(palyaNeve, sorok);
        }
    }
}