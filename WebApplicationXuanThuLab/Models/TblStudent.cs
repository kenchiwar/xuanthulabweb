using System;
using System.Collections.Generic;

namespace WebApplicationXuanThuLab.Models;

public partial class TblStudent
{
    public int StuId { get; set; }

    public string? StuPass { get; set; }

    public string? StuAdress { get; set; }

    public string? StuPhone { get; set; }

    public string? StuEmail { get; set; }

    public string? StuName { get; set; }

    public int? DeptId { get; set; }

    public virtual ICollection<TblExam> TblExams { get; } = new List<TblExam>();
}
