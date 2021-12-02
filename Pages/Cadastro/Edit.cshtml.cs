using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroBestProject.Models;
using CadstroBestProject.Data;

namespace CadastroBestProject.Pages.Cadastro
{
    public class EditModel : PageModel
    {
        private readonly CadstroBestProject.Data.BestProject _context;

        public EditModel(CadstroBestProject.Data.BestProject context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cadastroExists(cadastro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool cadastroExists(int id)
        {
            return _context.cadastro.Any(e => e.Id == id);
        }
    }
}
