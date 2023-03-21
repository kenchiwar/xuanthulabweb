using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplicationXuanThuLab.Models;

#nullable disable

namespace WebApplicationXuanThuLab.Migrations
{
    /// <inheritdoc />
    public partial class Chan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCourse",
                columns: table => new
                {
                    CouId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CouSemester = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblCours__E2AFE31AF4A72054", x => x.CouId);
                });

            migrationBuilder.CreateTable(
                name: "TblStudent",
                columns: table => new
                {
                    StuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuPass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StuAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StuPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StuEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    deptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblStude__6CDFAB955FD867BA", x => x.StuId);
                });

            migrationBuilder.CreateTable(
                name: "TblExam",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExamMark = table.Column<double>(type: "float", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: true),
                    StuId = table.Column<int>(type: "int", nullable: true),
                    CouId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    MarkPass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblExam__297521C7EA735100", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_TblExam_TblStudent",
                        column: x => x.StuId,
                        principalTable: "TblStudent",
                        principalColumn: "StuId");
                    table.ForeignKey(
                        name: "Fk_TblExam_TblCourse",
                        column: x => x.CouId,
                        principalTable: "TblCourse",
                        principalColumn: "CouId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblExam_CouId",
                table: "TblExam",
                column: "CouId");

            migrationBuilder.CreateIndex(
                name: "IX_TblExam_StuId",
                table: "TblExam",
                column: "StuId");
            Randomizer.Seed = new Random(8675309);
            var textTblStudent = new Faker<TblStudent>();
            var mia = 0;
            // textTblStudent.RuleFor(o => o.StuId, f => ++mia);
        //    textTblStudent.Locale = "vn";
            var lorem1 = new Bogus.DataSets.Lorem(locale: "vi");
            textTblStudent.RuleFor(o => o.StuPass, f => lorem1.Sentence(1,2));
            textTblStudent.RuleFor(o => o.StuAdress, f => lorem1.Sentence(1,2));
            textTblStudent.RuleFor(o => o.StuPhone, f => f.Random.Replace("0XXXXXXXXXX"));
            textTblStudent.RuleFor(o => o.StuEmail, f => f.Internet.Email());
            textTblStudent.RuleFor(o => o.StuName, f => f.Name.FullName());
            textTblStudent.RuleFor(o => o.DeptId, f => f.Random.Number(1,10));
           
            for (int i = 0; i < 150; i++)
            {
                TblStudent student = textTblStudent.Generate();
                migrationBuilder.InsertData(
                    table : "TblStudent",
                    columns : new[] {"StuPass","StuAdress","StuPhone","StuEmail","StuName", "deptId" },
                    values : new object[]
                    {
                        student.StuPass ,
                        student.StuAdress ,
                        student.StuPhone ,
                        student.StuEmail ,
                        student.StuName, 
                        student.DeptId ,
                    }
                    );
            }








        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblExam");

            migrationBuilder.DropTable(
                name: "TblStudent");

            migrationBuilder.DropTable(
                name: "TblCourse");
        }
    }
}
