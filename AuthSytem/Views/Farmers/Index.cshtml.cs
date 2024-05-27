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
    public class IndexModel : PageModel
    {
        private readonly AuthSytem.Data.AuthDbContext _context;

        public IndexModel(AuthSytem.Data.AuthDbContext context)
        {
            _context = context;
        }

        public IList<Farmer> Farmer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Farmer = await _context.Farmer.ToListAsync();
        }
    }
}
