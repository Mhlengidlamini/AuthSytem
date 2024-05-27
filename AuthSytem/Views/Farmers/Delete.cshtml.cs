using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuthSytem.Data;
using AuthSytem.Model;

namespace AuthSytem.Views.Farmers
{
    public class DeleteModel : PageModel
    {
        private readonly AuthSytem.Data.AuthDbContext _context;

        public DeleteModel(AuthSytem.Data.AuthDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Farmer Farmer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer.FirstOrDefaultAsync(m => m.farmer_id == id);

            if (farmer == null)
            {
                return NotFound();
            }
            else
            {
                Farmer = farmer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer.FindAsync(id);
            if (farmer != null)
            {
                Farmer = farmer;
                _context.Farmer.Remove(Farmer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
