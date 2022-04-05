using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;

namespace MusicLibrary.Business.Abstract
{
    public interface IGenreService
    {
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        void DeleteAll();
        int GetNextId();
        Genre Get(int id);
        List<Genre> GetAll();
    }
}
