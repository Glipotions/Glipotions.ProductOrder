namespace Glipotions.ProductOrder.OzelKodlar;

public class OzelKodManager : DomainService
{
    private readonly IOzelKodRepository _ozelKodRepository;

    public OzelKodManager(IOzelKodRepository ozelKodRepository)
    {
        _ozelKodRepository = ozelKodRepository;
    }

    /// <Özet>
    /// Create işlemi yaparken gelen id ve kod alanı ile ilgili hata var mı yok mu
    /// diye kontrol eder. hata varsa hata fırlatır.
    /// <param name="kod"></param>          varsa tekrar eden kod hatası
    /// <returns></returns>
    public async Task CheckCreateAsync(string kod, OzelKodTuru? kodTuru, KartTuru? kartTuru)
    {
        await _ozelKodRepository.KodAnyAsync(kod, x => x.Kod == kod && x.KodTuru == kodTuru &&
                                                       x.KartTuru == kartTuru);
    }

    /// <Özet>
    /// Update işlemi yaparken hata kontrol etme yeri
    /// kodlar birbirine eşitse check etmeye gerek yok
    /// gelen kod ile entity.kod işlemi aynı ise hiç check etmeden direkt bu aşamayı geç.
    /// 
    /// ozelKod Idleri birbirinden farklı ise check et, değilse işlemi geç
    public async Task CheckUpdateAsync(Guid id, string kod, OzelKod entity)
    {
        await _ozelKodRepository.KodAnyAsync(kod, x => x.Id != id && x.Kod == kod && x.KodTuru == entity.KodTuru &&
            x.KartTuru == entity.KartTuru,
            entity.Kod != kod);
    }

    /// <Özet>
    /// Silme işlemi yaparken kontrol eder sorun yoksa yapar varsa hata fırlatır.
    /// -
    /// entity kullanılmışsa iptal et, kullanılmamışsa izin ver.
    public async Task CheckDeleteAsync(Guid id)
    {
        await _ozelKodRepository.RelationalEntityAnyAsync(
            x =>
                 x.OzelKod1AlinanSiparisler.Any(y => y.OzelKod1Id == id) ||
                 x.OzelKod2AlinanSiparisler.Any(y => y.OzelKod2Id == id) ||
                 x.OzelKod1Birimler.Any(y => y.OzelKod1Id == id) ||
                 x.OzelKod2Birimler.Any(y => y.OzelKod2Id == id) ||
                 x.OzelKod1Stoklar.Any(y => y.OzelKod1Id == id) ||
                 x.OzelKod2Stoklar.Any(y => y.OzelKod2Id == id));
    }
}