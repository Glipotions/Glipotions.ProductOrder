
namespace Glipotions.ProductOrder.OzelKodlar;
/// <ÖZET>
/// (2/5) Kurs
/// Validation işlemi FluentValidation ile yapılır, Volo içinde var
/// Bu yüzden AbstractValidator kullanılır.
/// </summary>
public class CreateOzelKodDtoValidator : AbstractValidator<CreateOzelKodDto>
{
    /// <ÖZET>
    /// (2/5) Kurs
    /// FluentValidator da RuleFor ile kural verilir.
    /// 
    /// hataları localizer ile vermemiz gerekir dil problemi olmaması için
    /// her bir property için kural varsa teker teker girilir.
    /// Örneğin Kod için Boş olmaması gerekir ve Maximum uzunluğu geçmemelidir hataları verildi.
    /// 
    /// Enumda olmayan için IsInEnum komutu kullanılır ve enumdaki kullanılmıyorsa hatayı verir.
    /// 
    /// Must kendi yapımızı oluşturmak için kullanılır, kendi kuralımızı koyduktan sonra validation yapılır.
    /// </summary>
    /// <param name="localizer"></param>
    public CreateOzelKodDtoValidator(IStringLocalizer<ProductOrderResource> localizer)
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

        RuleFor(x => x.KodTuru)
            .IsInEnum()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["CodeType"]])

            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["CodeType"]]);

        RuleFor(x => x.KartTuru)
            .IsInEnum()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["CardType"]])

            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["CardType"]]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght,
             localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}