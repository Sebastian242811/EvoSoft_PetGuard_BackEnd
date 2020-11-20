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
        public DbSet <Card> Cards { get; set; }
        public DbSet <Chat> Chats { get; set; }
        public DbSet <Client> Clients { get; set; }
        public DbSet <Message> Messages { get; set; }
        public DbSet <Payment> Payments { get; set; }
        public DbSet <Pet> Pets { get; set; }
        public DbSet <PetKeeper> PetKeepers { get; set; }
        public DbSet <Service> Services { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Card Entity
            builder.Entity<Card>().ToTable("Cards");
            //REMOVE
            builder.Entity<Card>().HasNoKey();

            //Chat Entity
            builder.Entity<Chat>().ToTable("Chats");
            //REMOVE
            builder.Entity<Chat>().HasNoKey();

            //Client Entity
            builder.Entity<Client>().HasBaseType<User>();

            //Message Entity
            builder.Entity<Message>().ToTable("Messages");
            //REMOVE
            builder.Entity<Message>().HasNoKey();

            //Payment Entity
            builder.Entity<Payment>().ToTable("Payments");
            //REMOVE
            builder.Entity<Payment>().HasNoKey();

            //Pet Entity
            builder.Entity<Pet>().ToTable("Pets");
            //REMOVE
            builder.Entity<Pet>().HasNoKey();

            //PetKeeper Entity
            builder.Entity<PetKeeper>().HasBaseType<User>();
            builder.Entity<PetKeeper>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PetKeeper>().Property(p => p.FirstName).IsRequired().HasMaxLength(40);
            builder.Entity<PetKeeper>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<PetKeeper>().Property(p => p.Email).IsRequired();
            builder.Entity<PetKeeper>().Property(p => p.Birthday).IsRequired();
            builder.Entity<PetKeeper>().Property(p => p.Password).IsRequired();
            builder.Entity<PetKeeper>().HasData
                (
                new PetKeeper { Id = 100, FirstName = "Example First Name", LastName = "Example Last Name", Email = "example@email.com", Birthday = Convert.ToDateTime("01/01/2020"), Password = "12345" }
                );

            //Service Entity
            builder.Entity<Service>().ToTable("Services");
            //REMOVE
            builder.Entity<Service>().HasNoKey();

            //User Entity
            builder.Entity<User>().ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<PetKeeper>(1)
                .HasValue<Client>(2);
            builder.Entity<User>().HasKey(p => p.Id);
        }
    }
}
