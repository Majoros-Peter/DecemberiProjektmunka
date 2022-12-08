using System;
using System.Collections.Generic;

namespace Program
{
    class Terkep
    {
        static void Main(string[] args)
        {
            Random ran= new Random();
            List<char> jobbraLehet= new List<char>() { '╬', '═', '╦', '╩', '╣','╗', '╝'};
            List<char> leLehet = new List<char>() { '╬', '╩', '║', '╣', '╠','╝', '╚'};
            List<char> balraLehet = new List<char>() { '╬', '═', '╦', '╩', '╠', '╚', '╔' };
            List<char> felLehet = new List<char>() { '╬','╦',  '║', '╣', '╠', '╗', '╔' };

            Console.Write("Adja meg az x és y koordinátát:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
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
