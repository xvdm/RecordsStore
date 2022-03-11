using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RecordsStoreExam
{
    public partial class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
        {
        }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-A9TP3CP;Database=MusicStore;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.IdBand).HasColumnName("Id_Band");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhotoUri).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PrimeCost).HasColumnType("money");

                entity.HasOne(d => d.IdBandNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdBand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Records_Bands");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.DateOfSale).HasColumnType("date");

                entity.Property(e => e.IdRecord).HasColumnName("Id_Record");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdRecord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Records");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
