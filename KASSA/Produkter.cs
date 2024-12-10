using KASSA;
using System;
using System.Collections.Generic;
using System.IO;

public class Produkter
{
    public List<Produkt> ProdukterFix { get; set; }

    public Produkter()
    {
        ProdukterFix = new List<Produkt>();
        LäsProdukter();
    }

    private void LäsProdukter()
    {
        string filVäg = "C:\\Users\\aljub\\source\\repos\\KASSA\\KASSA\\produkter.txt";

        if (!File.Exists(filVäg))
        {
            Console.Clear();
            Console.WriteLine("Produktfiler finns inte!");
            return;
        }

        foreach (var rad in File.ReadLines(filVäg))
        {
            var delar = rad.Split(';');
            if (delar.Length == 4)
            {
                int produktId = int.Parse(delar[0]);
                string namn = delar[1];
                decimal pris = decimal.Parse(delar[2]);
                string prisTyp = delar[3];

                Produkt nyProdukt = new Produkt(produktId, namn, pris, prisTyp);
                ProdukterFix.Add(nyProdukt);
            }
        }
    }

    public void VisaProdukter()
    {
        foreach (var produkt in ProdukterFix)
        {
            Console.WriteLine(produkt);
        }
    }

    public Produkt HämtaProduktById(int produktId)
    {
        return ProdukterFix.Find(p => p.ProduktId == produktId);
    }
}