using System;
using System.Collections.Generic;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class UniversitateContext : DbContext
{
    public UniversitateContext()
    {
    }

    public UniversitateContext(DbContextOptions<UniversitateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grupa> Grupas { get; set; }

    public virtual DbSet<Materie> Materies { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Ora> Oras { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grupa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grupa__3214EC079DCD5C72");

            entity.ToTable("Grupa");

            entity.Property(e => e.Denumire)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("denumire");
        });

        modelBuilder.Entity<Materie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materie__3214EC07B1F3528C");

            entity.ToTable("Materie");

            entity.Property(e => e.Nume)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nume");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Note__3214EC07DEAD9391");

            entity.ToTable("Note");

            entity.Property(e => e.MaterieId).HasColumnName("materieId");
            entity.Property(e => e.Nota).HasColumnName("nota");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Materie).WithMany(p => p.Notes)
                .HasForeignKey(d => d.MaterieId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Note__materieId__49C3F6B7");

            entity.HasOne(d => d.Student).WithMany(p => p.Notes)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Note__studentId__48CFD27E");
        });

        modelBuilder.Entity<Ora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Oras__3214EC0709BB6517");

            entity.Property(e => e.Denumire)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("denumire");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07E4F537AD");

            entity.ToTable("Student");

            entity.Property(e => e.GrupaId).HasColumnName("grupaId");
            entity.Property(e => e.Nume)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nume");
            entity.Property(e => e.OrasId).HasColumnName("orasId");
            entity.Property(e => e.Prenume)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prenume");

            entity.HasOne(d => d.Grupa).WithMany(p => p.Students)
                .HasForeignKey(d => d.GrupaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Student__grupaId__44FF419A");

            entity.HasOne(d => d.Oras).WithMany(p => p.Students)
                .HasForeignKey(d => d.OrasId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Student__orasId__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
