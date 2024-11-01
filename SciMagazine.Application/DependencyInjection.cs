using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SciMagazine.Application.Interfaces.IUseCases;
using SciMagazine.Application.UseCases;
using FluentValidation;
using SciMagazine.Application.DTOs;


namespace SciMagazine.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {

            services.AddScoped<IRegisterUseCase, RegisterUseCase>();

            services.AddValidatorsFromAssemblyContaining<RegisterRequestDto>();

            return services;
        }
    }
}
