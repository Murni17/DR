using System;
using System.Collections.Generic;

namespace DRBAPI.Models
{
    public partial class Cabang
    {
        public string KodeCabang { get; set; } = null!;
        public string? NamaCabang { get; set; }
        public string? Alamat { get; set; }
        public string? Wilayah { get; set; }
    }
}
