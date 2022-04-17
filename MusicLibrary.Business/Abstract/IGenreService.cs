using Core.Utilities.Results.Abstract;
using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;

namespace MusicLibrary.Business.Abstract
{
    public interface IGenreService
    {
        IResult Add(Genre genre);
        IResult Update(Genre genre);
        IResult Delete(Genre genre);
        IResult DeleteAll();
        IDataResult<int> GetNextId();
        IDataResult<Genre> Get(int id);
        IDataResult<List<Genre>> GetAll();
    }
}
