
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class SelectAlinanSiparisDto : EntityDto<Guid>, IOzelKod
{
    public string SiparisNo { get; set; }
    public DateTime Tarih { get; set; }
    public Guid CariId { get; set; }
    public string CariAdi { get; set; }
    public string VergiDairesi { get; set; }
    public string VergiNo { get; set; }
    public string Adres { get; set; }
    public string Telefon { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutar { get; set; }
    public decimal KdvHaricTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal NetTutar { get; set; }
    public int HareketSayisi { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public List<SelectAlinanSiparisHareketDto> AlinanSiparisHareketler { get; set; }
}