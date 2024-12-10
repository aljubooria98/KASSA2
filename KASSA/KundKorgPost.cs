using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSA
{
    public class KundKorgPost
    {
        public Produkt Produkt { get; set; }
        public int Mängd { get; set; }
        public decimal TotaltPris { get; set; }

        public KundKorgPost(Produkt produkt, int mängd)
        {
            Produkt = produkt;
            Mängd = mängd;
            TotaltPris = Produkt.Pris * mängd;
        }
    }
}