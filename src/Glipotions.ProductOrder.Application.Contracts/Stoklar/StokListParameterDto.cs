namespace Glipotions.ProductOrder.Stoklar;

public class StokListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}