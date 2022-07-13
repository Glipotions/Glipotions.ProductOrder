using Glipotions.ProductOrder.Consts;
using Glipotions.ProductOrder.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Glipotions.ProductOrder.Subeler;

public class CreateSubeDtoValidator : AbstractValidator<CreateSubeDto>
{
    public CreateSubeDtoValidator(IStringLocalizer<ProductOrderResource> localizer)
    {
        RuleFor(x => x.Kod)
            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required, localizer["Code"]])

            .MaximumLength(EntityConsts.MaxKodLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght, localizer["Code"],
             EntityConsts.MaxKodLength]);

        RuleFor(x => x.Ad)
            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required, localizer["Name"]])

            .MaximumLength(EntityConsts.MaxAdLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght, localizer["Name"],
             EntityConsts.MaxAdLength]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght,
             localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}