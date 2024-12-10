using KASSA;
using System;
using System.IO;
class KvittoSpar
{
    public static void SkrivUtKvitto(KundKorg kundKorg, int kundNummer)
    {
        string nuDatum = DateTime.Now.ToString("yyyyMMdd");
        string kvittoTid = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string directoryPath = @"C:\Users\aljub\source\repos\KASSA\KASSA\Kvitton\";
        string filePath = Path.Combine(directoryPath, $"RECEIPT_{nuDatum}.txt");
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine($"                     {kundNummer}");
            writer.WriteLine("============================================");
            writer.WriteLine("                   KVITTO                  ");
            writer.WriteLine("============================================");
            writer.WriteLine($"     Kundnummer:   {kundNummer}");
            writer.WriteLine($"     Datum & Tid:  {kvittoTid}");
            writer.WriteLine("--------------------------------------------");

            foreach (var post in kundKorg.Artiklar)
            {
                writer.WriteLine($"     {post.Produkt.Namn} - {post.Mängd} x {post.Produkt.Pris:C} = {post.TotaltPris:C}");
            }

            writer.WriteLine("--------------------------------------------");
            writer.WriteLine($"     Totalt pris: {kundKorg.TotaltPris:C}");
            writer.WriteLine("--------------------------------------------");
            writer.WriteLine($"     Kvitto ID: {kundNummer}/RECEIPT_{nuDatum}.txt");
            writer.WriteLine("============================================");
            writer.WriteLine("");
            writer.WriteLine("");
        }
        Console.WriteLine($"Kvitto sparat: Kvitton NR: {kundNummer} i: {nuDatum}");
    }
}