using System;
using System.Collections.Generic;

namespace WebApplicationXuanThuLab.Models;

public partial class TblExam
{
    public int ExamId { get; set; }

    public string? ExamName { get; set; }

    public double? ExamMark { get; set; }

    public DateTime? ExamDate { get; set; }

    public int? StuId { get; set; }

    public int? CouId { get; set; }

    public string? Comment { get; set; }

    public int? MarkPass { get; set; }

    public virtual TblCourse? Cou { get; set; }

    public virtual TblStudent? Stu { get; set; }
}
