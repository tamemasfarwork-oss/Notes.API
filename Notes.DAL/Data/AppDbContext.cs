using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.DAL.Entity;
using System;
using System.IO; // مهم لقراءة المسارات إذا لزم الأمر

namespace Notes.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Users> Users { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Categories> Categories { get; set; }




       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}