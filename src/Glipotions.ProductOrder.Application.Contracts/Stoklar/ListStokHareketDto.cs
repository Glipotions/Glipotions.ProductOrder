
namespace Glipotions.ProductOrder.Stoklar;

public class ListStokHareketDto : EntityDto<Guid>
{
    public Guid? StokId { get; set; }
    public Guid? AlinanSiparisId { get; set; }
    public DateTime Tarih { get; set; }
    public string BelgeNo { get; set; }
    public string BelgeTuru { get; set; }
    //public AlinanSiparisHareketTuru HareketTuru { get; set; }
    public string HareketTuruAdi { get; set; }
    public string Aciklama { get; set; }
    public decimal Miktar { get; set; }
    public string Birim { get; set; }
    public decimal BirimFiyat { get; set; }
    public decimal Tutar { get; set; }
}