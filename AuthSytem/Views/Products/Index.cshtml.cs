using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuthSytem.Data;
using AuthSytem.Model;

namespace AuthSytem.Views.Products
{
    public class IndexModel : PageModel
    {
        private readonly AuthSytem.Data.AuthSytemContext _context;

        public IndexModel(AuthSytem.Data.AuthSytemContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
