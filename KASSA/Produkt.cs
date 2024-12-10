public class Produkt
{
    public int ProduktId { get; set; }
    public string Namn { get; set; }
    public decimal Pris { get; set; }
    public string PrisTyp { get; set; }

    public Produkt(int produktId, string namn, decimal pris, string prisTyp)
    {
        ProduktId = produktId;
        Namn = namn;
        Pris = pris;
        PrisTyp = prisTyp;
    }

    public override string ToString()
    {
        return $"{ProduktId} - {Namn} - {Pris} {PrisTyp}";
    }
}