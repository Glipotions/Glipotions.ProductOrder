namespace Glipotions.ProductOrder.Donemler;

public class Donem : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }

    public ICollection<AlinanSiparis> AlinanSiparisler { get; set; }
    //public ICollection<FirmaParametre> FirmaParametreler { get; set; }
}