using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.DAL.Entity;
using System;
using System.IO; // مهم لقراءة المسارات إذا لزم الأمر

namespace Notes.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // بناء وقراءة ملف appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // يفضل تحديد مسار التشغيل الحالي بدقة
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // استخدام الاسم المطابق لما كتبته في appsettings.json تماماً (اخترنا هنا contsr)
            var connectionString = config.GetSection("contsr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}