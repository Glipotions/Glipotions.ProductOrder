
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class AlinanSiparisReportDto : IEntityDto
{
    public string SiparisNo { get; set; }
    public DateTime Tarih { get; set; }
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
    public string Aciklama { get; set; }
    public List<AlinanSiparisHareketReportDto> AlinanSiparisHareketler { get; set; }
}