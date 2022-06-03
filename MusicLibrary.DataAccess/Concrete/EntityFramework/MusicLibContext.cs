using MusicLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;

namespace MusicLibrary.DataAccess.Concrete.EntityFramework
{
    public class MusicLibContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = (localdb)\mssqlLocaldb; Database = MusicDB; Trusted_connection=true"); // link
        }
    }
}