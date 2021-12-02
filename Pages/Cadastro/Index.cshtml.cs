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
    public class IndexModel : PageModel
    {
        private readonly CadstroBestProject.Data.BestProject _context;

        public IndexModel(CadstroBestProject.Data.BestProject context)
        {
            _context = context;
        }

        [BindProperty]
        public cadastro cadastro { get; set; }
        public IEnumerable<cadastro> Listacadastro { get;set; }

        public async Task OnGetAsync()
        {
            Listacadastro = await _context.cadastro.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int? id)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cadastro.Add(cadastro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }      

    }
}