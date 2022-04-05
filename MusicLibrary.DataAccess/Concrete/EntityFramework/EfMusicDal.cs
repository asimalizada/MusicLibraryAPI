using Core.DataAccess.Concrete.EntityFramework;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.Entities.Concrete;

namespace MusicLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfMusicDal : EfEntityRepositoryBase<Music, MusicLibContext>, IMusicDal
    {
    }
}
