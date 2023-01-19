using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Freelancer_Deploy.Models;

public partial class FreelancedbContext : DbContext
{
    public FreelancedbContext()
    {
    }

    public FreelancedbContext(DbContextOptions<FreelancedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UsuarioModel> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:freelancedb.database.windows.net,1433;Initial Catalog=freelancedb;Persist Security Info=False;User ID=freelancedb;Password=invoicedb1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Currency).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.DocNumber).HasMaxLength(100);
            entity.Property(e => e.DocType).HasMaxLength(255);
            entity.Property(e => e.Logo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.TotalAmmount).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
