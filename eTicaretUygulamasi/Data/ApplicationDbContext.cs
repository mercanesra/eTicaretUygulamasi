using eTicaretUygulamasi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTicaretUygulamasi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Products>? Products { get; set; }

        public DbSet<slider>? sliders { get; set; }


        


    }
}
