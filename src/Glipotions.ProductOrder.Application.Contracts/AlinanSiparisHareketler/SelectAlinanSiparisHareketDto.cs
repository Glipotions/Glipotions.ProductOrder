namespace Glipotions.ProductOrder.AlinanSiparisHareketler;

public class SelectAlinanSiparisHareketDto : EntityDto<Guid>
{
    public Guid AlinanSiparisId { get; set; }
    public string HareketTuruAdi { get; set; }
    public string HareketAdi { get; set; }
    public string HareketKodu { get; set; }
    public int HareketSayisi { get; set; }
    public Guid? StokId { get; set; }
    public string StokKodu { get; set; }
    public string StokAdi { get; set; }
    public string BirimAdi { get; set; }
    public decimal Miktar { get; set; }
    public decimal BirimFiyat { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutar { get; set; }
    public int KdvOrani { get; set; }
    public decimal KdvHaricTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal NetTutar { get; set; }
    public string Aciklama { get; set; }   
}