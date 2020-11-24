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
            builder.Entity<Card>().HasKey(prop => prop.Id);
            builder.Entity<Card>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Card>().Property(p => p.CardName).IsRequired();
            builder.Entity<Card>().Property(p => p.CardNumber).IsRequired();
            builder.Entity<Card>().Property(p => p.ExpDate).IsRequired();

            //Chat Entity
            builder.Entity<Chat>().ToTable("Chats");
            builder.Entity<Chat>().HasKey(p => p.Id);
            builder.Entity<Chat>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Chat>().HasData(new Chat { Id = 1, Name = "Paseo" }, new Chat { Id = 2, Name = "Cuidado" });

           //Client Entity
            builder.Entity<Client>().HasBaseType<User>();
            builder.Entity<Client>().Property(p => p.FirstName).IsRequired().HasMaxLength(40);
            builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Email).IsRequired();
            builder.Entity<Client>().Property(p => p.Birthday).IsRequired();
            builder.Entity<Client>().Property(p => p.Password).IsRequired();
            builder.Entity<Client>().HasData
                (
                new Client { Id = 101, FirstName = "Example FirstName", LastName = "Example LastName", Email = "example@email.com", Birthday = Convert.ToDateTime("01/01/2000"), Password = "54321" }
                );

            //Message Entity
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Text).IsRequired().HasMaxLength(250);
            builder.Entity<Message>().Property(p => p.File).IsRequired();
            builder.Entity<Message>().HasOne(p => p.Chat).WithMany(p => p.Messages).HasForeignKey(p => p.ChatId);
            builder.Entity<Message>().HasData(new Message { Id = 1, ChatId = 1, File = 0, ReciberId = 1, TransmitterId = 2, Text = "Hola como estas" });

           //Payment Entity
           builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p=>p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.CardId).IsRequired();
            builder.Entity<Payment>().Property(p => p.ClientId).IsRequired();
            builder.Entity<Payment>().HasOne(p => p.Client).WithMany(p => p.Payments).HasForeignKey(p=>p.ClientId);
            builder.Entity<Payment>().HasOne(p => p.Card).WithMany(p => p.Payments).HasForeignKey(p => p.CardId);

            //Pet Entity
            builder.Entity<Pet>().ToTable("Pets");
            builder.Entity<Pet>().HasKey(p => p.Id);
            builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
            builder.Entity<Pet>().Property(p => p.ClientId).IsRequired();
            builder.Entity<Pet>().HasOne(p => p.Client).WithMany(p => p.Pets).HasForeignKey(p=>p.ClientId);
            builder.Entity<Pet>().HasData(new Pet { Id = 1, Breed = EBreed.Bulldog, ClientId = 1, Name = "Jorge" });


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
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Service>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Service>().Property(p => p.Location).IsRequired().HasMaxLength(50);
            builder.Entity<Service>().Property(p => p.StartTime).IsRequired();
            builder.Entity<Service>().Property(p => p.Duration).IsRequired();
            builder.Entity<Service>().HasOne(p => p.Client)
                                     .WithMany(p => p.Services)
                                     .HasForeignKey(p => p.ClientId);
            builder.Entity<Service>().HasOne(p => p.PetKeeper)
                                     .WithMany(p => p.Services)
                                     .HasForeignKey(p => p.PetKeeperId);

            //User Entity
            builder.Entity<User>().ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<PetKeeper>(1)
                .HasValue<Client>(2);
            builder.Entity<User>().HasKey(p => p.Id);
        }
    }
}
