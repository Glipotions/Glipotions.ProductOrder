using AutoMapper;

namespace Glipotions.ProductOrder;

public class ProductOrderApplicationAutoMapperProfile : Profile
{
    public ProductOrderApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Birim
        CreateMap<Birim, SelectBirimDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
        CreateMap<Birim, ListBirimDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
        CreateMap<CreateBirimDto, Birim>();
        CreateMap<UpdateBirimDto, Birim>();
        CreateMap<SelectBirimDto, CreateBirimDto>();
        CreateMap<SelectBirimDto, UpdateBirimDto>();

        // Donem
        CreateMap<Donem, SelectDonemDto>();
        CreateMap<Donem, ListDonemDto>();
        CreateMap<CreateDonemDto, Donem>();
        CreateMap<UpdateDonemDto, Donem>();
        CreateMap<SelectDonemDto, CreateDonemDto>();
        CreateMap<SelectDonemDto, UpdateDonemDto>();

        // AlinanSiparis

        CreateMap<AlinanSiparis, SelectAlinanSiparisDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<AlinanSiparis, ListAlinanSiparisDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateAlinanSiparisDto, AlinanSiparis>();
        // sadece delete olanların silinmesi için ignore yapılır. (2/5) 13.Video 32.Dk
        CreateMap<UpdateAlinanSiparisDto, AlinanSiparis>()
            .ForMember(x => x.AlinanSiparisHareketler, y => y.Ignore());
        CreateMap<SelectAlinanSiparisDto, CreateAlinanSiparisDto>();
        CreateMap<SelectAlinanSiparisDto, UpdateAlinanSiparisDto>();
        CreateMap<SelectAlinanSiparisDto, AlinanSiparisReportDto>();

        //AlinanSiparis Hareket
        CreateMap<AlinanSiparisHareket, SelectAlinanSiparisHareketDto>()
            .ForMember(x => x.StokKodu, y => y.MapFrom(z => z.Stok.Kod))
            .ForMember(x => x.StokAdi, y => y.MapFrom(z => z.Stok.Ad))
            .ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Stok != null ? z.Stok.Birim.Ad : null))
            .ForMember(x => x.HareketKodu, y => y.MapFrom(z => z.Stok != null ? z.Stok.Kod : null))
            .ForMember(x => x.HareketAdi, y => y.MapFrom(z => z.Stok != null ? z.Stok.Ad : null));

        CreateMap<AlinanSiparisHareketDto, AlinanSiparisHareket>();
        CreateMap<SelectAlinanSiparisHareketDto, AlinanSiparisHareketDto>();
        CreateMap<SelectAlinanSiparisHareketDto, SelectAlinanSiparisHareketDto>();
        CreateMap<SelectAlinanSiparisHareketDto, AlinanSiparisHareketReportDto>();

        CreateMap<AlinanSiparisHareket, ListStokHareketDto>()
            .ForMember(x => x.Tarih, y => y.MapFrom(z => z.AlinanSiparis.Tarih))
            .ForMember(x => x.BelgeNo, y => y.MapFrom(z => z.AlinanSiparis.SiparisNo))
            .ForMember(x => x.Tutar, y => y.MapFrom(z => z.AlinanSiparis.NetTutar))
            .ForMember(x => x.Aciklama,
                y => y.MapFrom(z => string.IsNullOrEmpty(z.AlinanSiparis.Aciklama) ? z.Aciklama : z.AlinanSiparis.Aciklama));

        //OzelKod
        CreateMap<OzelKod, SelectOzelKodDto>();
        CreateMap<OzelKod, ListOzelKodDto>();
        CreateMap<CreateOzelKodDto, OzelKod>();
        CreateMap<UpdateOzelKodDto, OzelKod>();
        CreateMap<SelectOzelKodDto, CreateOzelKodDto>();
        CreateMap<SelectOzelKodDto, UpdateOzelKodDto>();

        //Stok
        CreateMap<Stok, SelectStokDto>()
            .ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<Stok, ListStokDto>()
            .ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
            //.ForMember(x => x.Giren, y => y.MapFrom(z => z.AlinanSiparisHareketler
            //    .Where(x => x.AlinanSiparis.AlinanSiparisTuru == AlinanSiparisTuru.Alis).Sum(x => x.Miktar)))
            //.ForMember(x => x.Cikan, y => y.MapFrom(z => z.AlinanSiparisHareketler
            //    .Where(x => x.AlinanSiparis.AlinanSiparisTuru == AlinanSiparisTuru.Satis).Sum(x => x.Miktar)))
            ;

        CreateMap<CreateStokDto, Stok>();
        CreateMap<UpdateStokDto, Stok>();
        CreateMap<SelectStokDto, CreateStokDto>();
        CreateMap<SelectStokDto, UpdateStokDto>();

        // Sube
        CreateMap<Sube, SelectSubeDto>();
        CreateMap<Sube, ListSubeDto>();
        CreateMap<CreateSubeDto, Sube>();
        CreateMap<UpdateSubeDto, Sube>();
        CreateMap<SelectSubeDto, CreateSubeDto>();
        CreateMap<SelectSubeDto, UpdateSubeDto>();


    }
}
