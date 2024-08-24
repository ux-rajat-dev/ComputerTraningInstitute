using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ComputerTrainingInstitute.Models;

public partial class ComputerInstituteContext : DbContext
{
    public ComputerInstituteContext()
    {
    }

    public ComputerInstituteContext(DbContextOptions<ComputerInstituteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=computerinstitute;port=3308;user=root;password=4811", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.2.17-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.DeptId, "DeptId");

            entity.HasIndex(e => e.TeacherId, "TeacherId");

            entity.Property(e => e.CourseId)
                .HasColumnType("int(11)")
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(60);
            entity.Property(e => e.DeptId).HasColumnType("int(11)");
            entity.Property(e => e.TeacherId).HasColumnType("int(11)");

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("course_ibfk_2");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("course_ibfk_1");
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PRIMARY");

            entity.ToTable("dept");

            entity.Property(e => e.DeptId).HasColumnType("int(11)");
            entity.Property(e => e.DeptName).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("student");

            entity.HasIndex(e => e.CourseId, "CourseId");

            entity.HasIndex(e => e.RegId, "RegId_UNIQUE").IsUnique();

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.CourseId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.RegId).HasColumnType("int(11)");

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("student_ibfk_1");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.HasIndex(e => e.DeptId, "DeptId");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.DateOfJoining)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.DeptId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("teacher_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
