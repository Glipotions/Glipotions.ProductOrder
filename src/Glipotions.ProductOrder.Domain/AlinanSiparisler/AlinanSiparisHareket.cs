namespace Glipotions.ProductOrder.AlinanSiparisler;

//FullAuditedEntity olmasının nedeni faturaya bağlı bir entity olduğu için böyle yaptık. (1/5) 24.Video 3.dk
public class AlinanSiparisHareket : FullAuditedEntity<Guid>
{
    public Guid AlinanSiparisId { get; set; }
    public Guid StokId { get; set; }
    public decimal Miktar { get; set; }
    public decimal BirimFiyat { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutar { get; set; }
    public int KdvOrani { get; set; }
    public decimal KdvHaricTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal NetTutar { get; set; }
    public string Aciklama { get; set; }

    public AlinanSiparis AlinanSiparis { get; set; }
    public Stok Stok { get; set; }
}