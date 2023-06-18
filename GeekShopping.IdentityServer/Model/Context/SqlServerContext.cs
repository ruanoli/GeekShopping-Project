using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class SqlServerContext : IdentityDbContext<ApplicationUser>
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }
    }
}



