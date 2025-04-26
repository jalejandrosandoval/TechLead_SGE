using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TechLead_SGE.Server.Utilities.Classes.Cors.Common
{
    /// <summary>
    /// Clase para la configuración inicial de CORS.
    /// </summary>
    public static class InitCors
    {
        /// <summary>
        /// Método para inicializar la configuración de CORS.
        /// </summary>
        /// <param name="Services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureCorsApi(this IServiceCollection Services)
        {
            Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:50608")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return Services;
        }

        /// <summary>
        /// Método para inicializar el uso de CORS en la API.
        /// </summary>
        /// <param name="App"></param>
        public static void ConfigureUseCorsApi(this WebApplication App)
        {
            App.UseCors("AllowSpecificOrigins");
        }
    }
}