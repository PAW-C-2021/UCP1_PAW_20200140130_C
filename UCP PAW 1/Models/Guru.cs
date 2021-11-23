using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class Guru
    {
        public Guru()
        {
            Nilais = new HashSet<Nilai>();
        }

        public int IdGuru { get; set; }
        public int? Nip { get; set; }
        public string NamaGuru { get; set; }
        public string AlamatGuru { get; set; }
        public string NoHp { get; set; }
        public int? IdMapel { get; set; }
        public string Keterangan { get; set; }

        public virtual Mapel IdMapelNavigation { get; set; }
        public virtual ICollection<Nilai> Nilais { get; set; }
    }
}
