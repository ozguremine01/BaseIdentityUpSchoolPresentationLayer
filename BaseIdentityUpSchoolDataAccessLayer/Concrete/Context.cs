using BaseIdentityUpSchoolEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseIdentityUpSchoolDataAccessLayer.Concrete
{
    //Override -> Hata mesajlarında da kullanmıştık.
    //IdentityDbContext 'i kullanabilmek için EntityFramewotkCore Identity pakti kurulmalı
    //Facebookla giriş veya gmaille girişte claim parametre doldurulacak -> Kullanılacak
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("server=DESKTOP-H7B28ES;database=DbBaseIdentity; integrated security=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
