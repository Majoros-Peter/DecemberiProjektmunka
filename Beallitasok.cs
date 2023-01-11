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

            M.Valaszt(szovegek, new Action[] { ()=>SzinAtallit(0), ()=>SzinAtallit(1), ()=>SzinAtallit(2), ()=>SzinAtallit(3), ()=>SzinAtallit(4), ()=>SzinAtallit(5), ()=>SzinAtallit(6), ()=>SzinAtallit(7), ()=>SzinAtallit(8), AlapertelmezettSzin, BeallitasokMain }, szoveg.Cim[5]);
        }
        private static void Gombok()
        {
            string[] szovegek = new string[16];
            for (byte i = 0; i < 14; i++)
                szovegek[i] = szoveg.Gombok[i];
            szovegek[14] = szoveg.Alapertelmezett;
            szovegek[15] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] { ()=>GombokBeker(0, Adatok.gombok.Fel), ()=>GombokBeker(1, Adatok.gombok.Le), ()=>GombokBeker(2, Adatok.gombok.Bal), ()=>GombokBeker(3, Adatok.gombok.Jobb), ()=>GombokBeker(4, Adatok.gombok.Elem0),
                ()=>GombokBeker(5, Adatok.gombok.Elem1), ()=>GombokBeker(6, Adatok.gombok.Elem2), ()=>GombokBeker(7, Adatok.gombok.Elem3), ()=>GombokBeker(8, Adatok.gombok.Elem4), ()=>GombokBeker(9, Adatok.gombok.Elem5),
                ()=>GombokBeker(10, Adatok.gombok.Forgat1), ()=>GombokBeker(11, Adatok.gombok.Forgat2), ()=>GombokBeker(12, Adatok.gombok.Lerak), ()=>GombokBeker(13, Adatok.gombok.Kilep), AlapertelmezettGombok, BeallitasokMain }, szoveg.Cim[6]);
        }

        private static void SzinAtallit(byte index)
        {
            hanyadik = index;
            string[] szovegek = new string[17];
            for(byte i = 0; i < 16; i++)
                szovegek[i] = szoveg.Szinek[i];
            szovegek[16] = szoveg.Vissza;

            M.Valaszt(szovegek, new Action[] { ()=>BeallitSzin(0), ()=>BeallitSzin(1), ()=>BeallitSzin(2), ()=>BeallitSzin(3), ()=>BeallitSzin(4), ()=>BeallitSzin(5), ()=>BeallitSzin(6), ()=>BeallitSzin(7), ()=>BeallitSzin(8),
                ()=>BeallitSzin(9), ()=>BeallitSzin(10), ()=>BeallitSzin(11), ()=>BeallitSzin(12), ()=>BeallitSzin(13), ()=>BeallitSzin(14), ()=>BeallitSzin(15), Szin }, szoveg.SzinezhetoDolgok[index]);
        }
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
                    Adatok.szinek.BejartLabirintusSzine = szinIndex;
                    break;
                case 7:
                    Adatok.szinek.ElemSorszamSzine = szinIndex;
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
        public string AlapJatek { get; set; }
        public string[] Nehezitesek { get; set; }
        public string[] Informaciok { get; set; }
        public string[] Iranyok { get; set; }
        public string VakVagy { get; set; }
        public string Gratulalok { get; set; }
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