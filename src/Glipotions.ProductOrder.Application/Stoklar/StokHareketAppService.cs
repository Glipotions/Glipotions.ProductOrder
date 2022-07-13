
namespace Glipotions.ProductOrder.Stoklar;

public class StokHareketAppService: ProductOrderAppService, IStokHareketAppService
{
    private readonly IAlinanSiparisHareketRepository _alinanSiparisHareketRepository;

    public StokHareketAppService(IAlinanSiparisHareketRepository alinanSiparisHareketRepository)
    {
        _alinanSiparisHareketRepository = alinanSiparisHareketRepository;
    }

    public virtual async Task<PagedResultDto<ListStokHareketDto>> GetListAsync(StokHareketListParameterDto input)
    {
        var hareketler = await _alinanSiparisHareketRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
            x => x.StokId == input.StokId &&
                 x.AlinanSiparis.SubeId == input.SubeId &&
                 x.AlinanSiparis.DonemId == input.DonemId &&
                 x.AlinanSiparis.Durum,
            x => x.AlinanSiparis.Tarih,
            x => x.AlinanSiparis, x => x.Stok.Birim);

        var totalCount = await _alinanSiparisHareketRepository.CountAsync(x => x.StokId == input.StokId &&
                                                                        x.AlinanSiparis.SubeId == input.SubeId &&
                                                                        x.AlinanSiparis.DonemId == input.DonemId &&
                                                                        x.AlinanSiparis.Durum);

        var mappedDtos = ObjectMapper.Map<List<AlinanSiparisHareket>, List<ListStokHareketDto>>(hareketler);

        return new PagedResultDto<ListStokHareketDto>(totalCount, mappedDtos);
    }
    
    public Task<SelectAlinanSiparisHareketDto> GetAsync(Guid id) => throw new NotImplementedException();

    public Task<SelectAlinanSiparisHareketDto> CreateAsync(AlinanSiparisHareketDto input) => throw new NotImplementedException();

    public Task<SelectAlinanSiparisHareketDto> UpdateAsync(Guid id, AlinanSiparisHareketDto input) => throw new NotImplementedException();

    public Task DeleteAsync(Guid id) => throw new NotImplementedException();

    public Task<string> GetCodeAsync(AlinanSiparisNoParameterDto input) => throw new NotImplementedException();
}