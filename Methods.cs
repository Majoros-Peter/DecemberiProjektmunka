namespace Labirintus
{
    class M
    {
        /// <summary>
        /// Megadja, hogy hány termet tartamaz a térkép
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Termek száma</returns>
        public static int GetRoomNumber(char[,] map)
        {
            int termekSzama = 0;
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                    if (map[sorIndex, oszlopIndex] == '█')
                        termekSzama++;
            return termekSzama;
        }
        /// <summary>
        /// A kapott térkép széleit végignézve megállapítja, hogy hány kijárat van.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Az alkalmas kijáratok száma</returns>
        public static int GetSuitableEntrance(char[,] map)
        {

            int kijaratokSzama = 0;
            for (byte sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                if ("╬╩║╣╠╝╚".Contains(map[sorIndex, 0]))
                    kijaratokSzama++;
                if ("╬╦║╣╠╗╔".Contains(map[sorIndex, map.GetLength(1) - 1]))
                    kijaratokSzama++;
            }
            for (byte oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
            {
                if ("╬═╦╩╣╗╝".Contains(map[0, oszlopIndex]))
                    kijaratokSzama++;
                if ("╬═╦╩╠╚╔".Contains(map[map.GetLength(0) - 1, oszlopIndex]))
                    kijaratokSzama++;
            }
            return kijaratokSzama;
        }
        /// <summary>
        /// Megnézi, hogy van-e a térképen meg nem engedett karakter?
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>true - A térkép tartalmaz szabálytalan karaktert, false - nincs benne ilyen</returns>
        public static bool IsInvalidElement(char[,] map)
        {
            bool karakterEllenorzo = true;
            char[] karakterekTombje = { '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█', '.' };
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                    if (karakterekTombje.Contains(map[sorIndex, oszlopIndex]))
                        karakterEllenorzo = true;
                    else
                        karakterEllenorzo = false;
            return karakterEllenorzo;
        }
        /// <summary>
        /// Visszaadja azoknak a járatkaraktereknek a pozícióját, amelyekhez egyetlen szomszéd pozícióból sem lehet eljutni.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>A pozíciók "sor_index:oszlop_index" formátumban szerepelnek a lista elemeiként
        public static List<string> GetUnavailableElements(char[,] map)
        {
            List<string> unavailables = new();

            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                {
                    if (oszlopIndex > 0 && "╬╩║╣╠╝╚█".Contains(map[sorIndex, oszlopIndex]) && "╬╦║╣╠╗╔█".Contains(map[sorIndex, oszlopIndex - 1]))
                        continue;
                    if (oszlopIndex + 1 < map.GetLength(1) && "╬╦║╣╠╗╔█".Contains(map[sorIndex, oszlopIndex]) && "╬╩║╣╠╝╚█".Contains(map[sorIndex, oszlopIndex + 1]))
                        continue;
                    if (sorIndex > 0 && "╬═╦╩╣╗╝█".Contains(map[sorIndex, oszlopIndex]) && "╬═╦╩╠╚╔█".Contains(map[sorIndex - 1, oszlopIndex]))
                        continue;
                    if (sorIndex + 1 < map.GetLength(0) && "╬═╦╩╠╚╔█".Contains(map[sorIndex, oszlopIndex]) && "╬═╦╩╣╗╝█".Contains(map[sorIndex + 1, oszlopIndex]))
                        continue;
                    unavailables.Add(Koordinata((byte)sorIndex, (byte)oszlopIndex));
                }

            // ?
            // pld: string poz = "4:12"; 


            return unavailables;
        }
        /// <summary>
        /// Labiritust generál a kapott pozíciókat tartalmazó lista alapján. A lista elemei egymáshoz kapcsolódó járatok pozíciói.
        /// </summary>
        /// <param name="positionsList">"sor_index:oszlop_index" formátumban az egymáshoz kapcsolódó járatok pozícióit tartalmazó lista </param>
        /// <returns>A létrehozott labirintus térképe</returns>
        public static char[,] GenerateLabyrinth(List<string> positionsList)
        {
            byte[] seged;
            List<string> koord = new() { "0;0", "0;1", "1;1", "0;2" };
            foreach (string s in koord)
            {
                seged = Koordinata(s);

            }
            return null;
        }
        public static byte[] Koordinata(string bekeres)
        {
            byte[] tomb = new byte[2];
            tomb[0] = Convert.ToByte(bekeres.Split(';')[0]);
            tomb[1] = Convert.ToByte(bekeres.Split(';')[1]);

            return tomb;
        }

        public static string Koordinata(byte egyikSzam, byte masikSzam)
        {
            return Convert.ToString(egyikSzam) + ";" + Convert.ToString(masikSzam);
        }

        public static string Koordinata(byte[] tomb)
        {
            return Convert.ToString(tomb[0]) + ";" + Convert.ToString(tomb[1]);
        }

        public static void Valaszt(string[] szoveg, Action[] methods, string cim = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            byte hanyadik = 0, felsoBekezdes = (byte)((Console.WindowHeight - (10 + szoveg.Length)) / 2);
            byte szelesseg = (byte)Console.WindowWidth, magassag = (byte)Console.WindowHeight;

        Rajzol:
            Console.Clear();
            if (cim != "")
            {
                Console.SetCursorPosition((Console.WindowWidth - cim.Length) / 2, felsoBekezdes);
                Console.WriteLine(cim + "\n");
            }
            for (byte i = 0; i < szoveg.Length; i++)
            {
                Console.ResetColor();
                Console.SetCursorPosition((Console.WindowWidth - szoveg[i].Length) / 2 - 2, felsoBekezdes + i + 2);
                if (i == hanyadik)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine($">>{szoveg[i]}<<");
            }

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (hanyadik == 0)
                            break;
                        Console.ResetColor();
                        Console.SetCursorPosition((Console.WindowWidth - szoveg[hanyadik].Length) / 2 - 2, felsoBekezdes + hanyadik + 2);
                        Console.Write($">>{szoveg[hanyadik]}<<");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        hanyadik--;
                        Console.SetCursorPosition((Console.WindowWidth - szoveg[hanyadik].Length) / 2 - 2, felsoBekezdes + hanyadik + 2);
                        Console.Write($">>{szoveg[hanyadik]}<<");
                        Console.ResetColor();
                        break;
                    case ConsoleKey.DownArrow:
                        if (hanyadik == szoveg.Length - 1)
                            break;
                        Console.ResetColor();
                        Console.SetCursorPosition((Console.WindowWidth - szoveg[hanyadik].Length) / 2 - 2, felsoBekezdes + hanyadik + 2);
                        Console.Write($">>{szoveg[hanyadik]}<<");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        hanyadik++;
                        Console.SetCursorPosition((Console.WindowWidth - szoveg[hanyadik].Length) / 2 - 2, felsoBekezdes + hanyadik + 2);
                        Console.Write($">>{szoveg[hanyadik]}<<");
                        Console.ResetColor();
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        methods[hanyadik]();
                        return;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        methods[^1]();
                        return;
                    default:
                        break;
                }
                if (Console.WindowWidth != szelesseg)
                {
                    szelesseg = (byte)Console.WindowWidth;
                    goto Rajzol;
                }
                if (Console.WindowHeight != magassag)
                {
                    magassag = (byte)Console.WindowHeight;
                    goto Rajzol;
                }
            }
        }
    }
}