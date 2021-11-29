using Microsoft.EntityFrameworkCore;
using QLNH_TH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {  
        }
        public DbSet<nhanvienModel> nhanviens { get; set; }
        public DbSet<bookphongModel> bookphongs { get; set; }
        public DbSet<phongModel> phongs { get; set; }
        public DbSet<sanhModel> sanhs { get; set; }
        public DbSet<tiecModel> tiecs { get; set; }
        public DbSet<khachhangModel> khachhangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<nhanvienModel>().ToTable("nhanvien");
            modelBuilder.Entity<bookphongModel>().ToTable("bookphong").HasKey(c => new { c.matiec, c.maphong });
            modelBuilder.Entity<phongModel>().ToTable("phong").HasKey(c => c.maphong);
            modelBuilder.Entity<sanhModel>().ToTable("sanh").HasKey(c => c.masanh);
            modelBuilder.Entity<tiecModel>().ToTable("tiec").HasKey(c => c.matiec);
            modelBuilder.Entity<khachhangModel>().ToTable("khachhang").HasKey(c => c.makh);
        }

    }
}
