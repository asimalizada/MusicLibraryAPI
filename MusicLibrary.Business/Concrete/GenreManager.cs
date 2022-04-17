using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MusicLibrary.Business.Abstract;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.DataAccess.Concrete.EntityFramework;
using MusicLibrary.Entities.Concrete;
using System;
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

        public IResult Add(Genre genre)
        {
            this._genreDal.Add(genre);

            return new SuccessResult();
        }

        public IResult Delete(Genre genre)
        {
            this._genreDal.Delete(genre);
            return new SuccessResult();
        }

        public IResult DeleteAll()
        {
            this._genreDal.DeleteAll();
            return new SuccessResult();
        }

        public IDataResult<Genre> Get(int id)
        {
            return new SuccessDataResult<Genre>
                       (this._genreDal.Get(g => g.Id == id), "Working correctly!");
        }

        public IDataResult<List<Genre>> GetAll()
        {
            if(DateTime.Now.Hour > 0 & DateTime.Now.Hour <= 3)
            {
                return new ErrorDataResult<List<Genre>>("This method cannot use now");
            }

            return new SuccessDataResult<List<Genre>>
                       (this._genreDal.GetAll(), "Working correctly!");
        }

        public IDataResult<int> GetNextId()
        {
            return new SuccessDataResult<int>(this._genreDal.GetNextId());
        }

        public IResult Update(Genre genre)
        {
            this._genreDal.Update(genre);
            return new SuccessResult();
        }
    }
}
