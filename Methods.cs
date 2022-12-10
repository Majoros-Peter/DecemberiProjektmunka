using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Methods
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
            {
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                {
                    if (map[sorIndex,oszlopIndex] == '█')
                    {
                        termekSzama++;
                    }
                }
            }
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
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                if (map[sorIndex, 0] == '═') //bal szélső oszlop
                    kijaratokSzama++;
                if (map[sorIndex, map.GetLength(1) - 1] == '═') //jobb szélső oszlop
                    kijaratokSzama++;
            }
            for (int oszlopIndexe = 1; oszlopIndexe < map.GetLength(1) - 1; oszlopIndexe++)
            {
                if (map[0, oszlopIndexe] == '║') //felső sor
                    kijaratokSzama++;
                if (map[map.GetLength(0) - 1, oszlopIndexe] == '║') //alsó sor
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
            char[] karakterekTombje = { '╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔', '█','.'};
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                {
                    if (karakterekTombje.Contains(map[sorIndex,oszlopIndex]))
                    {
                        karakterEllenorzo = true;
                    }
                    else
                    {
                        karakterEllenorzo = false;
                    }
                }
            }
            return karakterEllenorzo;
        }
        /// <summary>
        /// Visszaadja azoknak a járatkaraktereknek a pozícióját, amelyekhez egyetlen szomszéd pozícióból sem lehet eljutni.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>A pozíciók "sor_index:oszlop_index" formátumban szerepelnek a lista elemeiként
        public static List<string> GetUnavailableElements(char[,] map)
        {
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < map.GetLength(1); oszlopIndex++)
                {
                    switch (map[sorIndex, oszlopIndex])
                    {
                        case '╔':
                            //if (map[sorIndex+1, oszlopIndex].Contains(jobbraLehet) && map[sorIndex, oszlopIndex+1].Contains(lefeleLehet))
                            //else 
                            break;
                        case '╗':
                            //if (map[sorIndex-1, oszlopIndex].Contains(balraLehet)  && map[sorIndex, oszlopIndex+1].Contains(lefeleLehet))
                            //else 
                            break;
                        case '╝':
                            //if (map[sorIndex-1, oszlopIndex].Contains(balraLehet) && map[sorIndex, oszlopIndex-1].Contains(felfeleLehet))
                            //else 
                            break;
                        case '╚':
                            //if (map[sorIndex+1, oszlopIndex].Contains(jobbraLehet) && map[sorIndex, oszlopIndex-1].Contains(felfeleLehet))
                            //else 
                            break;
                    }
                }
            }
            List<string> unavailables = new List<string>();
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
            return Convert.ToString(egyikSzam)+";"+Convert.ToString(masikSzam);
        }
    }
}
