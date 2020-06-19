using System;
using System.Collections.Generic;
using System.Text;
namespace BusinessDto.UrunIslemleri
{
    public class SiparisDetayDto
    {
        public SiparisDetayDto()
        {
            Siparisler = new List<SiparisDto>();
        }
        public long UrunId { get; set; }
        public string UrunAdi { get; set; }
        public List<SiparisDto> Siparisler { get; set; }
    }
    public class SiparisDto
    {
        public long UrunSiparisID { get; set; }
        public int UrunSiparisAdet { get; set; }
        public decimal UrunSiparisToplam { get; set; }
        public decimal UrunSiparisBirimFiyat { get; set; }
    }
}
