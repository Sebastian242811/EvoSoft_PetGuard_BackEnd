using Microsoft.EntityFrameworkCore;
using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<PetKeeper>(1)
                .HasValue<Client>(2);
            builder.Entity<User>().HasKey(p => p.Id);
        }
    }
}
