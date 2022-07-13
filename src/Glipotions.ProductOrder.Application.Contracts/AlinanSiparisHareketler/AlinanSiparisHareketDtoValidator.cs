
namespace Glipotions.ProductOrder.AlinanSiparisHareketler;

public class AlinanSiparisHareketDtoValidator : AbstractValidator<AlinanSiparisHareketDto>
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
    /// 
    /// GreaterThanOrEqualTo ile 0 dan büyük olması gerektiği belirtilir.
    /// 
    /// When ile koşula bağlı Validator Eklenir. Örnek: AlinanSiparisHareketTuru.Stok ise Stok alanı boş olamaz.
    /// </summary>
    /// <param name="localizer"></param>
    public AlinanSiparisHareketDtoValidator(IStringLocalizer localizer)
    {
        RuleFor(x => x.Id)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["Id"]]);

        //RuleFor(x => x.HareketTuru)
        //    .IsInEnum()
        //    .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
        //     localizer["RowType"]])

        //    .NotEmpty()
        //    .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
        //     localizer["RowType"]]);

        RuleFor(x => x.StokId)
            .NotEmpty()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["Stock"]]);

        //RuleFor(x => x.DepoId)
        //    .NotEmpty()
        //    .When(x => x.HareketTuru == AlinanSiparisHareketTuru.Stok)
        //    .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
        //     localizer["Warehouse"]]);

        RuleFor(x => x.Miktar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["Quantity"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["Quantity"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.BirimFiyat)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["UnitPrice"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["UnitPrice"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.BrutTutar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["GrossAmount"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["GrossAmount"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.IndirimTutar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["DiscountAmount"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["DiscountAmount"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.KdvOrani)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["ValueAddedTaxRate"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["ValueAddedTaxRate"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.KdvHaricTutar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["ExcludesValueAddedTaxAmount"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["ExcludesValueAddedTaxAmount"], localizer["ToZero"],
             localizer["ThanZero"]]);

        RuleFor(x => x.KdvTutar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["ValueAddedTaxAmount"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["ValueAddedTaxAmount"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.NetTutar)
            .NotNull()
            .WithMessage(localizer[ProductOrderDomainErrorCodes.Required,
             localizer["TotalAmount"]])

            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.GreaterThanOrEqual,
             localizer["TotalAmount"], localizer["ToZero"], localizer["ThanZero"]]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(localizer[ProductOrderDomainErrorCodes.MaxLenght,
             localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}