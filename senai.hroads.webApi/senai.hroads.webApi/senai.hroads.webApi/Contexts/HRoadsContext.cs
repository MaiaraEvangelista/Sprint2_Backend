using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HRoadsContext : DbContext
    {
        public HRoadsContext()
        {
        }

        public HRoadsContext(DbContextOptions<HRoadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagens { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FCHJ4RD\\SQLEXPRESS; initial catalog=HRoads; user Id=sa; pwd=sa1365");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__57010672C838B322");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Cargos)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

           

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades)
                    .HasName("PK__Habilida__A5B0BFF5FBED317A");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.Técnicas)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E026A7499");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualização)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataCriação)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.ManaMáxima)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nomes)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VidaMáxima)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__Personage__idCla__3C69FB99");
            });


            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTiposHabilidades)
                    .HasName("PK__TiposHab__B078A372BFC14F32");

                entity.Property(e => e.IdTiposHabilidades).HasColumnName("idTiposHabilidades");

                entity.Property(e => e.Tipos)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__03006BFF112FEC33");

                entity.ToTable("TiposUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Tipos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A620F6BD89");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.NomeUsuario, "UQ__usuario__8C9D1DE50E6917DB")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUsuario, "UQ__usuario__ACC1DD998B7CEFC5")
                    .IsUnique();

                entity.HasIndex(e => e.SenhaUsuario, "UQ__usuario__F03EFC573503FEBC")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("emailUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senhaUsuario");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
