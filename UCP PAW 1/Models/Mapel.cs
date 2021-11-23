using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class Mapel
    {
        public Mapel()
        {
            Gurus = new HashSet<Guru>();
            Kelas = new HashSet<Kela>();
            Nilais = new HashSet<Nilai>();
        }

        public int IdMapel { get; set; }
        public string NamaMapel { get; set; }

        public virtual ICollection<Guru> Gurus { get; set; }
        public virtual ICollection<Kela> Kelas { get; set; }
        public virtual ICollection<Nilai> Nilais { get; set; }
    }
}
