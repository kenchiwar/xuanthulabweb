﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationXuanThuLab.Models;


#nullable disable

namespace WebApplicationXuanThuLab.Migrations
{
    [DbContext(typeof(SinhVienContext))]
    partial class SinhVienContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblCourse", b =>
                {
                    b.Property<int>("CouId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouId"));

                    b.Property<string>("CouName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CouSemester")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CouId")
                        .HasName("PK__TblCours__E2AFE31AF4A72054");

                    b.ToTable("TblCourse", (string)null);
                });

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblExam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int?>("CouId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExamDate")
                        .HasColumnType("date");

                    b.Property<double?>("ExamMark")
                        .HasColumnType("float");

                    b.Property<string>("ExamName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MarkPass")
                        .HasColumnType("int");

                    b.Property<int?>("StuId")
                        .HasColumnType("int");

                    b.HasKey("ExamId")
                        .HasName("PK__TblExam__297521C7EA735100");

                    b.HasIndex("CouId");

                    b.HasIndex("StuId");

                    b.ToTable("TblExam", (string)null);
                });

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblStudent", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuId"));

                    b.Property<int?>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("deptId");

                    b.Property<string>("StuAdress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StuEmail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StuName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StuPass")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StuPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StuId")
                        .HasName("PK__TblStude__6CDFAB955FD867BA");

                    b.ToTable("TblStudent", (string)null);
                });

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblExam", b =>
                {
                    b.HasOne("WebApplicationXuanThuLab.Models.TblCourse", "Cou")
                        .WithMany("TblExams")
                        .HasForeignKey("CouId")
                        .HasConstraintName("Fk_TblExam_TblCourse");

                    b.HasOne("WebApplicationXuanThuLab.Models.TblStudent", "Stu")
                        .WithMany("TblExams")
                        .HasForeignKey("StuId")
                        .HasConstraintName("FK_TblExam_TblStudent");

                    b.Navigation("Cou");

                    b.Navigation("Stu");
                });

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblCourse", b =>
                {
                    b.Navigation("TblExams");
                });

            modelBuilder.Entity("WebApplicationXuanThuLab.Models.TblStudent", b =>
                {
                    b.Navigation("TblExams");
                });
#pragma warning restore 612, 618
        }
    }
}
