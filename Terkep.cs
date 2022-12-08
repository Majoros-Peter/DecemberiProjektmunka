using System;
using System.Collections.Generic;

namespace Program
{
    class Terkep
    {
        static void Main(string[] args)
        {
            Random ran= new Random();
            char[] fel =   { '╬', '╦', '║', '╣', '╠', '╗', '╔' };
            char[] le =    { '╬', '╩', '║', '╣', '╠', '╝', '╚' };
            char[] jobb= { '╬', '═', '╦', '╩', '╣', '╗', '╝' };
            char[] bal = { '╬', '═', '╦', '╩', '╠', '╚', '╔' };

            Console.Write("Adja meg az x és y koordinátát:");
            byte x = Console.ReadLine();
            byte y = Console.ReadLine();
            char[,] matrix = new char[x, y];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '.';
                }
            }

            Console.WriteLine("Adja meg, hogy melyik oldalon szeretne kezdeni: ");
            switch (Console.ReadLine())
            {
                case "j":
                    Console.WriteLine("Hanyadik számú karakterrel kezdene? ");
                    for (int i = 0; i < balraLehet.Count; i++)
                    {
                        Console.Write(balraLehet[i]);
                    }
                    
                default:
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
}
