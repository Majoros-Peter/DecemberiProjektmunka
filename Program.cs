using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            switch (Console.ReadLine())
            {
                case "jatek":
                    //Jatek.Jatek();
                    break;
                case "palya":
                    T.TerkepMain();
                    break;
                default:
                    T.TerkepMain();
                    break;
            }
        }
    }
}