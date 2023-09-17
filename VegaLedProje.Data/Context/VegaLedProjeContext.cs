using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Data.Entities;

namespace VegaLedProje.Data.Context
{
    public class VegaLedProjeContext : DbContext
    {
       
        public VegaLedProjeContext(DbContextOptions<VegaLedProjeContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OurServicesEntity> OurServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
           {
               new UserEntity()
               {
                   Id=1,
                   UserName="admin",
                   Password="123456",
                   UserType=Enums.UserTypeEnum.admin
               }
           });

            base.OnModelCreating(modelBuilder);
        }
    }
}
