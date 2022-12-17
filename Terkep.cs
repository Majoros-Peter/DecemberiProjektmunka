using System;
using System.Collections.Generic;
using System.IO;
using Methods;

namespace Terkep
{
    class T
    {
        private static bool vege = false;
        private static char[,] karakterek = { { '║', '═', '║', '═' }, { '╗', '╝', '╚', '╔'}, { '╦', '╣', '╩', '╠' }, { '╬', '╬', '╬', '╬' }, { '█', '█', '█', '█' } };
        private static char[,] matrix;
        private static byte bekezdes;
        private static string mappa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - "\\bin\\Debug\\net6.0".Length);
        private static Random rnd = new Random();

        public static void TerkepMain()
        {
            Console.Clear();
            Console.Write("[s]aját pálya készítése\n[g]enerálás\n[m]eglévő pályán módosítás");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    SajatPalya();
                    break;
                case ConsoleKey.G:
                    GeneralPalya();
                    break;
                case ConsoleKey.M:
                    MeglevoModositas();
                    break;
            }
        }

        private static void SajatPalya()
        {
            byte[] szelMag = BekerKoordinata("Adja meg a pálya hosszát ;-vel elválasztva (szélesség;magasság): "), koord = { 0, 0 };
            matrix = new char[szelMag[0], szelMag[1]];
            bekezdes = (byte)((Console.WindowWidth-szelMag[0])/2);
            GC.Collect();   //Meghívja a GarbageCollectort.


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
            PalyaRajzol();


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
                Beker:

                Console.Clear();
                Console.Write("Adja meg a pálya nevét a mentéshez: ");
                string eleresiUt = Console.ReadLine();

                if(File.Exists(String.Join("",mappa,"\\",eleresiUt,".txt")))
                {
                    Console.Clear();
                    Console.Write("Ilyen nevű pálya már létezik, biztosan felül akarod írni (I/N)?");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.I:
                            Console.Clear();
                            break;
                        case ConsoleKey.N:
                            goto Beker;
                    }
                }

                MentTerkepet(matrix, eleresiUt);
                Console.WriteLine($"Sikeres mentés!");
                return;
            }
        }

        //W.I.P
        private static void GeneralPalya()
        {
            byte[] szelMag = BekerKoordinata("Adja meg a pálya hosszát ;-vel elválasztva (szélesség;magasság): "), koord = BekerKoordinata("Adja meg a pálya kezdőkoordinátáját ;-vel elválasztva (x;y): ");
            matrix = new char[szelMag[0], szelMag[1]];


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
        }

        private static void MeglevoModositas()
        {
            Console.Write("Adja meg a pálya nevét amin változtatni szeretne: ");
            string eleresiUt = Console.ReadLine();
            matrix = Betolt(eleresiUt);
            bekezdes = (byte)((Console.WindowWidth-matrix.GetLength(0))/2);
            byte[] koord = { 0, 0 };

            Console.Clear();
            PalyaRajzol();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(bekezdes, 0);

            byte hanyadik = 4, forgatas = 0;
            while (!vege)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(KeyPressed(ref koord, ref hanyadik, ref forgatas)[0] + bekezdes, koord[1]);
            }

            if (Ellenorzes())
            {
                Console.Clear();
                MentTerkepet(matrix, eleresiUt);
                Console.WriteLine($"Sikeres mentés!");
            }
        }

        private static void PalyaRajzol()
        {
            byte bekezdes2 = (byte)((Console.WindowWidth-30)/2);
            
            Console.SetCursorPosition(0, 0);
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                for(byte i = 0; i < bekezdes; i++)
                    Console.Write(" ");
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
        

            for (byte index = 0; index < 5; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(7*index+bekezdes2, matrix.GetLength(1) + 5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(7*index+bekezdes2, matrix.GetLength(1) + 6);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("║╗╦╬█"[index]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ║");
                Console.SetCursorPosition(7*index+bekezdes2, matrix.GetLength(1) + 7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(7*index+bekezdes2, matrix.GetLength(1) + 8);
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
                vizsgalandok.RemoveAt(0);

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

        private static void MentTerkepet(char[,] palya, string palyaNeve)
        {
            string[] sorok = new string[palya.GetLength(1)];

            for (byte sor = 0; sor < palya.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < sorok.Length; oszlop++)
                    sorok[oszlop] += palya[sor, oszlop];

            File.WriteAllLines(String.Join("",mappa,"\\",palyaNeve,".txt"), sorok);
        }

        private static char[,] Betolt(string palyaNeve)
        {
            string[] sorok = File.ReadAllLines(String.Join("",mappa,"\\",palyaNeve,".txt"));
            char[,] palya = new char[sorok[0].Length, sorok.Length];

            for (int sor = 0; sor < palya.GetLength(0); sor++)
                for (int oszlop = 0; oszlop < palya.GetLength(1); oszlop++)
                    palya[sor, oszlop] = sorok[oszlop][sor];

            return palya;
        }

        private static byte[] BekerKoordinata(string szoveg)
        {
            Vissza:
            Console.Clear();
            Console.Write(szoveg);
            try
            {
                return M.Koordinata(Console.ReadLine());

            }catch
            {
                Console.WriteLine("Nem jó formában adta meg!");
                Console.ReadKey();
                goto Vissza;
            }
        }
    }
}
