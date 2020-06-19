using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UrunSiparis
    {
        public long Id { get; set; }
        public long UrunId { get; set; }
        public int SiparisMiktari { get; set; }
        public decimal SiparisToplamFiyat { get; set; }
        public decimal SiparisBirimFiyat { get; set; }
        public bool IsDeleted { get; set; }
    }
}
