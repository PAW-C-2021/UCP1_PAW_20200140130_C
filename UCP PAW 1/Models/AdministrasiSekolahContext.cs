using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP_PAW_1.Models
{
    public partial class AdministrasiSekolahContext : DbContext
    {
        public AdministrasiSekolahContext()
        {
        }

        public AdministrasiSekolahContext(DbContextOptions<AdministrasiSekolahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guru> Gurus { get; set; }
        public virtual DbSet<Kela> Kelas { get; set; }
        public virtual DbSet<Mapel> Mapels { get; set; }
        public virtual DbSet<Nilai> Nilais { get; set; }
        public virtual DbSet<Siswa> Siswas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Guru>(entity =>
            {
                entity.HasKey(e => e.IdGuru);

                entity.ToTable("Guru");

                entity.Property(e => e.IdGuru)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Guru");

                entity.Property(e => e.AlamatGuru)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Guru");

                entity.Property(e => e.IdMapel).HasColumnName("Id_Mapel");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NamaGuru)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Guru");

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");

                entity.HasOne(d => d.IdMapelNavigation)
                    .WithMany(p => p.Gurus)
                    .HasForeignKey(d => d.IdMapel)
                    .HasConstraintName("FK_Guru_Mapel");
            });

            modelBuilder.Entity<Kela>(entity =>
            {
                entity.HasKey(e => e.IdKelas);

                entity.Property(e => e.IdKelas)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Kelas");

                entity.Property(e => e.IdMapel).HasColumnName("Id_Mapel");

                entity.Property(e => e.NamaKelas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kelas");

                entity.HasOne(d => d.IdMapelNavigation)
                    .WithMany(p => p.Kelas)
                    .HasForeignKey(d => d.IdMapel)
                    .HasConstraintName("FK_Kelas_Mapel");
            });

            modelBuilder.Entity<Mapel>(entity =>
            {
                entity.HasKey(e => e.IdMapel);

                entity.ToTable("Mapel");

                entity.Property(e => e.IdMapel)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Mapel");

                entity.Property(e => e.NamaMapel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Mapel");
            });

            modelBuilder.Entity<Nilai>(entity =>
            {
                entity.HasKey(e => e.IdNilai);

                entity.ToTable("Nilai");

                entity.Property(e => e.IdNilai)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Nilai");

                entity.Property(e => e.IdGuru).HasColumnName("Id_Guru");

                entity.Property(e => e.IdMapel).HasColumnName("Id_Mapel");

                entity.Property(e => e.IdSiswa).HasColumnName("Id_Siswa");

                entity.Property(e => e.JumlahNilai).HasColumnName("Jumlah_Nilai");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kkm).HasColumnName("KKM");

                entity.HasOne(d => d.IdGuruNavigation)
                    .WithMany(p => p.Nilais)
                    .HasForeignKey(d => d.IdGuru)
                    .HasConstraintName("FK_Nilai_Guru");

                entity.HasOne(d => d.IdMapelNavigation)
                    .WithMany(p => p.Nilais)
                    .HasForeignKey(d => d.IdMapel)
                    .HasConstraintName("FK_Nilai_Mapel");

                entity.HasOne(d => d.IdSiswaNavigation)
                    .WithMany(p => p.Nilais)
                    .HasForeignKey(d => d.IdSiswa)
                    .HasConstraintName("FK_Nilai_Siswa");
            });

            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.HasKey(e => e.IdSiswa);

                entity.ToTable("Siswa");

                entity.Property(e => e.IdSiswa)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Siswa");

                entity.Property(e => e.AlamatSiswa)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Siswa");

                entity.Property(e => e.IdKelas).HasColumnName("Id_Kelas");

                entity.Property(e => e.NamaSiswa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Siswa");

                entity.Property(e => e.Nis).HasColumnName("NIS");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");

                entity.HasOne(d => d.IdKelasNavigation)
                    .WithMany(p => p.Siswas)
                    .HasForeignKey(d => d.IdKelas)
                    .HasConstraintName("FK_Siswa_Kelas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
