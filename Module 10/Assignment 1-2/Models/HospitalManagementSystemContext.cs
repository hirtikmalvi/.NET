using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1_2.Models;

public partial class HospitalManagementSystemContext : DbContext
{
    public HospitalManagementSystemContext()
    {
    }

    public HospitalManagementSystemContext(DbContextOptions<HospitalManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorPatient> DoctorPatients { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDrug> PatientDrugs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QBJ7RSI\\SQLEXPRESS;Database=HospitalManagementSystem;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED102EF9CE");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EBF6DD20F4D");

            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Doctor__Departme__1BC821DD");
        });

        modelBuilder.Entity<DoctorPatient>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DoctorId }).HasName("PK__DoctorPa__75D2C38DBF0BF184");

            entity.ToTable("DoctorPatient");

            entity.Property(e => e.AssignedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorPatients)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorPat__Docto__2B0A656D");

            entity.HasOne(d => d.Patient).WithMany(p => p.DoctorPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorPat__Patie__2A164134");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.DrugId).HasName("PK__Drug__908D661672F4B926");

            entity.ToTable("Drug");

            entity.Property(e => e.DrugName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC366C2A24C94");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientDrug>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DrugId }).HasName("PK__PatientD__EE061507C0E98AC4");

            entity.ToTable("PatientDrug");

            entity.Property(e => e.TimeOfDay)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Drug).WithMany(p => p.PatientDrugs)
                .HasForeignKey(d => d.DrugId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatientDr__DrugI__2EDAF651");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientDrugs)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatientDr__Patie__2DE6D218");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
