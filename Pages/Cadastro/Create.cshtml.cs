using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CadastroBestProject.Models;
using CadstroBestProject.Data;

namespace CadastroBestProject.Pages.Cadastro
{
    public class CreateModel : PageModel
    {
        private readonly CadstroBestProject.Data.BestProject _context;

        public CreateModel(CadstroBestProject.Data.BestProject context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public cadastro cadastro { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
