namespace KASSA
{
    using System;
    using System.Collections.Generic;

    public class KundKorg
    {
        public List<KundKorgPost> Artiklar { get; set; }
        public decimal TotaltPris { get; set; }

        public KundKorg()
        {
            Artiklar = new List<KundKorgPost>();
            TotaltPris = 0;
        }

        public void LäggTillProdukt(Produkt produkt, int mängd)
        {
            KundKorgPost nyPost = new KundKorgPost(produkt, mängd);
            Artiklar.Add(nyPost);
            TotaltPris += nyPost.TotaltPris;
        }

        public void VisaKorg()
        {
            Console.WriteLine("\nProdukter i korgen:");
            foreach (var post in Artiklar)
            {
                Console.WriteLine($"{post.Produkt.Namn} - {post.Mängd} x {post.Produkt.Pris} = {post.TotaltPris}");
            }
            Console.WriteLine($"Totalt pris: {TotaltPris}");
        }

        public void RensaKorg()
        {
            Artiklar.Clear();
            TotaltPris = 0;
        }
    }
}