
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class AlinanSiparisListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}