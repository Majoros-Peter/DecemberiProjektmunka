using System;

namespace Program
{
    class T
    {
        public static void TerkepMain()
        {
            Random rnd= new Random();
            
            Console.Write("Adja meg az x és y koordinátát ;-vel elválasztva (x;y): ");
            byte[] tombHossz = Methods.Koordinata(Console.ReadLine());
            char[,] matrix = new char[tombHossz[0], tombHossz[1]];
            byte[] koord = { 0, 0 };

            string fel = "╬╦║╣╠╗╔";
            string le  = "╬╩║╣╠╝╚";
            string jobb= "╬═╦╩╣╗╝";
            string bal = "╬═╦╩╠╚╔";
            string karakterek = "╬╦╩═║╣╠╗╔╝╚";


            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    matrix[sor, oszlop] = '.';

            Console.Clear();

            Rajzol(matrix);
            HUD(matrix, karakterek);

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;

            byte hanyadik = 0;
            while(true)
            {
                Console.Write(karakterek[hanyadik]);
                Console.SetCursorPosition(KeyPressed(ref koord, matrix, ref hanyadik)[0], koord[1]);
                matrix[koord[0], koord[1]] = karakterek[hanyadik];
            }
        }

        static void Rajzol(char[,] matrix)
        {
            for (byte sor = 0; sor < matrix.GetLength(0); sor++)
            {
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
        }


        static void HUD(char[,] matrix, string karakterek)
        {
            for(byte index = 0; index < karakterek.Length; index++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0+7*index, matrix.GetLength(0) + 5);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(0+7*index, matrix.GetLength(0) + 6);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(karakterek[index]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ║");
                Console.SetCursorPosition(0+7*index, matrix.GetLength(0) + 7);
                Console.Write("╚═══╝");
                Console.SetCursorPosition(0+7*index, matrix.GetLength(0) + 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {Convert.ToChar(index+97)}");
            }
        }


        static byte[] KeyPressed(ref byte[] arr, char[,] matrix, ref byte index)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (arr[1]==0)
                        return arr;
                    arr[1]--;
                    break;
                case ConsoleKey.DownArrow:
                    if (arr[1]==matrix.GetLength(1)-1)
                        return arr;
                    arr[1]++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (arr[0]==0)
                        return arr;
                    arr[0]--;
                    break;
                case ConsoleKey.RightArrow:
                    if (arr[0]==matrix.GetLength(0)-1)
                        return arr;
                    arr[0]++;
                    break;


                case ConsoleKey.A:
                    index=0;
                    return arr;
                case ConsoleKey.B:
                    index=1;
                    return arr;
                case ConsoleKey.C:
                    index=2;
                    return arr;
                case ConsoleKey.D:
                    index=3;
                    return arr;
                case ConsoleKey.E:
                    index=4;
                    return arr;
                case ConsoleKey.F:
                    index=5;
                    return arr;
                case ConsoleKey.G:
                    index=6;
                    return arr;
                case ConsoleKey.H:
                    index=7;
                    return arr;
                case ConsoleKey.I:
                    index=8;
                    return arr;
                case ConsoleKey.J:
                    index=9;
                    return arr;
            }
            return arr;
        }
    }
}