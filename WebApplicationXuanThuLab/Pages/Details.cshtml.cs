using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationXuanThuLab.Models;

namespace WebApplicationXuanThuLab.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationXuanThuLab.Models.SinhVienContext _context;

        public DetailsModel(WebApplicationXuanThuLab.Models.SinhVienContext context)
        {
            _context = context;
        }

      public TblStudent TblStudent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblstudent = await _context.TblStudents.FirstOrDefaultAsync(m => m.StuId == id);
            if (tblstudent == null)
            {
                return NotFound();
            }
            else 
            {
                TblStudent = tblstudent;
            }
            return Page();
        }
    }
}
