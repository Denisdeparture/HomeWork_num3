using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHome
{
    public class BaseColor : DbContext
    {
        public DbSet<Color> Colors => Set<Color>();
        public BaseColor()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = color.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(new Color() { numberColor = 1, nameColor = "red", Id = 1 }, new Color() { numberColor = 2, nameColor = "blue", Id = 2 });
        }
    }
    
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public int numberColor { get; set; }
        public string? nameColor { get; set; }
    }
}
