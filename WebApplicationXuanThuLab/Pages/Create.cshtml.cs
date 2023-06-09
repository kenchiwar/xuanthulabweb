﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationXuanThuLab.Models;

namespace WebApplicationXuanThuLab.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationXuanThuLab.Models.SinhVienContext _context;

        public CreateModel(WebApplicationXuanThuLab.Models.SinhVienContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblStudent TblStudent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblStudents == null || TblStudent == null)
            {
                return Page();
            }

            _context.TblStudents.Add(TblStudent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
