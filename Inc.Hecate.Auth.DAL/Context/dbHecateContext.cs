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

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<RulesUser> RulesUsers { get; set; }

    public virtual DbSet<Scope> Scopes { get; set; }

    public virtual DbSet<ScopeUser> ScopeUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DEV03\\SQLEXPRESS;Initial Catalog=dbHecate;persist security info=True;user id=sa;password=Ehn@um11;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rule>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Rules__3214EC27EAED4561");

            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CREATED_AT).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SCOPE).WithMany(p => p.Rules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RULES_SCOPE");
        });

        modelBuilder.Entity<RulesUser>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RulesUse__3214EC2714F8A4BA");

            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.RULES).WithMany(p => p.RulesUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RulesUser_Rules");

            entity.HasOne(d => d.USER).WithMany(p => p.RulesUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RulesUser_User");
        });

        modelBuilder.Entity<Scope>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Scope__3214EC2787245661");

            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CREATED_AT).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ScopeUser>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ScopeUse__3214EC2722E2F8C2");

            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.SCOPE).WithMany(p => p.ScopeUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScopeUser_Scope");

            entity.HasOne(d => d.USER).WithMany(p => p.ScopeUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScopeUser_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__User__3214EC27E9BE4156");

            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ACCOUNT_ID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CREATED_AT).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
