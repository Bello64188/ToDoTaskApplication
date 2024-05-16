using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApplication.Models;

namespace ToDoTaskApplication.Context
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(

            new Category { CategoryId = "work", Name = "Work" },
            new Category { CategoryId = "home", Name = "Home" },
            new Category { CategoryId = "ex", Name = "Excercise" },
            new Category { CategoryId = "shop", Name = "Shopping" },
            new Category { CategoryId = "call", Name = "Contact" }

            );

            builder.Entity<Status>().HasData(

                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "closed", Name = "Completed" }

                );

            //builder.Entity<ToDo>().HasData(

            //    new ToDo {  Id=1, Description="I have work to do today", CategoryId="work", StatusId="open"}
            //    );
        }
    }
}
