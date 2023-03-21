using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationXuanThuLab.Models;

public partial class SinhVienContext : DbContext
{
    public SinhVienContext()
    {
    }

    public SinhVienContext(DbContextOptions<SinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblExam> TblExams { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=LAPTOP-DIKQPO3G;initial catalog=SinhVien1;TrustServerCertificate=True;user id=sa;password=kenchiwar3234;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CouId).HasName("PK__TblCours__E2AFE31AF4A72054");

            entity.ToTable("TblCourse");

            entity.Property(e => e.CouName).HasMaxLength(50);
            entity.Property(e => e.CouSemester).HasMaxLength(50);
        });

        modelBuilder.Entity<TblExam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__TblExam__297521C7EA735100");

            entity.ToTable("TblExam");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.ExamDate).HasColumnType("date");
            entity.Property(e => e.ExamName).HasMaxLength(50);

            entity.HasOne(d => d.Cou).WithMany(p => p.TblExams)
                .HasForeignKey(d => d.CouId)
                .HasConstraintName("Fk_TblExam_TblCourse");

            entity.HasOne(d => d.Stu).WithMany(p => p.TblExams)
                .HasForeignKey(d => d.StuId)
                .HasConstraintName("FK_TblExam_TblStudent");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StuId).HasName("PK__TblStude__6CDFAB955FD867BA");

            entity.ToTable("TblStudent");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.StuAdress).HasMaxLength(50);
            entity.Property(e => e.StuEmail).HasMaxLength(50);
            entity.Property(e => e.StuName).HasMaxLength(50);
            entity.Property(e => e.StuPass).HasMaxLength(50);
            entity.Property(e => e.StuPhone).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
