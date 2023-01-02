namespace Labirintus
{
    class T
    {
        private static bool vege = false;
        private static byte oldalBekezdes, felsoBekezdes = 3;
        private static char[,] karakterek = { { '.', '.', '.', '.' }, { '║', '═', '║', '═' }, { '╗', '╝', '╚', '╔' }, { '╦', '╣', '╩', '╠' }, { '╬', '╬', '╬', '╬' }, { '█', '█', '█', '█' } }, matrix;
        private static Nyelv szoveg = Adatok.szoveg;
        private static Gombok gombok = Adatok.gombok;

        public static void TerkepMain() => M.Valaszt(new string[] { szoveg.Sajat, szoveg.General, szoveg.Modositas, szoveg.Vissza }, new Action[] { SajatPalya, GeneralPalya, MeglevoModositas,  P.Valaszt}, szoveg.Cim[2]);
            
        private static void SajatPalya()
        {
            Console.ForegroundColor = Adatok.szovegSzine;
            byte[] szelMag = BekerKoordinata(szoveg.BekerMeret), koord = { 0, 0 };
            matrix = new char[szelMag[0], szelMag[1]];
            oldalBekezdes = (byte)((Console.WindowWidth-szelMag[0])/2);

            for (byte sor = 0; sor < szelMag[0]; sor++)
                for (byte oszlop = 0; oszlop < szelMag[1]; oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
            PalyaRajzol();
            Elemek();


            Console.SetCursorPosition(oldalBekezdes, felsoBekezdes);

            byte hanyadik = 4, forgatas = 0;
            while(!vege)
            {
                Console.ForegroundColor = Adatok.kivalasztottSzine;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.SetCursorPosition(GombNyomas(ref koord, ref hanyadik, ref forgatas, (byte)Console.ReadKey(true).Key)[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            }

            if(Ellenorzes())
            {
                Console.ForegroundColor = Adatok.szovegSzine;
                Beker:

                Console.Clear();
                Console.Write(szoveg.BekerPalyaNev[0]);
                string eleresiUt = Console.ReadLine();

                if(File.Exists($"{Adatok.mappa}/{eleresiUt}.txt"))
                {
                    Console.Clear();
                    Console.Write(szoveg.LetezoPalya);
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
                return;
            }
        }

        private static void GeneralPalya()
        {
            byte[] szelMag = BekerKoordinata(szoveg.BekerMeret), koord = BekerKoordinata(szoveg.BekerKoord);
            string kezdoKoord = M.Koordinata(koord);
            matrix = new char[szelMag[0], szelMag[1]];
            oldalBekezdes = (byte)((Console.WindowWidth-szelMag[0])/2);


            for (byte sor = 0; sor < szelMag[0]; sor++)
                for (byte oszlop = 0; oszlop < szelMag[1]; oszlop++)
                    matrix[sor, oszlop] = '.';

            matrix[koord[0], koord[1]] = '╬';


            Console.Clear();
            General(M.Koordinata(koord));
            Elemek();


            Console.SetCursorPosition(koord[0]+oldalBekezdes, koord[1]+felsoBekezdes);

            byte hanyadik = 4, forgatas = 0;
            while (!vege)
            {
                Console.ForegroundColor = Adatok.kivalasztottSzine;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.SetCursorPosition(GombNyomas(ref koord, ref hanyadik, ref forgatas, (byte)Console.ReadKey(true).Key)[0]+oldalBekezdes, koord[1]+felsoBekezdes);
            }

            if (Ellenorzes(kezdoKoord))
            {
                Console.ForegroundColor = Adatok.szovegSzine;

                Beker:
                Console.Clear();
                Console.Write(szoveg.BekerPalyaNev[0]);
                string eleresiUt = Console.ReadLine();

                if (File.Exists($"{Adatok.mappa}/{eleresiUt}.txt"))
                {
                    Console.Clear();
                    Console.Write(szoveg.LetezoPalya);
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
                return;
            }
        }

        private static void MeglevoModositas()
        {
            Console.Clear();
            Console.Write(szoveg.BekerPalyaNev[1]);
            string eleresiUt = Console.ReadLine();
            matrix = Betolt(eleresiUt);
            oldalBekezdes = (byte)((Console.WindowWidth-matrix.GetLength(0))/2);
            byte[] koord = { 0, 0 };


            Console.Clear();
            PalyaRajzol();
            Elemek();


            Console.SetCursorPosition(oldalBekezdes, felsoBekezdes);

            byte hanyadik = 4, forgatas = 0;
            while (!vege)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(karakterek[hanyadik, forgatas]);
                Console.SetCursorPosition(GombNyomas(ref koord, ref hanyadik, ref forgatas, (byte)Console.ReadKey(true).Key)[0] + oldalBekezdes, koord[1]+felsoBekezdes);
            }

            if (Ellenorzes())
            {
                Console.Clear();
                MentTerkepet(eleresiUt);
            }
        }

        private static void PalyaRajzol()
        {
            Console.ForegroundColor = Adatok.labirintusKeretSzine;
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

        private static void Elemek()
        {
            byte bekezdes = (byte)((Console.WindowWidth - 40) / 2);
            for (byte index = 0; index < 6; index++)
            {
                Console.ForegroundColor = Adatok.elemKereteSzine;
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1)+5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1)+6);
                Console.Write("║ ");
                Console.ForegroundColor = Adatok.elemSzine;
                Console.Write(".║╗╦╬█"[index]);
                Console.ForegroundColor = Adatok.elemKereteSzine;
                Console.Write(" ║");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1)+7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(7*index+bekezdes, matrix.GetLength(1)+8);
                Console.ForegroundColor = Adatok.elemSorszamSzine;
                Console.Write($"  {index}");
            }
        }

        private static byte[] GombNyomas(ref byte[] koord, ref byte index, ref byte forgatas, byte input)
        {
            //MOZGATÁS
            //FEL
            if (gombok.Fel == input)
            {
                Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                BeirElem(koord[0], koord[1]);
                if (koord[1] == 0)
                    return koord;
                koord[1]--;
            }
            //LE
            else if (gombok.Le == input)
            {
                Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                BeirElem(koord[0], koord[1]);
                if (koord[1] == matrix.GetLength(1) - 1)
                    return koord;
                koord[1]++;
            }
            //BAL     
            else if (gombok.Bal == input)
            {
                Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                BeirElem(koord[0], koord[1]);
                if (koord[0] == 0)
                    return koord;
                koord[0]--;
            }
            //JOBB
            else if (gombok.Jobb == input)
            {
                Console.SetCursorPosition(koord[0] + oldalBekezdes, koord[1] + felsoBekezdes);
                BeirElem(koord[0], koord[1]);
                if (koord[0] == matrix.GetLength(0) - 1)
                    return koord;
                koord[0]++;
            }
            //ELEM KIVÁLASZTÁS
            //0
            else if (gombok.ElemA0 == input || gombok.ElemB0 == input)
            {
                forgatas = 0;
                index = 0;
            }
            //1
            else if (gombok.ElemA1 == input || gombok.ElemB1 == input)
            {
                forgatas = 0;
                index = 1;
            }
            //2
            else if (gombok.ElemA2 == input || gombok.ElemB2 == input)
            {
                forgatas = 0;
                index = 2;
            }
            //3
            else if (gombok.ElemA3 == input || gombok.ElemB3 == input)
            {
                forgatas = 0;
                index = 3;
            }
            //4
            else if (gombok.ElemA4 == input || gombok.ElemB4 == input)
            {
                forgatas = 0;
                index = 4;
            }
            //5
            else if (gombok.ElemA5 == input || gombok.ElemB5 == input)
            {
                forgatas = 0;
                index = 5;
            }
            //FORGATÁS
            //-
            else if (gombok.Forgat1 == input)
            {
                if (forgatas == 0)
                    forgatas = 4;
                forgatas--;
            }
            //+
            else if (gombok.Forgat2 == input)
            {
                forgatas++;
                forgatas %= 4;
            }
            //LERAKÁS
            //ENTER
            else if(gombok.Lerak == input)
            {
                matrix[koord[0], koord[1]] = karakterek[index, forgatas];
            }
            //KILÉPÉS
            else if (gombok.Kilep == input)
                vege = true;
            else
                return koord;
            return koord;
        }

        private static void General(string koord)
        {
            List<string> meglatogatott = new(), vizsgalandok = new() { koord };

            PalyaRajzol();

            Console.ForegroundColor = Adatok.labirintusSzine;
            while(vizsgalandok.Count > 0)
            {
                string vizsgalando = vizsgalandok[0];
                vizsgalandok.RemoveAt(0);

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
            if (x+1 < matrix.GetLength(0) && "╬═╦╩╠╚╔█".Contains(matrix[x, y]) && matrix[x+1, y] == '.' && rnd.Next(matrix.GetLength(0)) > 0)
            {
                szomszedok.Add(M.Koordinata((byte)(x+1), y));
                BeirMatrixba("╬════════╦╩╣╦╩╣╗╝╗╝"[rnd.Next(19)], (byte)(x+1), y);
                Thread.Sleep(50);
            }

            //le
            if (y+1 < matrix.GetLength(1) && "╬╦║╣╠╗╔█".Contains(matrix[x, y]) && matrix[x, y+1] == '.' && rnd.Next(matrix.GetLength(1)) > 0)
            {
                szomszedok.Add(M.Koordinata(x, (byte)(y+1)));
                BeirMatrixba("╬║║║║║║║║╩╣╠╩╣╠╝╚╝╚"[rnd.Next(19)], x, (byte)(y+1));
                Thread.Sleep(50);
            }
            
            //bal
            if (x > 0 && "╬═╦╩╣╗╝█".Contains(matrix[x, y]) && matrix[x-1, y] == '.' && rnd.Next(matrix.GetLength(0)) > 0)
            {
                szomszedok.Add(M.Koordinata((byte)(x-1), y));
                BeirMatrixba("╬════════╦╩╠╦╩╠╚╔╚╔"[rnd.Next(19)], (byte)(x-1), y);
                Thread.Sleep(50);
            }
            
            //fel
            if (y > 0 && "╬╩║╣╠╝╚█".Contains(matrix[x, y]) && matrix[x, y-1] == '.' && rnd.Next(matrix.GetLength(1)) > 0)
            {
                szomszedok.Add(M.Koordinata(x, (byte)(y-1)));
                BeirMatrixba("╬║║║║║║║║╠╦╣╠╦╣╔╗╔╗"[rnd.Next(19)], x, (byte)(y-1));
                Thread.Sleep(50);
            }


            return szomszedok;
        }

        private static bool Ellenorzes(string koord="")
        {
            Console.ForegroundColor = Adatok.szovegSzine;
            if(koord == "")
                koord = M.Koordinata(BekerKoordinata(szoveg.BekerKoord, false)); //Azért kell mind a 2 koordinátás függvény, mert csak az egyikben van hibaellenőrzés.
            List<string> meglatogatott = new(), vizsgalandok = new() { koord };

            Console.Clear();
            PalyaRajzol();

            Console.ForegroundColor = Adatok.bejartLabirintusSzine;

            while (vizsgalandok.Count > 0)
            {
                string vizsgalando = vizsgalandok[0];
                vizsgalandok.RemoveAt(0);

                if (!meglatogatott.Contains(vizsgalando))
                {
                    koord = vizsgalando;

                    byte[] seged = M.Koordinata(koord);
                    Console.SetCursorPosition(seged[0]+oldalBekezdes, seged[1]+felsoBekezdes);
                    Console.Write(matrix[seged[0], seged[1]]);
                    Thread.Sleep(100);
                    if (matrix[seged[0], seged[1]] == '█')
                        return true;

                    meglatogatott.Add(vizsgalando);

                    foreach (string mezo in Szomszedok(M.Koordinata(koord)))
                    {
                        if (!meglatogatott.Contains(mezo))
                            vizsgalandok.Add(mezo);
                    }
                }
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

            File.WriteAllLines($"{Adatok.mappa}/{palyaNeve}.txt", sorok);
            Console.WriteLine(szoveg.SikeresMentes);
        }

        public static char[,] Betolt(string palyaNeve)
        {
            string[] sorok = File.ReadAllLines($"{Adatok.mappa}/{palyaNeve}.txt");
            char[,] palya = new char[sorok[0].Length, sorok.Length];

            for (int sor = 0; sor < palya.GetLength(0); sor++)
                for (int oszlop = 0; oszlop < palya.GetLength(1); oszlop++)
                    palya[sor, oszlop] = sorok[oszlop][sor];

            return palya;
        }

        private static byte[] BekerKoordinata(string szoveg1, bool torol=true)
        {
            Console.SetCursorPosition(0, 0);
            Vissza:
            if(torol) Torol();
            torol = true;
            Console.Write(szoveg1);
            
            try
            {
                return M.Koordinata(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine(szoveg.Hiba);
                Console.ReadKey();
                goto Vissza;
            }
        }

        private static void BeirMatrixba(char karakter, byte x, byte y)
        {
            Console.SetCursorPosition(x+oldalBekezdes, y+felsoBekezdes);
            matrix[x, y] = karakter;
            Console.Write(matrix[x, y]);
        }

        private static void BeirElem(byte x, byte y)
        {
            if (matrix[x, y] == '.')
                Console.ForegroundColor = Adatok.uresHelySzine;
            else
                Console.ForegroundColor = Adatok.labirintusSzine;
            Console.Write(matrix[x, y]);
        }

        private static void Torol()
        {
            Console.SetCursorPosition(0, 0);
            for (byte i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, 1);
            for (byte i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, 2);
            Console.Write("                              ");
            Console.SetCursorPosition(0, 0);
        }
    }
}