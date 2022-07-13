namespace Glipotions.ProductOrder.OzelKodlar;

public class OzelKod : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public OzelKodTuru KodTuru { get; set; }
    public KartTuru KartTuru { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public ICollection<AlinanSiparis> OzelKod1AlinanSiparisler { get; set; }
    public ICollection<AlinanSiparis> OzelKod2AlinanSiparisler { get; set; }
    public ICollection<Birim> OzelKod1Birimler { get; set; }
    public ICollection<Birim> OzelKod2Birimler { get; set; }
    public ICollection<Stok> OzelKod1Stoklar { get; set; }
    public ICollection<Stok> OzelKod2Stoklar { get; set; }
}