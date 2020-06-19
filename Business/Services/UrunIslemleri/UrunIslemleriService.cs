using BusinessDto;
using BusinessDto.UrunIslemleri;
using DataAccess.Repositories;
using System.Linq;
namespace Business.Services.UrunIslemleri
{
    public class UrunIslemleriService : IUrunIslemleriService
    {
        private readonly IUrunRepository _urunRepository;
        private readonly IUrunSiparisRepository _urunSiparisRepository;
        public UrunIslemleriService(IUrunRepository urunRepository, IUrunSiparisRepository urunSiparisRepository)
        {
            this._urunRepository = urunRepository;
            this._urunSiparisRepository = urunSiparisRepository;
        }
        public SiparisDetayDto SiparisDetayGetir(long urunId)
        {
            var result = new SiparisDetayDto();
            var urun = _urunRepository.GetUrunById(urunId);
            if (urun == null)
            {
                //Throw Exception here
            }
            result.UrunId = urun.Id;
            result.UrunAdi = urun.Adi;
            var urunSiparisler =
                _urunSiparisRepository.GetUrunSiparisByUrunId(urunId);
            if (urunSiparisler.Any())
            {
                urunSiparisler.ForEach((x) =>
                {
                    result.Siparisler.Add(new SiparisDto
                    {
                        UrunSiparisAdet = x.SiparisMiktari,
                        UrunSiparisID = x.Id,
                        UrunSiparisToplam = x.SiparisToplamFiyat,
                        UrunSiparisBirimFiyat = x.SiparisBirimFiyat
                    });
                });
            }
            return result;
        }
        public UrunDto GetUrunSiparisIdGetir(long urunSiparisId)
        {
            var urunSiparis = _urunSiparisRepository.GetUrunSiparisByUrunSiparisId(urunSiparisId);
            if (urunSiparis == null)
            {
                //throw ex
            }
            var urun = _urunRepository.GetUrunById(urunSiparis.UrunId);
            return new UrunDto { id = urun.Id, Name = urun.Adi };
        }
        public decimal GetAllUrunToplamSiparis()
        {
            return _urunSiparisRepository.GetAllUrunSiparisToplam();
        }
        public UrunDto UrunEkle(UrunDto urunDto)
        {
            var response = _urunRepository.UrunEkle(new DataAccess.Models.Urun
            {
                Adi = urunDto.Name,
                IsDeleted = false,
                Fiyat = urunDto.Fiyat,
                InsertedDate = urunDto.InsertedDate,
                UrunTarihi = urunDto.UrunTarihi,
                StokAdet = urunDto.StokAdet
            });
            return new UrunDto
            { 
                id = response.Id,
                Name = response.Adi,
                Fiyat = response.Fiyat,
                InsertedDate = response.InsertedDate,
                UrunTarihi = response.UrunTarihi,
                StokAdet = response.StokAdet
            };
        }
        public SiparisDto SiparisVer(long urunId)
        {
            var urun = _urunRepository.GetUrunById(urunId);
            if (urun == null)
            {
                throw new System.Exception("Ürün Bulunamadı");
            }
            if (urun.StokAdet > 0)
            {
                var urunSiparisResult = _urunSiparisRepository.UrunSiparisEkle(new DataAccess.Models.UrunSiparis
                {
                    IsDeleted = false,
                    UrunId = urun.Id,
                    SiparisMiktari = 1,
                    SiparisBirimFiyat = urun.Fiyat,
                    SiparisToplamFiyat = urun.Fiyat * 1,
                });
                return new SiparisDto
                {
                    UrunSiparisAdet = urunSiparisResult.SiparisMiktari,
                    UrunSiparisBirimFiyat = urunSiparisResult.SiparisBirimFiyat,
                    UrunSiparisToplam = urunSiparisResult.SiparisToplamFiyat,
                    UrunSiparisID = urunSiparisResult.Id
                };
            }
            else
            {
                throw new System.Exception("Stokta Yok");
            }
        }
    }
}
