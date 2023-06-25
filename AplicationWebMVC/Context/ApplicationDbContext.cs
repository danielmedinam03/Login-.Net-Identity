using AplicationWebMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AplicationWebMVC.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Agregar los dferentes modelos que se necesiten
        public DbSet<AppUsuario> AppUsuario { get; set; }
    }
}
