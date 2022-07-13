using Volo.Abp;

namespace Glipotions.ProductOrder.Exceptions;

public class ConnotBeDeletedException : BusinessException
{
    public ConnotBeDeletedException() : base(ProductOrderDomainErrorCodes.ConnotBeDeleted)
    {
    }
}