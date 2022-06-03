using MusicLibrary.Business.Abstract;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.Entities.Concrete;
using System.Collections.Generic;
using System;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using MusicLibrary.Business.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results;
using Business.BusinessAspects.Autofac;

namespace MusicLibrary.Business.Concrete
{
    public class MusicManager : IMusicService
    {
        private readonly IMusicDal _musicDal;

        public MusicManager(IMusicDal musicDal)
        {
            this._musicDal = musicDal;
        }

        [ValidationAspect(typeof(MusicValidator))]
        [SecuredOperation("musicAdd,admin,mod")]
        public IResult Add(Music music)
        {
            this._musicDal.Add(music);

            return new SuccessResult();
        }

        [SecuredOperation("musicDelete,admin,mod")]
        public IResult Delete(Music music)
        {
            this._musicDal.Delete(music);

            return new SuccessResult();
        }

        [SecuredOperation("admin,mod")]
        public IResult DeleteAll()
        {
            this._musicDal.DeleteAll();

            return new SuccessResult();
        }

        public IDataResult<Music> Get(int id)
        {
            return new SuccessDataResult<Music>(this._musicDal.Get(m => m.Id == id));
        }

        public IDataResult<List<Music>> GetAll()
        {
            return new SuccessDataResult<List<Music>>(this._musicDal.GetAll());
        }

        public IDataResult<List<Music>> GetByGenreId(int genreId)
        {
            return new SuccessDataResult<List<Music>>(this._musicDal.GetAll(m => m.GenreId == genreId));
        }

        public int GetNextId()
        {
            return this._musicDal.GetNextId();
        }

        public IDataResult<List<Music>> Search(string name, int genreId, int strParam)
        {
            var result = new List<Music>();
            switch (this.GetSearchOption(name, genreId))
            {
                case 0:
                    result = this._musicDal.GetAll();
                    break;
                case 1:
                    switch (strParam)
                    {
                        case 0:
                            result = this._musicDal.GetAll(m => m.Name.Contains(name));
                            break;
                        case 1:
                            result = this._musicDal.GetAll(m => m.Name.StartsWith(name));
                            break;
                        case 2:
                            result = this._musicDal.GetAll(m => m.Name.EndsWith(name));
                            break;
                    }
                    break;
                case 2:
                    result = this._musicDal.GetAll(m => m.GenreId == genreId);
                    break;

                case 3:
                    switch (strParam)
                    {
                        case 0:
                            result = this._musicDal.GetAll(m => m.Name.Contains(name) & m.GenreId == genreId);
                            break;
                        case 1:
                            result = this._musicDal.GetAll(m => m.Name.StartsWith(name) & m.GenreId == genreId);
                            break;
                        case 2:
                            result = this._musicDal.GetAll(m => m.Name.EndsWith(name) & m.GenreId == genreId);
                            break;
                    }
                    break;
            }

            return new SuccessDataResult<List<Music>>(result);
        }

        /// <summary>
        /// 0 -> no parameter
        /// 1 -> name
        /// 2 -> genre
        /// 3 -> name + genre
        /// </summary>
        /// <param name="name"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        private int GetSearchOption(string name, int genreId)
        {
            var result = 0;

            if (name.Trim() == "" & genreId != 0)
            {
                result = 3;
            }
            else if (name.Trim() == "")
            {
                result = 1;
            }
            else if (genreId != 0)
            {
                result = 2;
            }

            return result;
        }

        [ValidationAspect(typeof(MusicValidator))]
        [SecuredOperation("musicUpdate,admin,mod")]
        public IResult Update(Music music)
        {
            this._musicDal.Update(music);

            return new SuccessResult();
        }
    }
}
