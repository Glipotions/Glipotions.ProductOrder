namespace Glipotions.ProductOrder.AlinanSiparisler;

public class AlinanSiparisManager : DomainService
{
    private readonly IAlinanSiparisRepository _alinanSiparisRepository;
    private readonly IOzelKodRepository _ozelKodRepository;
    private readonly ISubeRepository _subeRepository;
    private readonly IDonemRepository _donemRepository;

    public AlinanSiparisManager(IAlinanSiparisRepository alinanSiparisRepository,
        IOzelKodRepository ozelKodRepository, ISubeRepository subeRepository,
        IDonemRepository donemRepository)
    {
        _alinanSiparisRepository = alinanSiparisRepository;
        _ozelKodRepository = ozelKodRepository;
        _subeRepository = subeRepository;
        _donemRepository = donemRepository;
    }
    /// <Özet>
    /// Create işlemi yaparken gelen id ve kod alanı ile ilgili hata var mı yok mu
    /// diye kontrol eder. hata varsa hata fırlatır.
    /// İlk olarak Şube ve Dönem kontrolü yapılır çünkü kod kontrolü yaparken şube ve dönem'e bakılır.
    /// 
    /// <param name="alinanSiparisNo"></param>     varsa tekrar eden kod hatası
    /// <param name="ozelKod1Id"></param>   yoksa böyle bir id yok hatası
    /// <param name="ozelKod2Id"></param>   yoksa böyle bir id yok hatası
    /// <param name="subeId"></param>       yoksa böyle bir subeid yok hatası
    /// <param name="donemId"></param>      yoksa böyle bir donemId yok hatası
    /// <param name="cariId"></param>       yoksa böyle bir cariId yok hatası
    /// <returns></returns>
    public async Task CheckCreateAsync(string alinanSiparisNo, Guid? ozelKod1Id,
        Guid? ozelKod2Id, Guid? subeId, Guid? donemId)
    {
        await _subeRepository.EntityAnyAsync(subeId, x => x.Id == subeId);
        await _donemRepository.EntityAnyAsync(donemId, x => x.Id == donemId);

        await _alinanSiparisRepository.KodAnyAsync(alinanSiparisNo, x => x.SiparisNo == alinanSiparisNo &&
        x.SubeId == subeId && x.DonemId == donemId);


        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1,
            KartTuru.AlinanSiparis);

        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2,
            KartTuru.AlinanSiparis);
        
    }

    public async Task CheckUpdateAsync(Guid id, string alinanSiparisNo, AlinanSiparis entity,
        Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        await _alinanSiparisRepository.KodAnyAsync(alinanSiparisNo, x => x.Id != id &&
        x.SiparisNo == alinanSiparisNo && x.SubeId == entity.SubeId && x.DonemId == entity.DonemId,
        entity.SiparisNo != alinanSiparisNo);

        await _ozelKodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1,
            KartTuru.AlinanSiparis, entity.OzelKod1Id != ozelKod1Id);

        await _ozelKodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2,
            KartTuru.AlinanSiparis, entity.OzelKod2Id != ozelKod2Id);
    }
}