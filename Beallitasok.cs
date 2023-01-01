using System.Text.Json;

namespace Labirintus
{
    class B
    {
        private static byte hanyadik;
        private static Nyelv szoveg = Adatok.szoveg;
        public static void BeallitasokMain() => M.Valaszt(new string[] { szoveg.NyelvBeallitas, szoveg.SzinBeallitas, szoveg.Vissza }, new Action[] { Nyelv, Szin, P.Valaszt }, szoveg.Cim[3]);

        private static void Nyelv() => M.Valaszt(new string[] { szoveg.Alapertelmezett, szoveg.Vissza }, new Action[] { Nyelv, BeallitasokMain }, szoveg.Cim[4]);

        private static void Szin()
        {
            string[] szovegek = new string[11];
            for (byte i = 0; i < 9; i++)
                szovegek[i] = szoveg.SzinezhetoDolgok[i];
            szovegek[9] = szoveg.Alapertelmezett;
            szovegek[10] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] { LKSz, LSz, UHSz, KSz, ESz, EKSz, ESSz, BLSz, SzSz, AlapertelmezettSzin, BeallitasokMain }, szoveg.Cim[5]);
        }

        private static void LKSz() => SzinAtallit(0);
        private static void LSz() => SzinAtallit(1);
        private static void UHSz() => SzinAtallit(2);
        private static void KSz() => SzinAtallit(3);
        private static void ESz() => SzinAtallit(3);
        private static void EKSz() => SzinAtallit(4);
        private static void ESSz() => SzinAtallit(5);
        private static void BLSz() => SzinAtallit(6);
        private static void SzSz() => SzinAtallit(7);

        private static void SzinAtallit(byte index)
        {
            hanyadik = index;
            string[] szovegek = new string[17];
            for(byte i = 0; i < 16; i++)
                szovegek[i] = szoveg.Szinek[i];
            szovegek[16] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] {Fekete, SKek, SZold, SCian, SPiros, SMagenta, SSarga, Szurke, SSzurke, Kek, Zold, Cian, Piros, Magenta, Sarga, Feher, Szin }, szoveg.SzinezhetoDolgok[index]);
        }

        private static void Fekete() => BeallitSzin(0);
        private static void SKek() => BeallitSzin(1);
        private static void SZold() => BeallitSzin(2);
        private static void SCian() => BeallitSzin(3);
        private static void SPiros() => BeallitSzin(4);
        private static void SMagenta() => BeallitSzin(5);
        private static void SSarga() => BeallitSzin(6);
        private static void Szurke() => BeallitSzin(7);
        private static void SSzurke() => BeallitSzin(8);
        private static void Kek() => BeallitSzin(9);
        private static void Zold() => BeallitSzin(10);
        private static void Cian() => BeallitSzin(11);
        private static void Piros() => BeallitSzin(12);
        private static void Magenta() => BeallitSzin(13);
        private static void Sarga() => BeallitSzin(14);
        private static void Feher() => BeallitSzin(15);

        private static void BeallitSzin(byte szinIndex)
        {
            ConsoleColor[] szinek = { Adatok.labirintusKeretSzine, Adatok.labirintusSzine, Adatok.uresHelySzine, Adatok.kivalasztottSzine, Adatok.elemSzine, Adatok.elemKereteSzine, Adatok.elemSorszamSzine, Adatok.bejartLabirintusSzine, Adatok.szovegSzine };
            szinek[hanyadik] = (ConsoleColor)szinIndex;
            Adatok.labirintusKeretSzine = szinek[0];
            Adatok.labirintusSzine = szinek[1];
            Adatok.uresHelySzine = szinek[2];
            Adatok.kivalasztottSzine = szinek[3];
            Adatok.elemSzine = szinek[4];
            Adatok.elemKereteSzine = szinek[5];
            Adatok.elemSorszamSzine = szinek[6];
            Adatok.bejartLabirintusSzine = szinek[7];
            Adatok.szovegSzine = szinek[8];
            Szin();
        }

        private static void AlapertelmezettSzin()
        {
            Adatok.labirintusKeretSzine = (ConsoleColor)6;
            Adatok.labirintusSzine = (ConsoleColor)15;
            Adatok.uresHelySzine = (ConsoleColor)0;
            Adatok.kivalasztottSzine = (ConsoleColor)11;
            Adatok.elemSzine = (ConsoleColor)12;
            Adatok.elemKereteSzine = (ConsoleColor)6;
            Adatok.elemSorszamSzine = (ConsoleColor)10;
            Adatok.bejartLabirintusSzine = (ConsoleColor)10;
            Adatok.szovegSzine = (ConsoleColor)15;
            File.WriteAllText(Adatok.mappa+@"\beallitasok\szinek.json", File.ReadAllText(Adatok.mappa+@"\beallitasok\AlapertelmezettSzinek.json"));
            Console.WriteLine(szoveg.SikeresBeallit[0]);
            Szin();
        }
    }

    class Adatok
    {
        public static byte nyelv = 0;    //0 => magyar, 1 => angol
        public static string mappa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 17);
        public static Nyelv szoveg = JsonSerializer.Deserialize<Nyelv>(nyelv==0 ? File.ReadAllText(mappa+@"\beallitasok\magyar.json") : File.ReadAllText(mappa + @"\beallitasok\angol.json"));
        public static SzinIndex szinek = JsonSerializer.Deserialize<SzinIndex>(File.ReadAllText(mappa+@"\beallitasok\szinek.json"));
        public static ConsoleColor
            labirintusKeretSzine = (ConsoleColor)szinek.LabirintusKeretSzine,
            labirintusSzine = (ConsoleColor)szinek.LabirintusSzine,
            uresHelySzine = (ConsoleColor)szinek.UresHelySzine,
            kivalasztottSzine = (ConsoleColor)szinek.KivalasztottSzine,
            elemSzine = (ConsoleColor)szinek.ElemSzine,
            elemKereteSzine = (ConsoleColor)szinek.ElemKereteSzine,
            elemSorszamSzine = (ConsoleColor)szinek.ElemSorszamSzine,
            bejartLabirintusSzine = (ConsoleColor)szinek.BejartLabirintusSzine,
            szovegSzine = (ConsoleColor)szinek.SzovegSzine;
    }

    class Nyelv
    {
        public string[] Cim { get; set; }
        public string Kilepes { get; set; }
        public string Vissza { get; set; }
        public string Inditas { get; set; }
        public string Szerkesztes { get; set; }
        public string Beallitas { get; set; }
        public string Sajat { get; set; }
        public string General { get; set; }
        public string Modositas { get; set; }
        public string BekerMeret { get; set; }
        public string BekerKoord { get; set; }
        public string[] BekerPalyaNev { get; set; }
        public string LetezoPalya { get; set; }
        public string SikeresMentes { get; set; }
        public string Hiba { get; set; }
        public string NyelvBeallitas { get; set; }
        public string SzinBeallitas { get; set; }
        public string Alapertelmezett { get; set; }
        public string[] SzinezhetoDolgok { get; set; }
        public string[] SikeresBeallit { get; set; }
        public string[] Szinek { get; set; }
    }

    class SzinIndex
    {
        public byte LabirintusKeretSzine { get; set; }
        public byte LabirintusSzine { get; set; }
        public byte UresHelySzine { get; set; }
        public byte KivalasztottSzine { get; set; }
        public byte ElemSzine { get; set; }
        public byte ElemKereteSzine { get; set; }
        public byte ElemSorszamSzine { get; set; }
        public byte BejartLabirintusSzine { get; set; }
        public byte SzovegSzine { get; set; }
    }
}