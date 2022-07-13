
namespace Glipotions.ProductOrder.AlinanSiparisler;

public class SelectAlinanSiparisHareketDtoValidator : AbstractValidator<SelectAlinanSiparisHareketDto>
{
    /// <ÖZET>
    /// Konu (2/5) Kurs
    /// Oluşturma (4/5) 28. video
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
    public SelectAlinanSiparisHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.StokId)
            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["Stock"]]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght,
             localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}