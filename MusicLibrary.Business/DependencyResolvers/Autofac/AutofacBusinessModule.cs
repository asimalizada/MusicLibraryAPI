using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
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

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
