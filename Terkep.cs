using System;
using System.Collections.Generic;

namespace Program
{
    class T
    {
        public static bool vege = false;
        public static string fel = "╬╦║╣╠╗╔";
        public static string le  = "╬╩║╣╠╝╚";
        public static string jobb= "╬═╦╩╣╗╝";
        public static string bal = "╬═╦╩╠╚╔";
        public static char[,] karakterek = { { '╬', '╬', '╬', '╬'}, { '╦', '╣', '╩', '╠'}, { '╗', '╝', '╚', '╔'}, { '║', '═', '║', '═'}, { '█', '█', '█', '█' } };
        public static char[,] matrix = new char[10, 10];
        //public static char[,] matrix = new char[tombHossz[0], tombHossz[1]];

        public static void TerkepMain()
        {

            //Console.Write("Adja meg az x és y koordinátát ;-vel elválasztva (x;y): ");
            //byte[] tombHossz = Methods.Koordinata(Console.ReadLine());
            byte[] koord = { 0, 0 };


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';


            Console.Clear();
            PalyaRajzol();
            ElemekRajzol();


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);

            byte hanyadik = 0, forgatas = 0;
            while(!vege)
            {
                Console.Write(karakterek[hanyadik, forgatas]);
                Koordinata(koord);
                Console.SetCursorPosition(KeyPressed(ref koord, ref hanyadik, ref forgatas)[1], koord[0]);
            }

            Ellenorzes();
            Console.ReadLine();
        }

        static void PalyaRajzol()
        {
            Console.SetCursorPosition(0, 0);
            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
            {
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
        }

        static void ElemekRajzol()
        {
            for (byte index = 0; index < 7; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0 + 7 * index, matrix.GetLength(0) + 5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(0 + 7 * index, matrix.GetLength(0) + 6);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("╬╦╗║█↺↻"[index]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ║");
                Console.SetCursorPosition(0 + 7 * index, matrix.GetLength(0) + 7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(0 + 7 * index, matrix.GetLength(0) + 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {"12345QE"[index]}");
            }
        }

        static byte[] KeyPressed(ref byte[] koord, ref byte index, ref byte forgatas)
        {
            switch (Console.ReadKey(true).Key)
            {
                //MOZATGÁS
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(koord[1], koord[0]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[0]==0)
                        return koord;
                    koord[0]--;
                    return koord;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(koord[1], koord[0]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[0]==matrix.GetLength(1)-1)
                        return koord;
                    koord[0]++;
                    return koord;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(koord[1], koord[0]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[1]==0)
                        return koord;
                    koord[1]--;
                    return koord;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(koord[1], koord[0]);
                    Console.Write(matrix[koord[0], koord[1]]);
                    if (koord[1]==matrix.GetLength(0)-1)
                        return koord;
                    koord[1]++;
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

        static bool Ellenorzes()
        {
            string koord = Methods.Koordinata(0, 0);
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

                    foreach (string mezo in Szomszedok(Methods.Koordinata(koord)))
                    {
                        if (!meglatogatott.Contains(mezo))
                            vizsgalandok.Add(mezo);
                    }
                }
            }


            foreach (string mezo in meglatogatott)
            {
                byte[] koordinata = Methods.Koordinata(mezo);
                if (matrix[koordinata[0], koordinata[1]] == '█')
                    Console.WriteLine("VAN!!");
                Console.WriteLine(mezo);
            }

            return true;
        }

        static List<string> Szomszedok(byte[] koord)
        {
            List<string> szomszedok = new List<string>();
            byte[] temp;

            //jobb
            if(koord[0]+1<matrix.GetLength(0) && jobb.Contains(matrix[koord[0]+1, koord[1]]))
            {
                temp = koord;
                szomszedok.Add(Methods.Koordinata((byte)(temp[0]+1), temp[1]));
            }
            //bal
            if(koord[0]>0 && bal.Contains(matrix[koord[0]-1, koord[1]]))
            {
                temp = koord;
                szomszedok.Add(Methods.Koordinata((byte)(temp[0]-1), temp[1]));
            }
            //fel
            if(koord[1]>0 && fel.Contains(matrix[koord[0], koord[1]-1]))
            {
                temp = koord;
                szomszedok.Add(Methods.Koordinata(temp[0], (byte)(temp[1]-1)));
            }
            //le
            if(koord[1]+1<matrix.GetLength(1) && le.Contains(matrix[koord[0], koord[1]+1]))
            {
                temp = koord;
                szomszedok.Add(Methods.Koordinata(temp[0], (byte)(temp[1]+1)));
            }


            return szomszedok;
        }
        
        static void Koordinata(byte[] koord)
        {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine($"{koord[0]}; {koord[1]}");
        }
    }
}