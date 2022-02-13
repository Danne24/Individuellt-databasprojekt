using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Individuellt_databasprojekt_DbContext : DbContext
    {
        public Individuellt_databasprojekt_DbContext()
        {
        }

        public Individuellt_databasprojekt_DbContext(DbContextOptions<Individuellt_databasprojekt_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BetygNamnTbl> BetygNamnTbl { get; set; }
        public virtual DbSet<BetygOchElevTbl> BetygOchElevTbl { get; set; }
        public virtual DbSet<BetygOchKursTbl> BetygOchKursTbl { get; set; }
        public virtual DbSet<BetygOchPersonalTbl> BetygOchPersonalTbl { get; set; }
        public virtual DbSet<BetygTbl> BetygTbl { get; set; }
        public virtual DbSet<ElevOchKursTbl> ElevOchKursTbl { get; set; }
        public virtual DbSet<ElevTbl> ElevTbl { get; set; }
        public virtual DbSet<KursTbl> KursTbl { get; set; }
        public virtual DbSet<PersonalTbl> PersonalTbl { get; set; }
        public virtual DbSet<PersonalYrkesrollTbl> PersonalYrkesrollTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-5CMCK84;Initial Catalog=Gymnasieskola;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetygNamnTbl>(entity =>
            {
                entity.HasKey(e => e.BetygNamnId);

                entity.ToTable("Betyg_Namn_tbl");

                entity.Property(e => e.BetygNamnId)
                    .HasColumnName("Betyg_Namn_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BetygNamnBokstav)
                    .HasColumnName("Betyg_Namn_Bokstav")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BetygOchElevTbl>(entity =>
            {
                entity.HasKey(e => e.BetygOchElevId);

                entity.ToTable("Betyg_Och_Elev_tbl");

                entity.Property(e => e.BetygOchElevId)
                    .HasColumnName("Betyg_Och_Elev_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BetygOchElevBetygElevFk).HasColumnName("Betyg_Och_Elev_Betyg_Elev_FK");

                entity.Property(e => e.BetygOchElevBetygFk).HasColumnName("Betyg_Och_Elev_Betyg_FK");

                entity.HasOne(d => d.BetygOchElevBetygElevFkNavigation)
                    .WithMany(p => p.BetygOchElevTbl)
                    .HasForeignKey(d => d.BetygOchElevBetygElevFk)
                    .HasConstraintName("FK_Betyg_Och_Elev_tbl_Elev_tbl");

                entity.HasOne(d => d.BetygOchElevBetygFkNavigation)
                    .WithMany(p => p.BetygOchElevTbl)
                    .HasForeignKey(d => d.BetygOchElevBetygFk)
                    .HasConstraintName("FK_Betyg_Och_Elev_tbl_Betyg_tbl");
            });

            modelBuilder.Entity<BetygOchKursTbl>(entity =>
            {
                entity.HasKey(e => e.BetygOchKursId);

                entity.ToTable("Betyg_Och_Kurs_tbl");

                entity.Property(e => e.BetygOchKursId)
                    .HasColumnName("Betyg_Och_Kurs_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BetygOchKursBetygFk).HasColumnName("Betyg_Och_Kurs_Betyg_FK");

                entity.Property(e => e.BetygOchKursKursFk).HasColumnName("Betyg_Och_Kurs_Kurs_FK");

                entity.HasOne(d => d.BetygOchKursBetygFkNavigation)
                    .WithMany(p => p.BetygOchKursTbl)
                    .HasForeignKey(d => d.BetygOchKursBetygFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Och_Kurs_tbl_Betyg_tbl");

                entity.HasOne(d => d.BetygOchKursKursFkNavigation)
                    .WithMany(p => p.BetygOchKursTbl)
                    .HasForeignKey(d => d.BetygOchKursKursFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Och_Kurs_tbl_Kurs_tbl");
            });

            modelBuilder.Entity<BetygOchPersonalTbl>(entity =>
            {
                entity.HasKey(e => e.BetygOchPersonalId);

                entity.ToTable("Betyg_Och_Personal_tbl");

                entity.Property(e => e.BetygOchPersonalId)
                    .HasColumnName("Betyg_Och_Personal_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BetygOchPersonalBetygFk).HasColumnName("Betyg_Och_Personal_Betyg_FK");

                entity.Property(e => e.BetygOchPersonalPersonalFk).HasColumnName("Betyg_Och_Personal_Personal_FK");

                entity.HasOne(d => d.BetygOchPersonalBetygFkNavigation)
                    .WithMany(p => p.BetygOchPersonalTbl)
                    .HasForeignKey(d => d.BetygOchPersonalBetygFk)
                    .HasConstraintName("FK_Betyg_Och_Personal_tbl_Betyg_tbl");

                entity.HasOne(d => d.BetygOchPersonalPersonalFkNavigation)
                    .WithMany(p => p.BetygOchPersonalTbl)
                    .HasForeignKey(d => d.BetygOchPersonalPersonalFk)
                    .HasConstraintName("FK_Betyg_Och_Personal_tbl_Personal_tbl");
            });

            modelBuilder.Entity<BetygTbl>(entity =>
            {
                entity.HasKey(e => e.BetygId)
                    .HasName("PK_Betyg");

                entity.ToTable("Betyg_tbl");

                entity.Property(e => e.BetygId)
                    .HasColumnName("Betyg_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BetygNamnFk).HasColumnName("Betyg_Namn_FK");

                entity.Property(e => e.Betygsdatum).HasColumnType("date");

                entity.HasOne(d => d.BetygNamnFkNavigation)
                    .WithMany(p => p.BetygTbl)
                    .HasForeignKey(d => d.BetygNamnFk)
                    .HasConstraintName("FK_Betyg_tbl_Betyg_Namn_tbl");
            });

            modelBuilder.Entity<ElevOchKursTbl>(entity =>
            {
                entity.HasKey(e => e.ElevKursId)
                    .HasName("PK_Elev_Kurs_tbl");

                entity.ToTable("Elev_Och_Kurs_tbl");

                entity.Property(e => e.ElevKursId)
                    .HasColumnName("Elev_Kurs_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ElevFk).HasColumnName("Elev_FK");

                entity.Property(e => e.KursFk).HasColumnName("Kurs_FK");

                entity.HasOne(d => d.ElevFkNavigation)
                    .WithMany(p => p.ElevOchKursTbl)
                    .HasForeignKey(d => d.ElevFk)
                    .HasConstraintName("FK_Elev_Och_Kurs_tbl_Elev_tbl");

                entity.HasOne(d => d.KursFkNavigation)
                    .WithMany(p => p.ElevOchKursTbl)
                    .HasForeignKey(d => d.KursFk)
                    .HasConstraintName("FK_Elev_Kurs_tbl_Kurs_tbl");
            });

            modelBuilder.Entity<ElevTbl>(entity =>
            {
                entity.HasKey(e => e.ElevId);

                entity.ToTable("Elev_tbl");

                entity.Property(e => e.ElevId)
                    .HasColumnName("Elev_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ElevEfternamn)
                    .HasColumnName("Elev_Efternamn")
                    .HasMaxLength(50);

                entity.Property(e => e.ElevFörnamn)
                    .HasColumnName("Elev_Förnamn")
                    .HasMaxLength(50);

                entity.Property(e => e.ElevKlass)
                    .HasColumnName("Elev_Klass")
                    .HasMaxLength(50);

                entity.Property(e => e.ElevKön)
                    .HasColumnName("Elev_Kön")
                    .HasMaxLength(50);

                entity.Property(e => e.ElevPersonnummer).HasColumnName("Elev_Personnummer");
            });

            modelBuilder.Entity<KursTbl>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK_Nuvarande_Kurs");

                entity.ToTable("Kurs_tbl");

                entity.Property(e => e.KursId)
                    .HasColumnName("Kurs_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kursnamn).HasMaxLength(50);

                entity.Property(e => e.ÄrKursenAktiv).HasColumnName("Är_Kursen_Aktiv");
            });

            modelBuilder.Entity<PersonalTbl>(entity =>
            {
                entity.HasKey(e => e.PersonalId);

                entity.ToTable("Personal_tbl");

                entity.Property(e => e.PersonalId)
                    .HasColumnName("Personal_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PersonalBörjadeJobbaDatum)
                    .HasColumnName("Personal_Började_Jobba_Datum")
                    .HasColumnType("date");

                entity.Property(e => e.PersonalEfternamn)
                    .HasColumnName("Personal_Efternamn")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalFörnamn)
                    .HasColumnName("Personal_Förnamn")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalKön)
                    .HasColumnName("Personal_Kön")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalMånadslön)
                    .HasColumnName("Personal_Månadslön")
                    .HasColumnType("money");

                entity.Property(e => e.PersonalTillhörAvdelning)
                    .HasColumnName("Personal_Tillhör_Avdelning")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalYrkesrollFk).HasColumnName("Personal_Yrkesroll_FK");

                entity.HasOne(d => d.PersonalYrkesrollFkNavigation)
                    .WithMany(p => p.PersonalTbl)
                    .HasForeignKey(d => d.PersonalYrkesrollFk)
                    .HasConstraintName("FK_Personal_tbl_Personal_Yrkesroll_tbl");
            });

            modelBuilder.Entity<PersonalYrkesrollTbl>(entity =>
            {
                entity.HasKey(e => e.PersonalYrkesrollId);

                entity.ToTable("Personal_Yrkesroll_tbl");

                entity.Property(e => e.PersonalYrkesrollId)
                    .HasColumnName("Personal_Yrkesroll_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PersonalYrkesrollNamn)
                    .HasColumnName("Personal_Yrkesroll_Namn")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
