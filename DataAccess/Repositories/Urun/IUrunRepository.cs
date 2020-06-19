using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IUrunRepository
    {
        Urun GetUrunById(long urunId);
        Urun UrunEkle(Urun entity);
    }
}
