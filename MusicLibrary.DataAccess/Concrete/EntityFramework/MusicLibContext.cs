using MusicLibrary.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.DataAccess.Concrete.EntityFramework
{
    public class MusicLibContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = (localdb)\mssqlLocaldb; Database = MusicDB; Trusted_connection=true"); // link
        }
    }
}