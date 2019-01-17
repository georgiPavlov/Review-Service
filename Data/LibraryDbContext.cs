using LibraryData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryDbContext : IdentityDbContext<User>
    {

        // add a constructor
        public LibraryDbContext(DbContextOptions options) : base(options) // take the options and pass to the base class constructor (DbContext)
        {
            // where will you use this class? Could inject directly into controllers, but
            // we already have an abstraction injected into controllers - the interfaces.
            // we should create an interface that can talk to the databse.
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<SettingsDataModel> Settings { get; set; }
    }
}
