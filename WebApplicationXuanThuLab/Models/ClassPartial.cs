using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationXuanThuLab.Models;


public class ClassPartial
{
    [DisplayName("Id")]
    public int StuId { get; set; }
    [DisplayName("PassWord  ")]
    public string? StuPass { get; set; }
    [DisplayName("Adress ")]
    public string? StuAdress { get; set; }
    [DisplayName("Phone ")]
    [MinLength(5)]
    public string? StuPhone { get; set; }
    [DisplayName("Email")]
    public string? StuEmail { get; set; }
    [DisplayName("Full Name")]
    public string? StuName { get; set; }
    [DisplayName("Dept")]
    public int? DeptId { get; set; }

}
[ModelMetadataType(typeof(ClassPartial))]
public partial class TblStudent
{

}