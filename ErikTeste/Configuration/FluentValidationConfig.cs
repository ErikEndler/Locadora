using ErikTeste.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ErikTeste.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                 .AddFluentValidation(p =>
                 {
                     p.RegisterValidatorsFromAssemblyContaining<ClienteDTOValidator>();
                     p.RegisterValidatorsFromAssemblyContaining<FilmeDTOValidator>();
                     p.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
                 });
        }
    }
}
