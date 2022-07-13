
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class ListAlinanSiparisDto : EntityDto<Guid>
{
    public string AlinanSiparisNo { get; set; }
    public DateTime Tarih { get; set; }
    public string CariAdi { get; set; }
    public decimal BrutTutar { get; set; }
    public decimal IndirimTutar { get; set; }
    public decimal KdvHaricTutar { get; set; }
    public decimal KdvTutar { get; set; }
    public decimal NetTutar { get; set; }
    public int HareketSayisi { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }    
}