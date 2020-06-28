using DataAccess.Models;
using System.Linq;
namespace DataAccess.Repositories
{
    public class UrunRepository : IUrunRepository
    {
        private eTicaretDBContext _context;
        public UrunRepository()
        {
            _context = new eTicaretDBContext();
        }
        public Urun GetUrunById(long urunId)
        {
            return _context.Urun.FirstOrDefault(r => r.Id == urunId && r.IsDeleted == false);
        }
        public Urun UrunEkle(Urun entity)
        {
            var result = _context.Urun.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
