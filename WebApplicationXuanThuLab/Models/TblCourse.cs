using System;
using System.Collections.Generic;

namespace WebApplicationXuanThuLab.Models;

public partial class TblCourse
{
    public int CouId { get; set; }

    public string? CouName { get; set; }

    public string? CouSemester { get; set; }

    public virtual ICollection<TblExam> TblExams { get; } = new List<TblExam>();
}
