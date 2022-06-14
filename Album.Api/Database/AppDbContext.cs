using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Album.Api.Models;

namespace Album.Api.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<AlbumModel> Albums { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          //  => optionsBuilder.UseNpgsql("User ID=root;Password=password;Host=cnsd-db-537734144164.cxsdm42x2daw.us-east-1.rds.amazonaws.com;Database=cnsd-db-537734144164;Port=5432");
        //optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}
