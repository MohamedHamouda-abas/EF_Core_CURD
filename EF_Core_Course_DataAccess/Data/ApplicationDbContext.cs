using EF_Core_Course_DataAccess.FluentConfig;
using EF_Core_Course_Model.Models;
using EF_Core_Course_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Course_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookDetila> bookDetilas { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            //Fluent Api To make realation many to many
            //modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, ISNB = "12AA99", Name = "ToyStory", Titel = "Story", Price = 10.50, Publisher_Id = 1 },
                new Book { BookId = 2, ISNB = "12AA99", Name = "Fortnite", Titel = "Story", Price = 10.50, Publisher_Id = 1 },
                new Book { BookId = 3, ISNB = "12AA99", Name = "Code", Titel = "Story", Price = 10.50, Publisher_Id = 2 },
                new Book { BookId = 4, ISNB = "12AA99", Name = "BattelFiled", Titel = "Story", Price = 10.50, Publisher_Id = 2 }
                );


            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Carvchal", Loction = "Usa" },
                new Publisher { Publisher_Id = 2, Name = "Mendy", Loction = "Spain" }
                );
        }
    }
}
