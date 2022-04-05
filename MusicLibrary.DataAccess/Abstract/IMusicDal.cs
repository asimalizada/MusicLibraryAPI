using Core.DataAccess.Abstract;
using MusicLibrary.Entities.Concrete;

namespace MusicLibrary.DataAccess.Abstract
{
    public interface IMusicDal : IEntityRepository<Music>
    {
    }
}
