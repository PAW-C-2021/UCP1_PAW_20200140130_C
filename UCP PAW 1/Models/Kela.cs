using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class Kela
    {
        public Kela()
        {
            Siswas = new HashSet<Siswa>();
        }

        public int IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public int? IdMapel { get; set; }

        public virtual Mapel IdMapelNavigation { get; set; }
        public virtual ICollection<Siswa> Siswas { get; set; }
    }
}
