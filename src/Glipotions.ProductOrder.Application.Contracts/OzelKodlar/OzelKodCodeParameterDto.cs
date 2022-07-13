namespace Glipotions.ProductOrder.OzelKodlar;

public class OzelKodCodeParameterDto : IDurum, IEntityDto
{
    public OzelKodTuru KodTuru { get; set; }
    public KartTuru KartTuru { get; set; }
    public bool Durum { get; set; }
}