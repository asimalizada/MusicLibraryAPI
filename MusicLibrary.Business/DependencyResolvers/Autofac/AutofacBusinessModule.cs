using Autofac;
using MusicLibrary.Business.Abstract;
using MusicLibrary.Business.Concrete;
using MusicLibrary.DataAccess.Abstract;
using MusicLibrary.DataAccess.Concrete.EntityFramework;

namespace MusicLibrary.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfGenreDal>().As<IGenreDal>().SingleInstance();
            builder.RegisterType<EfMusicDal>().As<IMusicDal>().SingleInstance();

            builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();
            builder.RegisterType<MusicManager>().As<IMusicService>().SingleInstance();
        }
    }
}
