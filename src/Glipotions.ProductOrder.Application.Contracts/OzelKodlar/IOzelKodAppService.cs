using Glipotions.ProductOrder.Services;

namespace Glipotions.ProductOrder.OzelKodlar;

public interface IOzelKodAppService : ICrudAppService<SelectOzelKodDto, ListOzelKodDto,
    OzelKodListParameterDto, CreateOzelKodDto, UpdateOzelKodDto, OzelKodCodeParameterDto>
{
}