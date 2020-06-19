using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
