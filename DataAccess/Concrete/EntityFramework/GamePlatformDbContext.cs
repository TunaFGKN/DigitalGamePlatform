using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class GamePlatformDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GamePlatformDb;Trusted_Connection=true");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<SystemPersonnel> SystemPersonnels { get; set; }
    }
}
