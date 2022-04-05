using Core.DataAccess.Concrete.EntityFramework;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.Entities.Concrete;

namespace MusicLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfGenreDal : EfEntityRepositoryBase<Genre, MusicLibContext>, IGenreDal
    {
    }
}
