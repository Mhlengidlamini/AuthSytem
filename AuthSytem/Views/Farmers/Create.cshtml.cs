using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuthSytem.Data;
using AuthSytem.Model;

namespace AuthSytem.Views.Farmers
{
    public class CreateModel : PageModel
    {
        private readonly AuthSytem.Data.AuthDbContext _context;

        public CreateModel(AuthSytem.Data.AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Farmer Farmer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Farmer.Add(Farmer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
