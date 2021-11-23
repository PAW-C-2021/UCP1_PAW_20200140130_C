using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class Siswa
    {
        public Siswa()
        {
            Nilais = new HashSet<Nilai>();
        }

        public int IdSiswa { get; set; }
        public int? Nis { get; set; }
        public string NamaSiswa { get; set; }
        public string AlamatSiswa { get; set; }
        public string NoHp { get; set; }
        public int? IdKelas { get; set; }

        public virtual Kela IdKelasNavigation { get; set; }
        public virtual ICollection<Nilai> Nilais { get; set; }
    }
}
