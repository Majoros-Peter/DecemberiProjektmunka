using System.Text.Json;

namespace Labirintus
{
    class B
    {
        private static byte hanyadik;
        private static Nyelv szoveg = Adatok.szoveg;
        private const string SZINEKJSON1 = @"{
  ""nyelv"": true,
  ""LabirintusKeretSzine"": 6,
  ""LabirintusSzine"": 15,
  ""UresHelySzine"": 0,
  ""KivalasztottSzine"": 11,
  ""ElemSzine"": 12,
  ""ElemKereteSzine"": 6,
  ""ElemSorszamSzine"": 10,
  ""BejartLabirintusSzine"": 10,
  ""SzovegSzine"": 15
}";
        private const string SZINEKJSON2 = @"{
  ""nyelv"": false,
  ""LabirintusKeretSzine"": 6,
  ""LabirintusSzine"": 15,
  ""UresHelySzine"": 0,
  ""KivalasztottSzine"": 11,
  ""ElemSzine"": 12,
  ""ElemKereteSzine"": 6,
  ""ElemSorszamSzine"": 10,
  ""BejartLabirintusSzine"": 10,
  ""SzovegSzine"": 15
}";
        private const string GOMBOKJSON = @"{
  ""Fel"": 38,
  ""Le"": 40,
  ""Bal"": 37,
  ""Jobb"": 39,
  ""Elem0"": 48,
  ""Elem1"": 49,
  ""Elem2"": 50,
  ""Elem3"": 51,
  ""Elem4"": 52,
  ""Elem5"": 53,
  ""Forgat1"": 107,
  ""Forgat2"": 109,
  ""Lerak"": 13,
  ""Kilep"": 27
}";
        public static void BeallitasokMain() => M.Valaszt(new string[] { szoveg.GombBeallitas, szoveg.NyelvBeallitas, szoveg.SzinBeallitas, szoveg.Vissza }, new Action[] { Gombok, Nyelv, Szin, P.Valaszt }, szoveg.Cim[3]);
        private static void Nyelv() => M.Valaszt(new string[] { szoveg.NyelvAtallitas, szoveg.Vissza }, new Action[] { NyelvBeallit, BeallitasokMain }, szoveg.Cim[4]);
        private static void Szin()
        {
            string[] szovegek = new string[11];
            for (byte i = 0; i < 9; i++)
                szovegek[i] = szoveg.SzinezhetoDolgok[i];
            szovegek[9] = szoveg.Alapertelmezett;
            szovegek[10] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] { LKSz, LSz, UHSz, KSz, ESz, EKSz, ESSz, BLSz, SzSz, AlapertelmezettSzin, BeallitasokMain }, szoveg.Cim[5]);
        }
        private static void Gombok()
        {
            string[] szovegek = new string[16];
            for (byte i = 0; i < 14; i++)
                szovegek[i] = szoveg.Gombok[i];
            szovegek[14] = szoveg.Alapertelmezett;
            szovegek[15] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] { Fel, Le, Bal, Jobb, E0, E1, E2, E3, E4, E5, F1, F2, L, K, AlapertelmezettGombok, BeallitasokMain }, szoveg.Cim[6]);
        }

        private static void LKSz() => SzinAtallit(0);
        private static void LSz() => SzinAtallit(1);
        private static void UHSz() => SzinAtallit(2);
        private static void KSz() => SzinAtallit(3);
        private static void ESz() => SzinAtallit(4);
        private static void EKSz() => SzinAtallit(5);
        private static void ESSz() => SzinAtallit(6);
        private static void BLSz() => SzinAtallit(7);
        private static void SzSz() => SzinAtallit(8);

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
            switch (hanyadik)
            {
                case 0:
                    Adatok.szinek.LabirintusKeretSzine = szinIndex;
                    break;
                case 1:
                    Adatok.szinek.LabirintusSzine = szinIndex;
                    break;
                case 2:
                    Adatok.szinek.UresHelySzine = szinIndex;
                    break;
                case 3:
                    Adatok.szinek.KivalasztottSzine = szinIndex;
                    break;
                case 4:
                    Adatok.szinek.ElemSzine = szinIndex;
                    break;
                case 5:
                    Adatok.szinek.ElemKereteSzine = szinIndex;
                    break;
                case 6:
                    Adatok.szinek.ElemSorszamSzine = szinIndex;
                    break;
                case 7:
                    Adatok.szinek.BejartLabirintusSzine = szinIndex;
                    break;
                case 8:
                    Adatok.szinek.SzovegSzine = szinIndex;
                    break;
            }
            hanyadik=0;

            File.WriteAllText(Adatok.mappa+@"\beallitasok\szinek.json", JsonSerializer.Serialize(Adatok.szinek, new JsonSerializerOptions { WriteIndented = true }));

            Szin();
        }

        private static void AlapertelmezettSzin()
        {
            File.WriteAllText(Adatok.mappa+@"\beallitasok\szinek.json", Adatok.szinek.nyelv ? SZINEKJSON1 : SZINEKJSON2);
            Adatok.szinek = JsonSerializer.Deserialize<SzinIndex>(File.ReadAllText(Adatok.mappa+@"\beallitasok\szinek.json"));
            Console.WriteLine(szoveg.SikeresBeallit[0]);
            Console.ReadKey();
            Szin();
        }

        private static void NyelvBeallit()
        {
            Adatok.szinek.nyelv = !Adatok.szinek.nyelv;
            Adatok.szoveg = JsonSerializer.Deserialize<Nyelv>(Adatok.szinek.nyelv ? File.ReadAllText(Adatok.mappa+@"\beallitasok\magyar.json") : File.ReadAllText(Adatok.mappa+@"\beallitasok\angol.json"));
            File.WriteAllText(Adatok.mappa+@"\beallitasok\szinek.json", JsonSerializer.Serialize(Adatok.szinek, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine(szoveg.SikeresBeallit[1]);
            Console.ReadKey();
        }

        private static void Fel() => GombokBeker(0, Adatok.gombok.Fel);
        private static void Le() => GombokBeker(1, Adatok.gombok.Le);
        private static void Bal() => GombokBeker(2, Adatok.gombok.Bal);
        private static void Jobb() => GombokBeker(3, Adatok.gombok.Jobb);
        private static void E0() => GombokBeker(4, Adatok.gombok.Elem0);
        private static void E1() => GombokBeker(5, Adatok.gombok.Elem1);
        private static void E2() => GombokBeker(6, Adatok.gombok.Elem2);
        private static void E3() => GombokBeker(7, Adatok.gombok.Elem3);
        private static void E4() => GombokBeker(8, Adatok.gombok.Elem4);
        private static void E5() => GombokBeker(9, Adatok.gombok.Elem5);
        private static void F1() => GombokBeker(10, Adatok.gombok.Forgat1);
        private static void F2() => GombokBeker(11, Adatok.gombok.Forgat2);
        private static void L() => GombokBeker(12, Adatok.gombok.Lerak);
        private static void K() => GombokBeker(13, Adatok.gombok.Kilep);

        private static void GombokBeker(byte index, byte gomb)
        {
            Console.WriteLine(szoveg.GombBeker[0] + szoveg.Gombok[index] + szoveg.GombBeker[1] + T.GombSzoveg(gomb) + szoveg.GombBeker[2]);
            Thread.Sleep(1000);
            Console.WriteLine($"\n\n{szoveg.GombBeker[3]}");
            GombokBeallit(index);
            Console.Clear();
            Console.WriteLine(szoveg.GombBeker[0] + szoveg.Gombok[index] + szoveg.GombBeker[4] + T.GombSzoveg(gomb) + szoveg.GombBeker[2]);
            File.WriteAllText(Adatok.mappa+@"\beallitasok\gombok.json", JsonSerializer.Serialize(Adatok.gombok, new JsonSerializerOptions { WriteIndented = true }));
            Gombok();
        }

        private static void GombokBeallit(byte hanyadik)
        {
            switch (hanyadik)
            {
                case 0:
                    Adatok.gombok.Fel = (byte)Console.ReadKey(true).Key;
                    break;
                case 1:
                    Adatok.gombok.Le = (byte)Console.ReadKey(true).Key;
                    break;
                case 2:
                    Adatok.gombok.Bal = (byte)Console.ReadKey(true).Key;
                    break;
                case 3:
                    Adatok.gombok.Jobb = (byte)Console.ReadKey(true).Key;
                    break;
                case 4:
                    Adatok.gombok.Elem0 = (byte)Console.ReadKey(true).Key;
                    break;
                case 5:
                    Adatok.gombok.Elem1 = (byte)Console.ReadKey(true).Key;
                    break;
                case 6:
                    Adatok.gombok.Elem2 = (byte)Console.ReadKey(true).Key;
                    break;
                case 7:
                    Adatok.gombok.Elem3 = (byte)Console.ReadKey(true).Key;
                    break;
                case 8:
                    Adatok.gombok.Elem4 = (byte)Console.ReadKey(true).Key;
                    break;
                case 9:
                    Adatok.gombok.Elem5 = (byte)Console.ReadKey(true).Key;
                    break;
                case 10:
                    Adatok.gombok.Forgat1 = (byte)Console.ReadKey(true).Key;
                    break;
                case 11:
                    Adatok.gombok.Forgat2 = (byte)Console.ReadKey(true).Key;
                    break;
                case 12:
                    Adatok.gombok.Lerak = (byte)Console.ReadKey(true).Key;
                    break;
                case 13:
                    Adatok.gombok.Kilep = (byte)Console.ReadKey(true).Key;
                    break;
            }
        }

        private static void AlapertelmezettGombok()
        {
            File.WriteAllText(Adatok.mappa+@"\beallitasok\gombok.json", GOMBOKJSON);
            Adatok.gombok = JsonSerializer.Deserialize<Gombok>(File.ReadAllText(Adatok.mappa+@"\beallitasok\gombok.json"));
            Console.WriteLine(szoveg.SikeresBeallit[2]);
            Console.ReadKey();
            Gombok();
        }
    }

    class Adatok
    {
        public static string mappa = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 17);
        public static SzinIndex szinek = JsonSerializer.Deserialize<SzinIndex>(File.ReadAllText(mappa+@"\beallitasok\szinek.json"));
        public static Nyelv szoveg = JsonSerializer.Deserialize<Nyelv>(szinek.nyelv ? File.ReadAllText(mappa+@"\beallitasok\magyar.json") : File.ReadAllText(mappa+@"\beallitasok\angol.json"));
        public static Gombok gombok = JsonSerializer.Deserialize<Gombok>(File.ReadAllText(mappa+@"\beallitasok\gombok.json"));
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
        public string[] BekerKoord { get; set; }
        public string[] BekerPalyaNev { get; set; }
        public string LetezoPalya { get; set; }
        public string SikeresMentes { get; set; }
        public string Hiba { get; set; }
        public string NyelvBeallitas { get; set; }
        public string NyelvAtallitas { get; set; }
        public string SzinBeallitas { get; set; }
        public string Alapertelmezett { get; set; }
        public string[] SzinezhetoDolgok { get; set; }
        public string[] SikeresBeallit { get; set; }
        public string[] Szinek { get; set; }
        public string GombBeallitas { get; set; }
        public string[] Gombok { get; set; }
        public string[] GombBeker { get; set; }
    }

    class SzinIndex
    {
        public bool nyelv { get; set; }
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

    class Gombok
    {
        public byte Fel { get; set; }
        public byte Le { get; set; }
        public byte Bal { get; set; }
        public byte Jobb { get; set; }
        public byte Elem0 { get; set; }
        public byte Elem1 { get; set; }
        public byte Elem2 { get; set; }
        public byte Elem3 { get; set; }
        public byte Elem4 { get; set; }
        public byte Elem5 { get; set; }
        public byte Forgat1 { get; set; }
        public byte Forgat2 { get; set; }
        public byte Lerak { get; set; }
        public byte Kilep { get; set; }
    }
}