using KASSA;
using System;
using System.IO;

public class Program
{
    private static Produkter produktFix = new Produkter();
    private static KundKorg kundKorg = new KundKorg();
    private static int kundNummer;
    private static string kundNummerFil = "kundNummer.txt";
    private static string datumFil = "datum.txt";

    public static void Main(string[] args)
    {
        string förrDatum = GetLastDate();
        string nuDatum = DateTime.Now.ToString("yyyy-MM-dd");

        if (förrDatum != nuDatum)
        {
            kundNummer = 1;
            SaveDate(nuDatum);
            SaveKundNummer(kundNummer);
        }
        else
        {
            kundNummer = LoadKundNummer();
        }

        while (true)
        {
            VisaHuvudmeny();
            string val = Console.ReadLine();

            if (val == "1")
            {
                Console.Clear();
                StartaHandel();
            }
            else if (val == "0")
            {
                Console.WriteLine("Stänger kassan...");
                break;
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }
    }

    public static void VisaHuvudmeny()
    {
        Console.WriteLine("\nVälkommen till kassan!");
        Console.WriteLine("1 - Börja handla");
        Console.WriteLine("0 - Stäng Kassan");
        Console.Write("Välj ett alternativ: ");
    }

    public static void StartaHandel()
    {
        kundKorg.RensaKorg();
        Console.WriteLine($"\nKund {kundNummer} börjar handla!");

        while (true)
        {
            Console.WriteLine("\nTillgängliga varor:");
            produktFix.VisaProdukter();

            Console.WriteLine("\nTryck '0' för att avbryta.");
            Console.WriteLine("Ange 'PAY' för att betala.");

            Console.Write("\nAnge produktid mellanslag mängd: ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                kundKorg.RensaKorg();
                return;
            }

            if (input == "PAY")
            {
                Console.Clear();
                KvittoSpar.SkrivUtKvitto(kundKorg, kundNummer);
                kundNummer++;
                SaveKundNummer(kundNummer);
                return;
            }

            string[] delar = input.Split(' ');

            if (delar.Length == 2 && int.TryParse(delar[0], out int produktId) && int.TryParse(delar[1], out int mängd))
            {
                Produkt produkt = produktFix.HämtaProduktById(produktId);

                if (produkt == null)
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig produkt.");
                    continue;
                }

                Console.Clear();
                kundKorg.LäggTillProdukt(produkt, mängd);
                kundKorg.VisaKorg();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ogiltig inmatning. Använd formatet: produktid mellanslag mängd (ex: 300 2).");
            }
        }
    }

    private static int LoadKundNummer()
    {
        if (File.Exists(kundNummerFil))
        {
            string kundNummerStr = File.ReadAllText(kundNummerFil);
            if (int.TryParse(kundNummerStr, out int lastKundNummer))
            {
                return lastKundNummer;
            }
        }
        return 1;
    }

    private static void SaveKundNummer(int number)
    {
        File.WriteAllText(kundNummerFil, number.ToString());
    }

    private static string GetLastDate()
    {
        if (File.Exists(datumFil))
        {
            return File.ReadAllText(datumFil);
        }
        return string.Empty;
    }

    private static void SaveDate(string date)
    {
        File.WriteAllText(datumFil, date);
    }
}