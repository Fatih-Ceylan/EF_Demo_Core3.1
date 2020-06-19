using BusinessDto.UrunIslemleri;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.Repositories
{
    public class UrunSiparisRepository : IUrunSiparisRepository
    {
        private eTicaretDBContext _context;
        public UrunSiparisRepository()
        {
            _context = new eTicaretDBContext();
        }
        public List<UrunSiparis> GetUrunSiparisByUrunId(long urunId)
        {
            return _context.UrunSiparis.Where(r => r.UrunId == urunId && r.IsDeleted == false).ToList();
        }

        public UrunSiparis GetUrunSiparisByUrunSiparisId(long urunSiparisId)
        {
            return _context.UrunSiparis.FirstOrDefault(y => y.UrunId == urunSiparisId && y.IsDeleted ==false);
        }

        public decimal GetAllUrunSiparisToplam()
        {
            return _context.UrunSiparis.Sum(x=> x.SiparisToplamFiyat);
        }

        public UrunSiparis UrunSiparisEkle(UrunSiparis mahmut)
        {
            var result= _context.UrunSiparis.Add(mahmut);
            _context.SaveChanges();
            return result.Entity;

        }
    }
}
