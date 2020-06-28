using System;
namespace BusinessDto
{
    public class UrunDto
    {
        public long id { get; set; }
        public string Name { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? InsertedDate { get; set; }
        public int StokAdet { get; set; }
        public DateTime? UrunTarihi { get; set; }
    }
}
