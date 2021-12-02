using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CadastroBestProject.Models;
using CadstroBestProject.Data;

namespace CadastroBestProject.Pages.Cadastro
{
    public class DetailsModel : PageModel
    {
        private readonly CadstroBestProject.Data.BestProject _context;

        public DetailsModel(CadstroBestProject.Data.BestProject context)
        {
            _context = context;
        }

        public cadastro cadastro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cadastro = await _context.cadastro.FirstOrDefaultAsync(m => m.Id == id);

            if (cadastro == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cadastro = await _context.cadastro.FindAsync(id);

            if (cadastro != null)
            {
                _context.cadastro.Remove(cadastro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
