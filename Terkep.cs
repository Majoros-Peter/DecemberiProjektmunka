using Methods;

namespace Terkep
{
    class T
    {
        private static bool vege = false;
        private static char[,] karakterek = { { '.', '.', '.', '.' }, { '║', '═', '║', '═' }, { '╗', '╝', '╚', '╔'}, { '╦', '╣', '╩', '╠' }, { '╬', '╬', '╬', '╬' }, { '█', '█', '█', '█' } };
        private static char[,] matrix;
        private static byte bekezdes;
        private static string mappa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - "\\bin\\Debug\\net6.0".Length);

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

            for (byte sor = 0; sor < szelMag[0]; sor++)
                for (byte oszlop = 0; oszlop < szelMag[1]; oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
            PalyaRajzol();
            Elemek();


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(bekezdes, 0);

            byte hanyadik = 4, forgatas = 0;
            while(!vege)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(KeyPressed(ref koord, ref hanyadik, ref forgatas)[0]+bekezdes, koord[1]);
            }

            if(Ellenorzes())
            {
                Console.ForegroundColor = ConsoleColor.White;
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

                MentTerkepet(eleresiUt);
                Console.WriteLine($"Sikeres mentés!");
                return;
            }
        }

        private static void GeneralPalya()
        {
            byte[] szelMag = BekerKoordinata("Adja meg a pálya hosszát ;-vel elválasztva (szélesség;magasság): "), koord = BekerKoordinata("Adja meg a pálya kezdőkoordinátáját ;-vel elválasztva (x;y): ");
            matrix = new char[szelMag[0], szelMag[1]];
            bekezdes = (byte)((Console.WindowWidth-szelMag[0])/2);


            for (byte sor = 0; sor < szelMag[0]; sor++)
                for (byte oszlop = 0; oszlop < szelMag[1]; oszlop++)
                    matrix[sor, oszlop] = '.';

            matrix[koord[0], koord[1]] = '╬';


            Console.Clear();
            General(M.Koordinata(koord));
            Elemek();


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
                Console.ForegroundColor = ConsoleColor.White;
            Beker:

                Console.Clear();
                Console.Write("Adja meg a pálya nevét a mentéshez: ");
                string eleresiUt = Console.ReadLine();

                if (File.Exists(String.Join("", mappa, "\\", eleresiUt, ".txt")))
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

                MentTerkepet(eleresiUt);
                Console.WriteLine($"Sikeres mentés!");
                return;
            }
        }

        private static void MeglevoModositas()
        {
            Console.Clear();
            Console.Write("Adja meg a pálya nevét amin változtatni szeretne: ");
            string eleresiUt = Console.ReadLine();
            matrix = Betolt(eleresiUt);
            bekezdes = (byte)((Console.WindowWidth-matrix.GetLength(0))/2);
            byte[] koord = { 0, 0 };


            Console.Clear();
            PalyaRajzol();
            Elemek();


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
                MentTerkepet(eleresiUt);
                Console.WriteLine($"Sikeres mentés!");
            }
        }

        private static void PalyaRajzol()
        {
            Console.SetCursorPosition(0, 0);
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                for (byte i = 0; i < bekezdes; i++)
                    Console.Write(" ");
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
        }

        private static void Elemek()
        {
            byte bekezdes = (byte)((Console.WindowWidth - 40) / 2);
            for (byte index = 0; index < 6; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 6);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(".║╗╦╬█"[index]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ║");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1) + 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {"012345"[index]}");
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
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    forgatas = 0;
                    index = 0;
                    return koord;
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    forgatas=0;
                    index=1;
                    return koord;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    forgatas=0;
                    index=2;
                    return koord;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    forgatas=0;
                    index=3;
                    return koord;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    forgatas=0;
                    index=4;
                    return koord;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    forgatas = 0;
                    index=5;
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

        private static void General(string koord)
        {
            List<string> meglatogatott = new(), vizsgalandok = new() { koord };
            
            for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
            {
                for (byte i = 0; i < bekezdes; i++)
                    Console.Write(" ");
                for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }

            while(vizsgalandok.Count > 0)
            {
                string vizsgalando = vizsgalandok.Last();
                vizsgalandok.RemoveAt(vizsgalandok.Count-1);

                if(!meglatogatott.Contains(vizsgalando))
                {
                    koord = vizsgalando;

                    meglatogatott.Add(vizsgalando);

                    foreach (string mezo in MelleRak(M.Koordinata(koord)))
                    {
                        if (!meglatogatott.Contains(mezo))
                            vizsgalandok.Add(mezo);
                    }
                }
            }
        }

        public static List<string> MelleRak(byte[] koord)
        {
            List<string> szomszedok = new();
            byte x = koord[0], y = koord[1];
            Random rnd = new();


            //jobb
            if (x+1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[x, y]) && matrix[x+1, y] == '.' && rnd.Next(matrix.GetLength(0)*2) > 0)
            {
                szomszedok.Add(M.Koordinata((byte)(x+1), y));
                BeirMatrixba("╬══════════╦╩╣╦╩╣╗╝╗╝╗╝"[rnd.Next(23)], (byte)(x+1), y);
                Thread.Sleep(100);
            }

            //le
            if (y+1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[x, y]) && matrix[x, y+1] == '.' && rnd.Next(matrix.GetLength(1)*2) > 0)
            {
                szomszedok.Add(M.Koordinata(x, (byte)(y+1)));
                BeirMatrixba("╬║║║║║║║║║║╩╣╠╩╣╠╝╚╝╚╝╚"[rnd.Next(23)], x, (byte)(y+1));
                Thread.Sleep(100);
            }
            
            //bal
            if (x > 0 && "╬═╦╩╣╗╝█".Contains(matrix[x, y]) && matrix[x-1, y] == '.' && rnd.Next(matrix.GetLength(0)*2) > 0)
            {
                szomszedok.Add(M.Koordinata((byte)(x-1), y));
                BeirMatrixba("╬══════════╦╩╠╦╩╠╚╔╚╔╚╔"[rnd.Next(23)], (byte)(x-1), y);
                Thread.Sleep(100);
            }
            
            //fel
            if (y > 0 && "╬╩║╣╠╝╚█".Contains(matrix[x, y]) && matrix[x, y-1] == '.' && rnd.Next(matrix.GetLength(1)*2) > 0)
            {
                szomszedok.Add(M.Koordinata(x, (byte)(y-1)));
                BeirMatrixba("╬║║║║║║║║║║╠╦╣╠╦╣╔╗╔╗╔╗"[rnd.Next(23)], x, (byte)(y-1));
                Thread.Sleep(100);
            }


            return szomszedok;
        }

        private static bool Ellenorzes()
        {
            string koord = M.Koordinata(BekerKoordinata("Adja meg a labirintus kezdőkoordinátáját ;-vel elválasztva: ")); //Azért kell mind a 2 koordinátás függvény, mert csak az egyikben van hibaellenőrzés.
            List<string> meglatogatott = new(), vizsgalandok = new() { koord };

            Console.Clear();
            PalyaRajzol();
            Elemek();

            Console.ForegroundColor = ConsoleColor.Green;

            while (vizsgalandok.Count > 0)
            {
                string vizsgalando = vizsgalandok.Last();
                vizsgalandok.RemoveAt(vizsgalandok.Count-1);

                if (!meglatogatott.Contains(vizsgalando))
                {
                    koord = vizsgalando;

                    byte[] seged = M.Koordinata(koord);
                    Console.SetCursorPosition(bekezdes + seged[0], seged[1]);
                    Console.Write(matrix[seged[0], seged[1]]);
                    Thread.Sleep(100);

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
            List<string> szomszedok = new();
            byte x = koord[0], y = koord[1];

            //jobb
            if(x+1<matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[x, y]) && "╬═╦╩╣╗╝█".Contains(matrix[x+1, y]))
                szomszedok.Add(M.Koordinata((byte)(x+1), y));
            //le
            if(y+1<matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[x, y]) && "╬╩║╣╠╝╚█".Contains(matrix[x, y+1]))
                szomszedok.Add(M.Koordinata(x, (byte)(y+1)));
            //bal
            if(x>0 && "╬═╦╩╣╗╝█".Contains(matrix[x, y]) && "╬═╦╩╠╚╔█".Contains(matrix[x-1, y]))
                szomszedok.Add(M.Koordinata((byte)(x-1), y));
            //fel
            if(y>0 && "╬╩║╣╠╝╚█".Contains(matrix[x, y]) && "╬╦║╣╠╗╔█".Contains(matrix[x, y-1]))
                szomszedok.Add(M.Koordinata(x, (byte)(y-1)));


            return szomszedok;
        }

        private static void MentTerkepet(string palyaNeve)
        {
            string[] sorok = new string[matrix.GetLength(1)];

            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < sorok.Length; oszlop++)
                    sorok[oszlop] += matrix[sor, oszlop];

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

        private static void BeirMatrixba(char karakter, byte x, byte y)
        {
            Console.SetCursorPosition(bekezdes + x, y);
            matrix[x, y] = karakter;
            Console.Write(matrix[x, y]);
        }
    }
}
