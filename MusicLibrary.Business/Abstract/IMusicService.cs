using Core.Utilities.Results.Abstract;
using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;

namespace MusicLibrary.Business.Abstract
{
    public interface IMusicService
    {
        IResult Add(Music music);
        IResult Update(Music music);
        IResult Delete(Music music);
        IResult DeleteAll();
        IDataResult<Music> Get(int id);
        IDataResult<List<Music>> GetAll();
        int GetNextId();
        IDataResult<List<Music>> GetByGenreId(int genreId);
        IDataResult<List<Music>> Search(string name, int genreId, int strParam);
    }
}
