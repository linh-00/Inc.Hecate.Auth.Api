using System;
using System.Collections.Generic;
using Inc.Hecate.Auth.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Inc.Hecate.Auth.DAL.Context;

public partial class dbHecateContext : DbContext
{
    public dbHecateContext()
    {
    }

    public dbHecateContext(DbContextOptions<dbHecateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DEV03\\SQLEXPRESS;Initial Catalog=dbHecate;persist security info=True;user id=sa;password=Ehn@um11;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ACCOUNT_ID).HasName("PK__User__05B22F60AEB43A01");

            entity.Property(e => e.ACCOUNT_ID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ACCOINT_ID).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
