using ClassroomSE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomSE
{
    public class ClassroomContext : IdentityDbContext<IdentityUser>
    {
        //for database creation
        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        { }
        public DbSet<AccountClass> AccountClasses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }

        // for many to many relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountClass>()
                .HasKey(bc => new { bc.AccountID, bc.ClassID });
            modelBuilder.Entity<AccountClass>()
                .HasOne(bc => bc.Class)
                .WithMany(b => b.AccountClasses)
                .HasForeignKey(bc => bc.ClassID);
            modelBuilder.Entity<AccountClass>()
                .HasOne(bc => bc.Account)
                .WithMany(c => c.AccountClasses)
                .HasForeignKey(bc => bc.AccountID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
