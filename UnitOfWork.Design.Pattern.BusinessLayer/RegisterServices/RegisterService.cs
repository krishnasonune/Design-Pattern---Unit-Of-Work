using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Repository;

namespace UnitOfWork.Design.Pattern.BusinessLayer.RegisterServices;
public static class RegisterService
{
    public static IServiceCollection ExtendServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.Design.Pattern.BusinessLayer.Repository.UnitOfWork>();
        services.AddScoped<IMovies, MovieRepository>();
        services.AddScoped<IUser, UserRepository>();
        return services;
    }
}
