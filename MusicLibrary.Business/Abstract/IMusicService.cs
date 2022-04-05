using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;

namespace MusicLibrary.Business.Abstract
{
    public interface IMusicService
    {
        void Add(Music music);
        void Update(Music music);
        void Delete(Music music);
        void DeleteAll();
        Music Get(int id);
        List<Music> GetAll();
        int GetNextId();
        List<Music> GetByGenreId(int genreId);
        List<Music> Search(string name, int genreId, int strParam);
    }
}
