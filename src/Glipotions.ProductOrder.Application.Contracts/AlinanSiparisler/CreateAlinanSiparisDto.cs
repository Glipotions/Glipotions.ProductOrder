
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class CreateAlinanSiparisDto : IEntityDto
{
    public string AlinanSiparisNo { get; set; }
    public DateTime? Tarih { get; set; }
    public decimal? BrutTutar { get; set; }
    public decimal? IndirimTutar { get; set; }
    public decimal? KdvHaricTutar { get; set; }
    public decimal? KdvTutar { get; set; }
    public decimal? NetTutar { get; set; }
    public int? HareketSayisi { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public Guid? SubeId { get; set; }
    public Guid? DonemId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
    public ICollection<AlinanSiparisHareketDto> AlinanSiparisHareketler { get; set; }
}