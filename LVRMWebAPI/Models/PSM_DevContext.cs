using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LVRMWebAPI.Models
{
    public partial class PSM_DevContext : DbContext
    {
        public PSM_DevContext()
        {
        }

        public PSM_DevContext(DbContextOptions<PSM_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TwilioOptOuts> TwilioOptOuts { get; set; }
        public DbSet<UserDeatails> UserFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:i6oix57t40.database.windows.net,1433;Database=PSM_Dev;User ID=PSMAdmin@i6oix57t40;Password=Psm_13567!;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TwilioOptOuts>(entity =>
            {
                entity.Property(e => e.DateOptedOut).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
