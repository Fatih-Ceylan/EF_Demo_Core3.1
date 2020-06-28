using DataAccess.Models;
namespace DataAccess.Repositories
{
    public interface IUrunRepository
    {
        Urun GetUrunById(long urunId);
        Urun UrunEkle(Urun entity);
    }
}
