
namespace Glipotions.ProductOrder.AlinanSiparisler;

//[Authorize(ProductOrderPermissions.AlinanSiparis.Default)]
public class AlinanSiparisAppService : ProductOrderAppService, IAlinanSiparisAppService
{
    private readonly IAlinanSiparisRepository _alinanSiparisRepository;
    private readonly AlinanSiparisManager _alinanSiparisManager;
    private readonly AlinanSiparisHareketManager _alinanSiparisHareketManager;

    public AlinanSiparisAppService(IAlinanSiparisRepository faturaRepository, AlinanSiparisManager faturaManager,
        AlinanSiparisHareketManager faturaHareketManager)
    {
        _alinanSiparisRepository = faturaRepository;
        _alinanSiparisManager = faturaManager;
        _alinanSiparisHareketManager = faturaHareketManager;
    }

    /// <Özet>
    /// Parametre olarak gönderilen id'nin entity.id ye eşit olduğu entity'i geriye döndürür.
    /// ObjectMapper Entity'i Select(Entity)Dto olarak mapler.
    /// include property eklenmek, EFCoreRepository de bu işlem yapılır.
    /// AlinanSiparis Hareketler de HareketTuru nü burda doldurmak gerekir.
    public virtual async Task<SelectAlinanSiparisDto> GetAsync(Guid id)
    {
        var entity = await _alinanSiparisRepository.GetAsync(id, x => x.Id == id);

        return ObjectMapper.Map<AlinanSiparis, SelectAlinanSiparisDto>(entity);
    }
    /// <Özet>
    /// Listeyi Çağırır
    /// predicate --> filtre görebi görür
    /// <param name="input"></param>
    /// include propertyler girilir.
    /// return olarak Entity'i List(Entity)Dto ya mapleriz.
    public virtual async Task<PagedResultDto<ListAlinanSiparisDto>> GetListAsync(AlinanSiparisListParameterDto input)
    {
        var entities = await _alinanSiparisRepository.GetPagedListAsync(input.SkipCount,
            input.MaxResultCount,
            x => x.SubeId == input.SubeId &&
                 x.DonemId == input.DonemId && x.Durum == input.Durum,  
            x => x.SiparisNo,
            x => x.OzelKod1, x => x.OzelKod2);

        var totalCount = await _alinanSiparisRepository.CountAsync(
            x => x.SubeId == input.SubeId &&
                 x.DonemId == input.DonemId && x.Durum == input.Durum);

        return new PagedResultDto<ListAlinanSiparisDto>(
            totalCount,
            ObjectMapper.Map<List<AlinanSiparis>, List<ListAlinanSiparisDto>>(entities)
            );
    }

    /// <Özet>
    /// UI'dan Create(Entity)Dto gelecek bunu Entity'e mapler ve o şekilde database e gönderir
    /// Sadece Domain katmanındaki Entityler Database'e gönderilebilir, DTO lar gönderilemez.
    /// Bu nedenle Mapleme yapıldı.
    /// foreach döngüsü içinde hareketlerin kontrol işlemleri yapılır.
    /// 
    /// InsertAsync ile Databasede Create yapılmış oluyor.
    /// 
    /// Databaseden entity geliyor, 
    /// return kısmında ise bu entity'i tekrar mapleyerek Select(Entity)Dto olarak döndürüyor.
    //[Authorize(ProductOrderPermissions.AlinanSiparis.Create)]
    public virtual async Task<SelectAlinanSiparisDto> CreateAsync(CreateAlinanSiparisDto input)
    {
        await _alinanSiparisManager.CheckCreateAsync(input.AlinanSiparisNo, input.OzelKod1Id,
            input.OzelKod2Id, input.SubeId, input.DonemId);

        foreach (var alinanSiparisHareket in input.AlinanSiparisHareketler)
        {
            await _alinanSiparisHareketManager.CheckCreateAsync(alinanSiparisHareket.StokId);
        }

        var entity = ObjectMapper.Map<CreateAlinanSiparisDto, AlinanSiparis>(input);
        await _alinanSiparisRepository.InsertAsync(entity);
        return ObjectMapper.Map<AlinanSiparis, SelectAlinanSiparisDto>(entity);
    }
    /// <Özet>
    /// CheckUpdateAsync ile Manager sınıfından database kontrolü yapılır.
    /// Maplerken Elimizde 2 entity var o yüzden generic yapı kullanılmaz. 
    /// UI dan gelen input ile entity maplenir. Arada oluşan farklar update edilir.
    /// <param name="id"></param>
    /// <param name="input"></param> UI dan gelir
    /// faturaHareketDto döngüsünde bir faturaHareket entitysi elde edilir..
    /// eğer null ise fatura güncelleniyor ancak yeni bir hareket eklenecek demektir..
    /// yeni eklenecek hareketi .Add komutu ile eklenir daha sonra elde edilen entity maplenir.
    /// 
    /// deletedEntities ile faturada silinen hareketleri tutar
    /// RemoveAll ile silinir. Databaseden tam anlamıyla silinmiyor isDeleted=true durumuna getirilir.
    /// 
    /// <returns> Maplenmiş entity return edilir. </returns>
    //[Authorize(ProductOrderPermissions.AlinanSiparis.Update)]
    public virtual async Task<SelectAlinanSiparisDto> UpdateAsync(Guid id, UpdateAlinanSiparisDto input)
    {
        var entity = await _alinanSiparisRepository.GetAsync(id, x => x.Id == id,
            x => x.AlinanSiparisHareketler);

        await _alinanSiparisManager.CheckUpdateAsync(id, input.SiparisNo, entity,
            input.OzelKod1Id, input.OzelKod2Id);

        foreach (var alinanSiparisHareketDto in input.AlinanSiparisHareketler)
        {
            await _alinanSiparisHareketManager.CheckUpdateAsync(alinanSiparisHareketDto.StokId);

            var faturaHareket = entity.AlinanSiparisHareketler.FirstOrDefault(
                x => x.Id == alinanSiparisHareketDto.Id);

            if (faturaHareket == null)
            {
                entity.AlinanSiparisHareketler.Add(
                    ObjectMapper.Map<AlinanSiparisHareketDto, AlinanSiparisHareket>(alinanSiparisHareketDto));
                continue;
            }

            ObjectMapper.Map(alinanSiparisHareketDto, faturaHareket);
        }

        var deletedEntities = entity.AlinanSiparisHareketler.Where(
            x => input.AlinanSiparisHareketler.Select(y => y.Id).ToList().IndexOf(x.Id) == -1);

        entity.AlinanSiparisHareketler.RemoveAll(deletedEntities);

        ObjectMapper.Map(input, entity);
        await _alinanSiparisRepository.UpdateAsync(entity);
        return ObjectMapper.Map<AlinanSiparis, SelectAlinanSiparisDto>(entity);
    }
    /// <Özet>
    /// CheckUpdateAsync ile Manager sınıfından database kontrolü yapılır.
    //[Authorize(ProductOrderPermissions.AlinanSiparis.Delete)]
    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _alinanSiparisRepository.GetAsync(id, x => x.Id == id,
            x => x.AlinanSiparisHareketler);

        await _alinanSiparisRepository.DeleteAsync(entity);
        entity.AlinanSiparisHareketler.RemoveAll(entity.AlinanSiparisHareketler);
    }

    public virtual async Task<string> GetCodeAsync(AlinanSiparisNoParameterDto input)
    {
        return await _alinanSiparisRepository.GetCodeAsync(x => x.SiparisNo,
            x => x.SubeId == input.SubeId &&
                 x.DonemId == input.DonemId && x.Durum == input.Durum);
    }
}
