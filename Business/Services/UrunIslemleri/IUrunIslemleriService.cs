using BusinessDto;
using BusinessDto.UrunIslemleri;

namespace Business.Services.UrunIslemleri
{
    public interface IUrunIslemleriService
    {
        SiparisDetayDto SiparisDetayGetir(long urunId);
        UrunDto GetUrunSiparisIdGetir(long urunSiparisId);
        decimal GetAllUrunToplamSiparis();
        SiparisDto SiparisVer(long urunId);
        UrunDto UrunEkle(UrunDto urunDto);
    }
}
