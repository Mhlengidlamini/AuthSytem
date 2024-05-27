﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSytem.Data;
using AuthSytem.Model;

namespace AuthSytem.Views.Farmers
{
    public class EditModel : PageModel
    {
        private readonly AuthSytem.Data.AuthDbContext _context;

        public EditModel(AuthSytem.Data.AuthDbContext context)
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

            var farmer =  await _context.Farmer.FirstOrDefaultAsync(m => m.farmer_id == id);
            if (farmer == null)
            {
                return NotFound();
            }
            Farmer = farmer;
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

            _context.Attach(Farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(Farmer.farmer_id))
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

        private bool FarmerExists(int id)
        {
            return _context.Farmer.Any(e => e.farmer_id == id);
        }
    }
}
