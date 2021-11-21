using IJA9WQ_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Data
{
    public class WeddingDbContext : DbContext
    {
        public virtual DbSet<Husband> Husbands { get; set; }
        public virtual DbSet<Wife> Wives { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }

        public WeddingDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Wedding>(entity =>
            {
                entity
                .HasOne(wedding => wedding.Husband)
                .WithOne(husband => husband.Wedding)
                .HasForeignKey<Wedding>(wedding => wedding.HusbandID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(wedding => wedding.Wife)
                .WithOne(wife => wife.Wedding)
                .HasForeignKey<Wedding>(wedding => wedding.WifeID)
                .OnDelete(DeleteBehavior.Restrict);



            });

            modelBuilder.Entity<Husband>(entity =>
            {
                entity
                .HasOne(husband => husband.Wife)
                .WithOne(wife => wife.Husband)
                .HasForeignKey<Husband>(husband => husband.WifeID)
                .OnDelete(DeleteBehavior.Restrict);
                            

            });

            Husband husb1 = new Husband() { Id = 1, WifeID =3, Name = "Peter Thompson", Age = 18 };
            Husband husb2 = new Husband() { Id = 2, WifeID = 1, Name = "John Tanner", Age = 23 };
            Husband husb3 = new Husband() { Id = 3, WifeID =5, Name="Martin Smith", Age =35 };
            Husband husb4 = new Husband() { Id = 4, WifeID =4, Name="Shawn Martinez", Age =40 };
            Husband husb5 = new Husband() { Id = 5, WifeID =2, Name="William Tenorman", Age =29 };

            Wife wife1 = new Wife() { Id = 1,  Name ="Janett Brown", Age =20 };
            Wife wife2 = new Wife() { Id = 2,  Name = "Natalie Jones", Age =26 };
            Wife wife3 = new Wife() { Id = 3,  Name = "Luna Garcia", Age =18 };
            Wife wife4 = new Wife() { Id = 4,  Name = "Sofia White", Age =38 };
            Wife wife5 = new Wife() { Id = 5,  Name = "Victoria Davis", Age =27 };


            Wedding wedd1 = new Wedding() { Id = 1, HusbandID=1,WifeID=3,Place="London",Price=10000 };
            Wedding wedd2 = new Wedding() { Id = 2, HusbandID =2, WifeID =1, Place ="Denver", Price =35000 };
            Wedding wedd3 = new Wedding() { Id = 3, HusbandID =3, WifeID =5, Place ="San Francisco", Price =25000 };
            Wedding wedd4 = new Wedding() { Id = 4, HusbandID =4, WifeID =4, Place ="New York", Price =50000 };
            Wedding wedd5 = new Wedding() { Id = 5, HusbandID =5, WifeID =2, Place ="Las Vegas", Price = 500};
           
            modelBuilder.Entity<Wedding>().HasData(wedd1, wedd2, wedd3, wedd4, wedd5);
            modelBuilder.Entity<Husband>().HasData(husb1, husb2, husb3, husb4, husb5);
            modelBuilder.Entity<Wife>().HasData(wife1, wife2, wife3, wife4, wife5);

        }

    }
}
