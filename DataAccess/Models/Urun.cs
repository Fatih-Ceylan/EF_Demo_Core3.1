using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Urun
    {
        public long Id { get; set; }
        public string Adi { get; set; }
        public int StokAdet { get; set; }
        public decimal Fiyat { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? UrunTarihi { get; set; }
    }
}
