using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthSytem.Model;

namespace AuthSytem.Data
{
    public class AuthSytemContext : DbContext
    {
        public AuthSytemContext (DbContextOptions<AuthSytemContext> options)
            : base(options)
        {
        }

        public DbSet<AuthSytem.Model.Product> Product { get; set; } = default!;
    }
}
