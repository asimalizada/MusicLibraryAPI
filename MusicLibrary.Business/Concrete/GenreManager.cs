using MusicLibrary.Business.Abstract;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.DataAccess.Concrete.EntityFramework;
using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;

namespace MusicLibrary.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public void Add(Genre genre)
        {
            this._genreDal.Add(genre);
        }

        public void Delete(Genre genre)
        {
            this._genreDal.Delete(genre);
        }

        public void DeleteAll()
        {
            this._genreDal.DeleteAll();
        }

        public Genre Get(int id)
        {
            return this._genreDal.Get(g => g.Id == id);
        }

        public List<Genre> GetAll()
        {
            return this._genreDal.GetAll();
        }

        public int GetNextId()
        {
            return this._genreDal.GetNextId();
        }

        public void Update(Genre genre)
        {
            this._genreDal.Update(genre);
        }
    }
}
