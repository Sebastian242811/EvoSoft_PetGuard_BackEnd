using Microsoft.EntityFrameworkCore;
using PetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<Card> Cards { get; set; }
        DbSet<Chat> Chats { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Card>().ToTable("Cards");
            builder.Entity<Card>().HasKey(p => p.CardId);
            builder.Entity<Card>().Property(p => p.CardId).ValueGeneratedOnAdd();
            builder.Entity<Card>().Property(p => p.CardName).IsRequired();
            builder.Entity<Card>().Property(p => p.CardNumber).IsRequired();
            builder.Entity<Card>().Property(p => p.ExpireDate).IsRequired();


            builder.Entity<Chat>().ToTable("Chats");
            builder.Entity<Chat>().HasKey(p=>p.ChatId);
            builder.Entity<Chat>().Property(p => p.ChatId).ValueGeneratedOnAdd();


            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p=>p.MessageId);
            builder.Entity<Message>().Property(p => p.MessageId).ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Text).IsRequired();
            builder.Entity<Message>().Property(p => p.File).IsRequired();
            builder.Entity<Message>().Property(p => p.ChatId).IsRequired();


            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p=>p.PaymentId);
            builder.Entity<Payment>().Property(p => p.PaymentId).ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.PaymentDetail).IsRequired();
            builder.Entity<Payment>().Property(p => p.Date).IsRequired();
            builder.Entity<Payment>().Property(p => p.TotalAmmount).IsRequired();
            builder.Entity<Payment>().Property(p => p.CardId).IsRequired();


            builder.Entity<Pet>().ToTable("Pets");
            builder.Entity<Pet>().HasKey(p => p.PetId);
            builder.Entity<Pet>().Property(p => p.PetId).ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
        }
    }
}
