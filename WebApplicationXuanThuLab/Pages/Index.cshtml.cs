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
    public class IndexModel : PageModel
    {
        private readonly WebApplicationXuanThuLab.Models.SinhVienContext _context;

        public IndexModel(WebApplicationXuanThuLab.Models.SinhVienContext context)
        {
            _context = context;
        }

        public IList<TblStudent> TblStudent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblStudents != null)
            {
                TblStudent = await _context.TblStudents.ToListAsync();
            }
        }
    }
}
