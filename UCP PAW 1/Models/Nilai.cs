using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class Nilai
    {
        public int IdNilai { get; set; }
        public int? JumlahNilai { get; set; }
        public int? Kkm { get; set; }
        public int? IdSiswa { get; set; }
        public int? IdMapel { get; set; }
        public int? IdGuru { get; set; }
        public string Keterangan { get; set; }

        public virtual Guru IdGuruNavigation { get; set; }
        public virtual Mapel IdMapelNavigation { get; set; }
        public virtual Siswa IdSiswaNavigation { get; set; }
    }
}
