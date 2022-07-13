namespace Glipotions.ProductOrder.AlinanSiparisler;

public class AlinanSiparisHareketManager : DomainService
{
    private readonly IStokRepository _stokRepository;

    public AlinanSiparisHareketManager(IStokRepository stokRepository)
    {
        _stokRepository = stokRepository;
    }
    /// <ÖZET>
    /// stok, hizmet, masraf, depo kontrolü yapılır.
    /// </summary>
    /// <param name="stokId"></param>
    /// <param name="hizmetId"></param>
    /// <param name="masrafId"></param>
    /// <param name="depoId"></param>
    /// <returns></returns>
    public async Task CheckCreateAsync(Guid? stokId)
    {
        await _stokRepository.EntityAnyAsync(stokId, x => x.Id == stokId);
    }
    /// <ÖZET>
    /// stok, hizmet, masraf, depo kontrolü yapılır.
    /// </summary>
    /// <param name="stokId"></param>
    /// <param name="hizmetId"></param>
    /// <param name="masrafId"></param>
    /// <param name="depoId"></param>
    /// <returns></returns>
    public async Task CheckUpdateAsync(Guid? stokId)
    {
        await _stokRepository.EntityAnyAsync(stokId, x => x.Id == stokId);
    }
}