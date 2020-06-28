using DataAccess.Models;
using System.Collections.Generic;
namespace DataAccess.Repositories
{
    public interface IUrunSiparisRepository
    {
        List<UrunSiparis> GetUrunSiparisByUrunId(long urunId);
        UrunSiparis GetUrunSiparisByUrunSiparisId(long urunSiparisId);
        decimal GetAllUrunSiparisToplam();
        UrunSiparis UrunSiparisEkle(UrunSiparis mahmut);
    }
}
